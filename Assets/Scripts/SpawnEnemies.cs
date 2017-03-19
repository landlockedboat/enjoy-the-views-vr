using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    float maxSpeed = 5f;
    [SerializeField]
    float minTimeToSpawn = .2f;
    [Header("Prefabs")]
    [SerializeField]
    GameObject enemyPrefab;

    bool isGameOver = false;
    float currentTimeToSpawn;
    float currentSpeed;

    void Start () {

        spawners = GetComponentsInChildren<Spawner>();

        currentTimeToSpawn = initalTimeToSpawn;
        currentSpeed = initalSpeed;
        Invoke("SpawnEnemy", currentTimeToSpawn);
        GameMaster.Instance.RegisterOnGameOverCallback(GameOver);
	}

    void GameOver()
    {
        isGameOver = true;
    }

    void SpawnEnemy()
    {
        if (isGameOver)
        {
            return;
        }
        int randomSpawner = Random.Range(0, spawners.Length);
        GameObject enemy = 
            Instantiate(enemyPrefab, spawners[randomSpawner].transform.position,
                spawners[randomSpawner].transform.rotation);

        currentSpeed += speedToIncrease;
        if(currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        enemy.GetComponent<NavMeshAgent>().speed = currentSpeed;

        currentTimeToSpawn -= spawnTimeToDecrease;
        if(currentTimeToSpawn < minTimeToSpawn)
        {
            currentTimeToSpawn = minTimeToSpawn;
        }
        Invoke("SpawnEnemy", currentTimeToSpawn);
    }
}
