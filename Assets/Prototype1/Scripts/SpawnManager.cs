using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameBehaviour
{



    public enum EnemyType { Red, Green, Blue }
    public enum MergedEnemyType { Cyan, Magenta, Yellow }
    public List<int> red,green,blue;

    public GameObject REnemy;
    public GameObject BEnemy;
    public GameObject GEnemy;
    public GameObject CEnemy;
    public GameObject YEnemy;
    public GameObject MEnemy;
    public float spawnRange = 14;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    private int enemies;
    public int mergedCount;

    UIManager uiManager;

    
     

    // Start is called before the first frame update
    void Start()
    {
       

        SpawnEnemyWave(1, (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));
        //Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uiManager.DisplayWaveCount(waveNumber);


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
                        REnemy.gameObject.GetComponent<Collider>().enabled = true;
                        REnemy.gameObject.GetComponent<Collider>().isTrigger = false;
                        print("R spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case EnemyType.Blue:
                    {
                        Instantiate(BEnemy, GenerateSpawnPos(), REnemy.transform.rotation);
                        BEnemy.gameObject.GetComponent<Collider>().enabled = true;
                        BEnemy.gameObject.GetComponent<Collider>().isTrigger = false;
                        print("B spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case EnemyType.Green:
                    {
                        Instantiate(GEnemy, GenerateSpawnPos(), REnemy.transform.rotation);
                        GEnemy.gameObject.GetComponent<Collider>().enabled = true;
                        GEnemy.gameObject.GetComponent<Collider>().isTrigger = false;

                        print("G spawn");
                    }
                    break;
            }
        }
       
    }

    void SpawnMergedEnemyWave(int enemiesToSpawn, MergedEnemyType _enemyType)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            switch (_enemyType)
            {
                case MergedEnemyType.Cyan:
                    {
                        Instantiate(CEnemy, GenerateSpawnPos(), CEnemy.transform.rotation);
                        CEnemy.gameObject.GetComponent<Collider>().enabled = true;
                        CEnemy.gameObject.GetComponent<Collider>().isTrigger = false;
                        print("C spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case MergedEnemyType.Magenta:
                    {
                        Instantiate(MEnemy, GenerateSpawnPos(), MEnemy.transform.rotation);
                        MEnemy.gameObject.GetComponent<Collider>().enabled = true;
                        MEnemy.gameObject.GetComponent<Collider>().isTrigger = false;
                        print("M spawn");
                    }
                    break;
            }

            switch (_enemyType)
            {
                case MergedEnemyType.Yellow:
                    {
                        Instantiate(YEnemy, GenerateSpawnPos(), YEnemy.transform.rotation);
                        YEnemy.gameObject.GetComponent<Collider>().enabled = true;
                        YEnemy.gameObject.GetComponent<Collider>().isTrigger = false;

                        print("Y spawn");
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
            uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            waveNumber++;
            uiManager.DisplayWaveCount(waveNumber);
            if (waveNumber > 5)
            {
                mergedCount++;
            }



            for (int i = 0; i < waveNumber; i++)
            {
                NewWave();

            }

            for (int i = 0; i < mergedCount; i++)
            {

                NewMergedWave();


            }


        }

    }

    void NewWave()
    {
        SpawnEnemyWave(1, (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));

        
    }

    void NewMergedWave()
    {
        SpawnMergedEnemyWave(1, (MergedEnemyType)Random.Range(0, System.Enum.GetValues(typeof(MergedEnemyType)).Length));
    }

    
}
