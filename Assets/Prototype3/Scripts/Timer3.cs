using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer3 : GameBehaviour

{
    private bool timerActive3;
    public float currentTime3;
    public TMP_Text timerText;
   

    // Start is called before the first frame update
    void Start()
    {
        currentTime3 = 0;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive3 == true)
        {
            currentTime3 = currentTime3 + Time.deltaTime;

        }
        timerText.text = currentTime3.ToString("F2");
    }

    void StartTimer()
    {
        timerActive3 = true;
    }

    public void StopTimer()
    {
        timerActive3 = false;
    }
}
