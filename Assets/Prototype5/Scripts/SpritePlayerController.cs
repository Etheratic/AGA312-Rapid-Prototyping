using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject reset;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirectionX = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        moveDirectionX = transform.TransformDirection(moveDirectionX);

        transform.position += moveDirectionX * moveSpeed * Time.deltaTime;


        Vector3 moveDirectionZ = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        moveDirectionZ = transform.TransformDirection(moveDirectionZ);

        transform.position += moveDirectionZ * moveSpeed * Time.deltaTime;
    }

   
}
