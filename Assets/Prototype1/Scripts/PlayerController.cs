using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameBehaviour
{
   
    public GameObject player;
    public Rigidbody rb;
    public float speed = 1f;
    public float jumpForce = 2f;


    public float moveTweenTime = 1f;
    public Ease moveEase;

    private bool hasPowerUp;
    public GameObject powerUpIndicator;
    public float powerUpStrength = 20f;
    public GameObject camera;

   
    public bool isRed;
    public bool isBlue;
    public bool isGreen;

    

    


    

    // Start is called before the first frame update
    void Start()
    {

        rb = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //apply force
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        ;
       

        rb.AddForce(movement * speed, ForceMode.Force);

        camera.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x , player.gameObject.transform.position.y + 10, player.gameObject.transform.position.z - 17);
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Rgem"))
        {
            isRed = true; isBlue = false; isGreen = false;
            ColourChange();
            
            print("Red");
            
        }

        if (other.CompareTag("Bgem"))
        {
            isRed = false; isBlue = true; isGreen = false;
            ColourChange();
            print("Blue");
           
        }

        if (other.CompareTag("Ggem"))
        {
            isRed = false; isBlue = false; isGreen = true;
            ColourChange();
            print("Green");
           
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.CompareTag("Red") && isRed)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            enemyRigidbody.AddForce(0, 20, 0);
            print("working");

        }

        if (collision.gameObject.CompareTag("Blue") && isBlue)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            enemyRigidbody.AddForce(0, 20, 0);

        }

        if (collision.gameObject.CompareTag("Green") && isGreen)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position + transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            enemyRigidbody.AddForce(0, 20, 0);
            
            
        }


    } 

    public void ColourChange()
    {
        if (isRed == true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.red, moveTweenTime);

        }


        if (isBlue == true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.blue, moveTweenTime);
        }

        if (isGreen == true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.green, moveTweenTime);
        }
    }
    
    


}
