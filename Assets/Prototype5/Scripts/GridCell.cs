using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class GridCell : MonoBehaviour
{
    public int posX;
    public int posY;
    
    //saves a reference to the gameobject that gets placed on this cell
    public GameObject objectInThisGridSpace = null;

    //is the grids space occupied or not
    public bool isOccupied = false;

    
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    //get the pos of this grid space in the grid
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }

   
}
