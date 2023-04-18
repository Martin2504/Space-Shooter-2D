using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationspeed = 30f;

    // handle to animatior component. 
//    private Animator _animator;

    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private AudioClip _explosionSoundEffect;
    [SerializeField]
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {

//        _animator = GetComponent<Animator>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();

//        if (_animator == null)
//        {
//            Debug.LogError("The Animator is NULL.");
//        }
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        if (_audioSource == null)
        {
            Debug.LogError("AudioSource on the asteroid is NULL.");
        }
        else
        {
            _audioSource.clip = _explosionSoundEffect;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * _rotationspeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)     // other is the other object which collided with the Enemy. 
    {
        if (other.tag == "Laser")
        {
            GameObject newExplision = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            newExplision.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            _audioSource.Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
           

//            _animator.SetTrigger("OnAsteroidDestruction");
//            Destroy(this.gameObject, 2.38f);

            _spawnManager.StartSpawning();
           
        }
    }
}
