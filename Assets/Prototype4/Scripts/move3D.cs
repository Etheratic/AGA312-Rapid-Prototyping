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

        

        if (Input.GetKey(KeyCode.Alpha1) && isSelected == true)
        {
            width += 10;
            

        }

        if (Input.GetKey(KeyCode.Alpha2) && isSelected == true)
        {

            width -= 10;
            width = gameObject.GetComponent<Transform>().localScale.x;


        }

        width = gameObject.GetComponent<Transform>().localScale.x;
    }
}
