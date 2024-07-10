using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnManager;

public class EnemySpawn : MonoBehaviour
{
    public enum Spawn {A,B,C}
    public GameObject enemy;
    public GameObject spawnA;
    public GameObject spawnB;
    public GameObject spawnC;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(1, Spawn.A);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.position = new Vector3(0, 0, -1) * Time.deltaTime;
        if (enemyCount <= 0)
        {
            SpawnEnemies(2, (Spawn)Random.Range(0, System.Enum.GetValues(typeof(Spawn)).Length));
        }
    }

    void SpawnEnemies(int _numberOfEnemies, Spawn _SpawnLocation)
    {
        for (int i = 0; i < _numberOfEnemies; i++)
        {
            switch (_SpawnLocation)
            {
                case Spawn.A:
                    {
                        Instantiate(enemy, spawnA.transform.position, spawnA.transform.rotation);
                        print("working");
                        
                    }
                    break;
            }

            switch (_SpawnLocation)
            {
                case Spawn.B:
                    {
                       
                    }
                    break;
            }

            switch (_SpawnLocation)
            {
                case Spawn.C:
                    {

                    }
                    break;
            }

            enemyCount++;
           
        }
    }
}
