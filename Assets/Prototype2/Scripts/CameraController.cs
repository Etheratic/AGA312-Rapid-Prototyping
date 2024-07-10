using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float lookSensitivity = 15f; 
    void Update()
    {
        rotationX += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotationY += Input.GetAxis("Mouse X") * -1  * lookSensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
