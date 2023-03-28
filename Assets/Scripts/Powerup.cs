using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]     
    private float _speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Move down at a speed of 3.
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
        // When it leaves the screen destroy this object.
        if (transform.position.y < -5.7f)
        {
            Destroy(this.gameObject);
        }

    }

    // Power up collision. 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Activate triple shot
            Player player = other.transform.GetComponent<Player>();     // Get refenernce to player component. 
            if (player != null)
            {
                player.TripleShotActive();
            }
            
            Destroy(this.gameObject);
        }
    }
}
