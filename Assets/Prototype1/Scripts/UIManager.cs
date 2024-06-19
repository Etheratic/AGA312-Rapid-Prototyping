using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : GameBehaviour
{
    public TMP_Text waveCount;
    
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayWaveCount(int _waveNumber)
    {
        waveCount.text = "wave: " + _waveNumber;
    }
}
