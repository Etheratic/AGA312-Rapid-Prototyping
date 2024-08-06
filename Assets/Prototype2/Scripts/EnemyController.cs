using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float speed = 100;
    public int points;
    public TMP_Text scoreText;
 


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (gameObject.transform.position.y < 3)
        {               
            Destroy(gameObject);
            points += 1;
        }
    }
}
