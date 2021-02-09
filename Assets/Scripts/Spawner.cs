using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle[] enemyPrefabs;
    [SerializeField] float minTimeBetweenSpawn = 1;
    [SerializeField] float maxTimeBetweenSpawn = 1;
    float timeBetweenSpawn;
    GameSession gameSession;
    Coroutine spawnCoroutine;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy() {
        while (spawning) {
            timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Debug.Log("Spawning -> " + randomIndex.ToString());
            Obstacle enemyToSpawn = Instantiate(enemyPrefabs[randomIndex], 
                transform.position, Quaternion.identity) as Obstacle;
            enemyToSpawn.transform.parent = transform;        
            yield return new WaitForSecondsRealtime(timeBetweenSpawn);
        }
    }

    public void Spawn() {
        spawning = true;
        StartCoroutine(SpawnEnemy());
    }

    public void StopSpawning() {
        spawning = false;
    }
}
