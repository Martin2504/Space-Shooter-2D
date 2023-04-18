using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroyMe());
    }
    private IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(2.38f);
        Destroy(this.gameObject);
    }
}
