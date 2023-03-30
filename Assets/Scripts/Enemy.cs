using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // (1) Move Enemy down at 4m/s
            // Respawn emeny at top when it reaches bottom of the screen with new random x position.
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);   // Moves enemy down. 
        if (transform.position.y < -6)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 6, 0);  // sets position to top of screen and random x value. 
        }
    }

    // This method is a collsion method for 2D. 
    // Its called upon any collision with this object. 
    private void OnTriggerEnter2D(Collider2D other)     // other is the other object which collided with the Enemy. 
    {
        // If other is player -> Damage player & then Destroy Enemy.
        // If other is laser -> Destroy Laser & then Destroy Enemy. 
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {   // Calling the damage method on the player component.
                player.Damage();
            }
            Destroy(this.gameObject);
        } else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}