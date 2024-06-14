using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameBehaviour
{



    public enum EnemyType { Red, Green, Blue }
    public List<int> red,green,blue;

    public GameObject REnemy;
    public GameObject BEnemy;
    public GameObject GEnemy;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    private int enemies;
     

    // Start is called before the first frame update
    void Start()
    {
       

        SpawnEnemyWave(1, (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));
        //Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
      
      
    }

  

    void SpawnEnemyWave(int enemiesToSpawn, EnemyType _enemyType)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            switch (_enemyType)
            {
                case EnemyType.Red:
                    {
                        Instantiate(REnemy, GenerateSpawnPos(), REnemy.transform.rotation);
                        print("R spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case EnemyType.Blue:
                    {
                        Instantiate(BEnemy, GenerateSpawnPos(), REnemy.transform.rotation);
                        print("B spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case EnemyType.Green:
                    {
                        Instantiate(GEnemy, GenerateSpawnPos(), REnemy.transform.rotation);
                        print("G spawn");
                    }
                    break;
            }
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
           


            for (int i = 0; i < waveNumber; i++)
            {
                NewWave();
            }


        }
    }

    void NewWave()
    {
        SpawnEnemyWave(1, (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));
    }

    
}
