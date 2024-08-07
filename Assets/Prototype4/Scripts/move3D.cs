using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class move3D : GameBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public float width;
    public bool isSelected;
    public Renderer shape;
   
    
      

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        width = 0.5f;
        shape = GetComponentInChildren<Renderer>();
        
        
    }

    private void OnMouseOver()
    {
        shape.material.DOColor(Color.red, .2f);
    }
    private void OnMouseDrag()
    {
        
        Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
        Vector3 NewWorldPos = mainCamera.ScreenToWorldPoint(ScreenPos);
        transform.position = NewWorldPos;
       
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }

    private void OnMouseExit()
    {
        shape.material.DOColor(Color.blue, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.UpArrow) && isSelected == true)
        {
            width += 0.1f;
            print("grow");
           
            gameObject.transform.localScale = new Vector3(width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isSelected == true)
        {

            width -= 0.1f;
            
            gameObject.transform.localScale = new Vector3(width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);


        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.localScale = new Vector3(0.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

       
    }
}
