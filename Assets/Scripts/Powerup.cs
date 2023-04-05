using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]     
    private float _speed = 3.0f;

    // Uniquely identify powerups
    [SerializeField]        // 0 = Triple Shot, 1 = Speed, 2 = Shields
    private int powerupID;      

    // Start is called before the first frame update
    void Start()
    {

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
                switch (powerupID)
                {
                    case 0:
                        // Activate triple shot powerup
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
