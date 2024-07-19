using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject timer3;
    public int tilesCompleted;
    public int numOfTiles;
    public GameObject winScreen;


    // Start is called before the first frame update
    void Start()
    {
        numOfTiles = GameObject.FindGameObjectsWithTag("tile").Length;
        tilesCompleted = 0;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(tilesCompleted == numOfTiles)
        {
            print("gameCompleted yay");
            timer3.GetComponent<Timer>().StopTimer();
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }

    public void AddPoint()
    {
        tilesCompleted = tilesCompleted + 1;
        print("point added");

    }

    public void LosePoint()
    {
        tilesCompleted -= 1;
    }
}
