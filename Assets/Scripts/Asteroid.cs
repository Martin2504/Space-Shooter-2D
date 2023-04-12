using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationspeed = 30f;

    // handle to animatior component. 
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("The Animator is NULL.");
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
            Destroy(other.gameObject);
            _animator.SetTrigger("OnAsteroidDestruction");
            Destroy(this.gameObject, 2.38f);
        }
    }
}
