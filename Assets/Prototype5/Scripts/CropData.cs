using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Crop Data", menuName = "New Crop Data")]
public class CropData : ScriptableObject
{
    public int daysToGrow;
    public GameObject[] GrowProgress;
    public GameObject readyToHarvest;
}
