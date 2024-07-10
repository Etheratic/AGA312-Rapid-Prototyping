using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;

        if (gameObject.transform.position.y < 3)
        {
            Destroy(gameObject);
        }
    }
}
