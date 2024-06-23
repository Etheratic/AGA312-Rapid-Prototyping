using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : GameBehaviour
{
    public TMP_Text waveCount;
    public TMP_Text dead;
    
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void YouDied()
    {
        dead.gameObject.SetActive(true);
        StartCoroutine(DeathMessage());
    }

    public void DisplayWaveCount(int _waveNumber)
    {
        waveCount.text = "wave: " + _waveNumber;
    }

   IEnumerator DeathMessage()
    {
        yield return new WaitForSeconds(1);
        dead.gameObject.SetActive(false);
        

   }
}
