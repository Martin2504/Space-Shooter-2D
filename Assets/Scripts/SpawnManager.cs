using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // (1) Spawn game objects every 3 seconds. 
        // Create a co-routine of type IEnumerator which allows us to Yield events.
    IEnumerator SpawnRoutine()
    {
        while (_isPlayerDead == false)          // loop until player dies.
        {   // Instantiate enemy prefab, yield wait for 3 seconds.
            Vector3 positionToSpawn = new Vector3(Random.Range(-6f, 6f), 7, 0);                             // Random Spawn point. 
            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);          // Instantiate.
            newEnemy.transform.parent = _enemyContainer.transform;                                          // Assign to enemy container.
            yield return new WaitForSeconds(3.0f);                                                          // Wait 3 seconds and re-loop. 
        }
    }

    public void OnPlayerDeath()                 // Called if player dies.
    {
        _isPlayerDead = true;
    }

}
