using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    // Speed variable
    [SerializeField]
    private float _speed = 8f;
    
    private bool _isEnemyLaser = false; // To distinguish the lasers


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        } else
        {
            MoveDown();
        }
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    void MoveUp()
    {
        // Translate laser up

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // If laser position is >8 on the y, destroy it. 
        if (transform.position.y > 8f)
        {
            // If object has a parent (Triple_Shot), destroy it. 
            // If this laser is part of the triple shot power up...
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        _speed = 5f;
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
