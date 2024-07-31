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
        width = gameObject.GetComponent<Transform>().localScale.x;

        
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

        

        if (Input.GetKey(KeyCode.P) && isSelected == true)
        {
            width += 10;
            print("grow");
            float scale = transform.localScale.x;
            gameObject.transform.localScale += new Vector3(scale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }

        if (Input.GetKey(KeyCode.O) && isSelected == true)
        {

            width -= 10;
            width = gameObject.GetComponent<Transform>().localScale.x;


        }

       
    }
}
