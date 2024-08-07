using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : GameBehaviour
{
    public float moveSpeed = 1f;
    
    public GameObject CameraA;
    public GameObject deathPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        


        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        

       
        //translates the input vectors into coordinates
        moveDirection = transform.TransformDirection(moveDirection);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

      

       

    }

    public void OnTriggerEnter(Collider other)
    {
        Die();
    }

    public void Die()
    {
        Time.timeScale = 0;
        Destroy(gameObject);
        deathPanel.SetActive(true);
    }
}
