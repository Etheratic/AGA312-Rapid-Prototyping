using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameBehaviour
{
   
    public GameObject player;
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 2f;


    public float moveTweenTime = 1f;
    public Ease moveEase;

    private bool hasPowerUp;
    public GameObject powerUpIndicator;
    public float powerUpStrength = 10f;

   
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
       

        rb.AddForce(movement * speed);
        

        
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
        }

        if (collision.gameObject.CompareTag("Blue") && isBlue)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Green") && isGreen)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }


    } 

    public void ColourChange()
    {
        if (isRed == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;

        }


        if (isBlue == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (isGreen == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    
    


}
