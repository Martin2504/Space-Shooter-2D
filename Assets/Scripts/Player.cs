using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour                     // : means inherits
                                                        // MonoBehaviour gives us two functions out of the box. Start and Update. 
{

    [SerializeField]    // This annotation means the value can be adjusted in the inspector. 
    private float _speed = 3.5f;
    [SerializeField]
    public GameObject _laserPrefab;
    [SerializeField]
    public GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;     // Giving the player 3 lives. 
    private SpawnManager _spawnManager;

    [SerializeField]
    private bool _isTripleShotActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Access the transform component of the Player Object and change its position.
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();      // Get SpawnManager component. 
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

            // (3) Spawn game object when space key is pressed. Add a cool down of 0.5 seconds. 
                // Time.time is how long the game has been running, in seconds. 
                // If spacebar is pressed...
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }



    }

    void CalculateMovement()    // All code related to movement. 
    {
        // Declare inputs using local variable and set them to their corresponding Axis. This allows us to move the object using the arrow keys. 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

            // (1) Lets move the object by using the arrow keys 
                // Vector3.right is the same as writing 'new Vector3(1, 0, 0)'
                // new Vector3(1, 0, 0) * 0 {the horizontalInput variable}  * 3.5f * real time. 
//        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
                // new Vector3(0, 1, 0) * 0 {the verticalInput variable}  * 3.5f * real time.
//        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
                // A more optimized solution. 
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

            // (2) Lets add some restraints
                // Add y restraint minimum -3.8f and maximum 1. 
                // An optimized solution for 'clamping' the y values between 1 and -3.8f. 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 1), 0);

                // Add x restraint minimum -11f and maximum 11, but make it wrap around. 
        if (transform.position.x >= 11)
        {       // transform.position.y = current y position
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
                // Making projecties spawn on the player object. 
        _canFire = Time.time + _fireRate;     // Reassign + cool down delay. 

        
        if (_isTripleShotActive == true)
        {   // Tripple shot power up.
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);        // Quaternion.identity = defult rotation.
        } else
        {   // Regular shot.
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);  // Adding 1.05 offset above player.
        }
    }

    public void Damage()    // Method to damage the player.
    {
        _lives--;   // Subtract 1 from _lives. 

        if (_lives == 0)    // Are we dead?
        {
            _spawnManager.OnPlayerDeath();      // Telling the spawn manager player has died.
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        // Staring power down coroutine for triple shot
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }
}
