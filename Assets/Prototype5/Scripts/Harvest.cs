using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void HarvestCrop()
    {
        Destroy(gameObject);
        gameController.HarvestCrop();
        print("crop harvested");
    }



}