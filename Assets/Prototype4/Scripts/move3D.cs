using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class move3D : GameBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public float width;
    public bool isSelected;

    
      

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        width = 1;
        
        
    }

   
    private void OnMouseDrag()
    {
        isSelected = true;
        Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
        Vector3 NewWorldPos = mainCamera.ScreenToWorldPoint(ScreenPos);
        transform.position = NewWorldPos;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.UpArrow) && isSelected == true)
        {
            width += 0.1f;
            print("grow");
           
            gameObject.transform.localScale += new Vector3(width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isSelected == true)
        {

            width -= 0.1f;
            
            gameObject.transform.localScale = new Vector3(width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);


        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

       
    }
}
