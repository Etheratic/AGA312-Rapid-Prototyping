using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    public float speed = 3;
    private Rigidbody enemyRb;
    private GameObject player;
    public int points;
    UIManager uiManager;
    PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
       
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    } 
    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            playerController.UpdatePoints(1);
            
           
        }

        

    }
}
