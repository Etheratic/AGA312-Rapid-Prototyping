using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    public List<GameObject> equations;
    public GameObject spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Spawn(int _type)
    {
        Instantiate(equations[_type], spawnPos.transform);
        print("spawned" + _type);
    }
}
