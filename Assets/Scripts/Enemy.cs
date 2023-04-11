using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2f;

    private Player _player;

    // handle to animatior component. 
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();     // Getting a reference to the player component
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("The Animator is NULL.");
        }

        if ( _player == null )
        {
            Debug.LogError("The Player is NULL.");
        }
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
            _animator.SetTrigger("OnEnemyDeath");   // Trigger destroy animation. 
            _speed = 0;
            Destroy(this.gameObject, 2.38f);         // Destroy game object after 2.38 seconds. 
        } else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.38f);
        }

    }
}
