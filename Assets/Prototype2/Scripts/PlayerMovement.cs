using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GameBehaviour
{
    public float moveSpeed = 1f;
    public GameObject bullet;
    public Transform bulletSpawn;
    public Rigidbody bulletRb;
    public int bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        

        //rotates the player to the direction of the camera
        transform.eulerAngles = Camera.main.transform.eulerAngles;
        //translates the input vectors into coordinates
        moveDirection = transform.TransformDirection(moveDirection);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        
    }
}
