using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsAGridLayer;
    GridCell gridCell;
    public GameObject crop;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
        gridCell = FindObjectOfType<GridCell>();
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        if(cellMouseIsOver != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Instantiate(crop, cellMouseIsOver.transform);
                gridCell.isOccupied = true;
            }
        }
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


   

}
