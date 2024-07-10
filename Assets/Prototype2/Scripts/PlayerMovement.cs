using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GameBehaviour
{
    public float moveSpeed = 1f;
    public GameObject bullet;
    public Transform bulletSpawn;
    public Rigidbody bulletRb;
    public int bulletForce = 30;
    public GameObject CameraA;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;



        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        

       
        //translates the input vectors into coordinates
        moveDirection = transform.TransformDirection(moveDirection);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

      

       

    }

    public void Shoot()
    {
        
        Vector3 mousePos = Input.mousePosition;
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
