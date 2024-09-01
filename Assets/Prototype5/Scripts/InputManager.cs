using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsAGridLayer;
    GridCell gridCell;
    public GameObject crop;
    public int cropSpawn;

    public int SeedsInInventory = 5;
    UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
        gridCell = FindObjectOfType<GridCell>();
        uiController = FindObjectOfType<UIController>();
        uiController.UpdateSeed(SeedsInInventory);


    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        if(cellMouseIsOver != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && SeedsInInventory > 0 && cellMouseIsOver.isOccupied == false)
            {
                SeedsInInventory -= 1;
                Instantiate(crop, cellMouseIsOver.transform);


                cellMouseIsOver.isOccupied = true;
              
              
            }

        }

        

        uiController.UpdateSeed(SeedsInInventory);



    }

    //returns the frid cell if the mouse is over it and null if over nothing

    private GridCell IsMouseOverAGridSpace()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGridLayer ))
        {
            return hitInfo.transform.GetComponent<GridCell>();

        }
        else
        {
            return null;
        }
    }

    public void cellIsClear()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();

        cellMouseIsOver.isOccupied = false;


    }
   
   

}
