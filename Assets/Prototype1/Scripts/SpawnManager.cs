using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
     

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
      
      
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
        }
    }
}
