using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    [Header("Read Only variables")]
    [SerializeField]
    Spawner[] spawners;
    [Header("Other variables")]
    [SerializeField]
    float initalTimeToSpawn = 1f;
    [SerializeField]
    float spawnTimeToDecrease = .005f;
    [SerializeField]
    float initalSpeed = .75f;
    [SerializeField]
    float speedToIncrease = .01f;
    [SerializeField]
    float minTimeToSpawn = .2f;
    [Header("Prefabs")]
    [SerializeField]
    GameObject enemyPrefab;


    float currentTimeToSpawn;

	void Start () {

        spawners = GetComponentsInChildren<Spawner>();

        currentTimeToSpawn = initalTimeToSpawn;
        Invoke("SpawnEnemy", currentTimeToSpawn);
	}

    void SpawnEnemy()
    {

        int randomSpawner = Random.Range(0, spawners.Length);
        Instantiate(enemyPrefab, spawners[randomSpawner].transform.position,
            spawners[randomSpawner].transform.rotation);

        currentTimeToSpawn -= spawnTimeToDecrease;
        if(currentTimeToSpawn < minTimeToSpawn)
        {
            currentTimeToSpawn = minTimeToSpawn;
        }
        Invoke("SpawnEnemy", currentTimeToSpawn);
    }
}
