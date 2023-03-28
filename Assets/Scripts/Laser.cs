using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    // Speed variable
    [SerializeField]
    private float _speed = 8f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Translate laser up
//        transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime);
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
}
