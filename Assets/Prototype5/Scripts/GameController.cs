using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : GameBehaviour
{
    public int money;
    public int days;
    public int cropsHarvested = 0;

    UIController uiController;
    InputManager inputManager;

    public void Start()
    {
        uiController = FindObjectOfType<UIController>();
        inputManager = FindObjectOfType<InputManager>();
        uiController.UpdateCrop(cropsHarvested);
    }

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
        uiController.UpdateCrop(cropsHarvested);
        inputManager.SeedsInInventory += 2;
        
    }
}
