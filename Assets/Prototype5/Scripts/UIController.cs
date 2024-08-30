using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text harvestScore;
    public TMP_Text seedsText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCrop(int harvestscore)
    {
        harvestScore.text = "souls harvested: " + harvestscore;
    }

    public void UpdateSeed(int seedAmount)

    {
        seedsText.text = "souls to plant: " + seedAmount;
    }
}
