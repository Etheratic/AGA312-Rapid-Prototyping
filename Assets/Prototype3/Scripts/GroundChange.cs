using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChange : GameBehaviour
{
    public float growth;
    public bool isGrowing;
    public bool isComplete;
    public int tilesCompleted;
    public int tiles;

    // Start is called before the first frame update
    void Start()
    {
        isGrowing = false;
        gameObject.GetComponent<Renderer>().material.color = new Color(.537f, .318f, .161f, 0);


        tiles = GameObject.FindGameObjectsWithTag("tile").Length;

    }

    // Update is called once per frame
    void Update()
    {

        if (growth >= 5f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (growth >= 10f) 
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            isComplete = true;
            StopGrow();
            print("complete");
            tilesCompleted += 1;
          
        }

        if (isGrowing == true)
        {
            growth += 1 * Time.deltaTime;
            print("growing");
        }

        if (isComplete ==  true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        
        }

        if(tilesCompleted == tiles)
        {
            print("game complete");
        }

    }

    public void Grow()
    {
        isGrowing = true;
  
    }
    public void StopGrow()
    {
        isGrowing = false;
    }

   
}
