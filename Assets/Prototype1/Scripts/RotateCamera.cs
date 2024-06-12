using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : GameBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontalImput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalImput * rotationSpeed * Time.deltaTime);
    }
}
