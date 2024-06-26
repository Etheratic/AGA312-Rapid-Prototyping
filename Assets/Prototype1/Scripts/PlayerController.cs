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

    
    public GameObject powerUpIndicator;
    public float rPowerUpStrength = 50f;
    public float gPowerUpStrength = 50f;
    public float bPowerUpStrength = 50f;
    public GameObject mainCamera;
    public float explosionForce = 20f;

   
    public bool isRed;
    public bool isBlue;
    public bool isGreen;

    public int points = 0;

    UIManager uiManager;

    public int hitPoints = 3;
    public GameObject spawnPoint;

   



    

    


    

    // Start is called before the first frame update
    void Start()
    {

        rb = player.GetComponent<Rigidbody>();
        
        uiManager = GameObject.Find("UICanvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //apply force
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ChangeToWhite(0));
        }

        if (gameObject.transform.position.y < - 10)
        {
            hitPoints -= 1;
            Respawn();
        }

        if( hitPoints <= 0)
        {
            print("dead");
        }
       

        rb.AddForce(movement * speed, ForceMode.Force);

        mainCamera.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x , player.gameObject.transform.position.y + 10, player.gameObject.transform.position.z - 17);
        
    }

    public void UpdatePoints(int _bonus)
    {
        points = points + _bonus;
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Rgem"))
        {
            isRed = true;
            ColourChange();
            
            print("Red");
            
        }

        if (other.CompareTag("Bgem"))
        {
            isBlue = true;
            ColourChange();
            print("Blue");
           
        }

        if (other.CompareTag("Ggem"))
        {
            isGreen = true;
            ColourChange();
            print("Green");
           
        }

        //if (other.CompareTag("Wgem"))
        //{
        //    isRed = false; isBlue = false; isGreen = false;
        //    ColourChange();
        //    print("white");
        //}
    }

   

    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.CompareTag("Red") && isRed)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * rPowerUpStrength, ForceMode.Impulse);
           
        }

        if (collision.gameObject.CompareTag("Blue") && isBlue)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * bPowerUpStrength, ForceMode.Impulse);
            

        }

        if (collision.gameObject.CompareTag("Green") && isGreen)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * gPowerUpStrength, ForceMode.Impulse);
            
                       
        }


    } 

    public void ColourChange()
    {
        if (isRed == true && isBlue != true && isGreen != true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.red, moveTweenTime);
            
        }

        else if (isBlue == true && isGreen != true && isRed != true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.blue, moveTweenTime);
            
        }

        else if (isGreen == true && isRed != true && isBlue !=true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.green, moveTweenTime);
        }

        else if (isGreen ==true && isBlue ==true && isRed != true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.cyan, moveTweenTime);
            StartCoroutine(ChangeToWhite(5));
        }

        else if (isGreen == true && isRed == true != isBlue == true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.yellow, moveTweenTime);
            StartCoroutine(ChangeToWhite(5));

        }

        else if (isRed == true && isBlue == true != isGreen ==true)
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.magenta, moveTweenTime);
            StartCoroutine(ChangeToWhite(5));
        }

        else
        {
            gameObject.GetComponent<Renderer>().material.DOColor(Color.white, moveTweenTime);
        }

    }

    private IEnumerator ChangeToWhite(int _time)
    {
        yield return new WaitForSeconds(_time);
        gameObject.GetComponent<Renderer>().material.DOColor(Color.white, moveTweenTime);
        isRed = false; isBlue = false; isGreen = false;

    }

    public void Respawn()
    {
       
        gameObject.transform.position = spawnPoint.transform.position;
        uiManager.YouDied();
    }


}
