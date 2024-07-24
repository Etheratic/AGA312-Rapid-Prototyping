using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundChange : GameBehaviour
{
    public float growth;
    public bool isGrowing;
    public bool isComplete;
    public int tilesCompleted;
    public int tiles;
    public bool hasCompleted;
    public float changeSpeed = 2
;


   
   GroundController groundController;

    // Start is called before the first frame update
    void Start()
    {
        isGrowing = false;
        gameObject.GetComponent<Renderer>().material.color = new Color(.4196f, .3176f, .251f, 1);


        tiles = GameObject.FindGameObjectsWithTag("tile").Length;
        hasCompleted = false;

        groundController = GameObject.Find("GroundController").GetComponent<GroundController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (growth >= .5f && hasCompleted == false)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(new Color(.4196f - .2941f,.6922f - .3176f, .2927f - .251f, 1), changeSpeed);
        }

        if (growth >= 1f && hasCompleted == false)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(new Color(.2941f,.6922f,.2927f,1), changeSpeed);
        }

        if (growth >= 1.5f && hasCompleted == false)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(new Color(1f -.2941f,.7255f - .6922f, .3529f - .2927f, 1), changeSpeed);
        }

        if (growth >= 2f && hasCompleted == false) 
        {
          
            
            StopGrow();
            print("complete");
            TileCompleted();
            gameObject.GetComponent<Renderer>().material.DOColor(new Color(1f, .7255f, .3529f, 1), changeSpeed);




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
      


        gameObject.GetComponent<BoxCollider>().enabled = false;
        groundController.AddPoint();



    }

 
}
