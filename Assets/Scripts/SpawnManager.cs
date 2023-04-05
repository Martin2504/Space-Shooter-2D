using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // (1) Spawn game objects every 3 seconds. 
        // Create a co-routine of type IEnumerator which allows us to Yield events.
    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)          // loop until player dies.
        {   // Instantiate enemy prefab, yield wait for 3 seconds.
            Vector3 positionToSpawn = new Vector3(Random.Range(-6f, 6f), 7, 0);                             // Random Spawn point. 
            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);          // Instantiate.
            newEnemy.transform.parent = _enemyContainer.transform;                                          // Assign to enemy container.
            yield return new WaitForSeconds(3.0f);                                                          // Wait 3 seconds and re-loop. 
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        // Spawn powerup every 3-7 seconds.  
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(powerups[Random.Range(0, 3)], posToSpawn, Quaternion.identity);     // Random.Range(0, 3) = 0, 1, 2
            yield return new WaitForSeconds(Random.Range(3f, 7f));

        }
    }

    public void OnPlayerDeath()                 // Called if player dies.
    {
        _stopSpawning = true;
    }


}
