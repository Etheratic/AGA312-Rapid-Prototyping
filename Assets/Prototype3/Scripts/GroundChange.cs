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
    public bool hasCompleted;

   GroundController groundController;

    // Start is called before the first frame update
    void Start()
    {
        isGrowing = false;
        gameObject.GetComponent<Renderer>().material.color = new Color(.537f, .318f, .161f, 0);


        tiles = GameObject.FindGameObjectsWithTag("tile").Length;
        hasCompleted = false;

        groundController = GameObject.Find("GroundController").GetComponent<GroundController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (growth >= 2f && hasCompleted == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (growth >= 4f && hasCompleted == false) 
        {
          
            
            StopGrow();
            print("complete");
            TileCompleted();
            
           
          
        }

        if (isGrowing == true)
        {
            growth += 1 * Time.deltaTime;
          
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

   public void TileCompleted()
    {

        hasCompleted = true;
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        
        gameObject.GetComponent<BoxCollider>().enabled = false;
        groundController.AddPoint();
    }
}
