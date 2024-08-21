using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : GameBehaviour
{
    public int money;
    public int days;
    public int cropsHarvested;



    public void NewDay()
    {
        days += 1;
    }

    public void AddMoney(int _money)
    {

    }

    public void HarvestCrop()
    {
        cropsHarvested += 1;
    }
}
