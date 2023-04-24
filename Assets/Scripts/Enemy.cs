using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2f;
    private Player _player;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private AudioClip _explosionSoundEffect;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 5.0f;
    private float _canFire = -1;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();     // Getting a reference to the player component
        _audioSource = GetComponent<AudioSource>();

        if (_player == null )
        {
            Debug.LogError("The Player is NULL.");
        }

        if (_audioSource == null)
        {
            Debug.LogError("AudioSource on the enemy is NULL.");
        } else {
            _audioSource.clip = _explosionSoundEffect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalulateMovement();

        if (_player._score >= 100)
        {
            Fire();
        }

    }

    void Fire()
    {
        if (Time.time > _canFire )
        {
            _fireRate = Random.Range(4f, 6f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
        
    }

    void CalulateMovement()
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
            GameObject newExplision = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            newExplision.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            _audioSource.Play();
            Destroy(this.gameObject);         
            
        } else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            GameObject newExplision = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            newExplision.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            _audioSource.Play();
            Destroy(this.gameObject);
        }
    }
}
