using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : GameBehaviour

{
    private bool timerActive;
    public float currentTime;
    public TMP_Text timerText;
   

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;

        }
        timerText.text = currentTime.ToString("F2");
    }

    void StartTimer()
    {
        timerActive = true;
    }

    void StopTimer()
    {
        timerActive = false;
    }
}
