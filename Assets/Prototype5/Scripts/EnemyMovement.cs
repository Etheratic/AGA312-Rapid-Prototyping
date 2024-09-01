using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public float enemySpeed;
    public int enemyHealth = 9;
    public float knockBackStr = 5;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 1 * enemySpeed * Time.deltaTime);
    }

    public void EnemyKnockBack()
    {
        

        Vector3 awayFromPlayer = (gameObject.transform.position - target.transform.position);

        if(enemyHealth > 0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * knockBackStr, ForceMode.Impulse);
        }
        else
        {
            Destroy(gameObject);
            print("enemy killed");
        }
            
        
       
    }
}
