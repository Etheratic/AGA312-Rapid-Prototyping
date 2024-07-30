using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class move3D : GameBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public float width;
      

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
        width = gameObject.transform.localScale.x;
    }

   
    private void OnMouseDrag()
    {
        Vector3 ScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
        Vector3 NewWorldPos = mainCamera.ScreenToWorldPoint(ScreenPos);
        transform.position = NewWorldPos;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
