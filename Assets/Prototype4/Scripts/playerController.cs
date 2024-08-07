using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerController : GameBehaviour
{
    public bool timeFreeze;
    public GameObject winText;
    public GameObject spawn;
    public int points;
    public TMP_Text scoreText;
    public GameObject pointObject;
    

    // Start is called before the first frame update
    void Start()
    {
        timeFreeze = true;
        winText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "points: " + points;

        if (timeFreeze == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

     if(Input.GetKeyDown(KeyCode.Space))
        {
            timeFreeze = !timeFreeze;

        }


     if(gameObject.transform.position.y <= -10)
        {
            gameObject.transform.position = spawn.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            
            
            _EFFECTS.TweenVignetteInOut(0.5f, 0.5f);
            
          
           
        }
    }


    public void EndGame()
    {
        timeFreeze = true;
        winText.SetActive(true);
  
        
      
       
    }

    public void AddPoint()
    {
        points += 1;
        

    }

   

}
