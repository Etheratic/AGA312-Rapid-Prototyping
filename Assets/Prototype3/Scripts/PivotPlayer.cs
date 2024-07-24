using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPlayer : GameBehaviour
{
    public GameObject pivotPointA;
    public GameObject pivotPointB;
    public float spinSpeed;
    public bool pivotAB;
    public GameObject reset;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pivotAB = !pivotAB;
        }

        if(pivotAB == true)
        {
            transform.RotateAround(pivotPointA.transform.position, Vector3.forward, -20 * Time.deltaTime * spinSpeed);
        }

        else
        {
            transform.RotateAround(pivotPointB.transform.position, Vector3.forward, -20 * Time.deltaTime * spinSpeed);
        }
        
        

       
    }

    private void OnBecameInvisible()
    {
        gameObject.transform.position = reset.transform.position;
    }
}
