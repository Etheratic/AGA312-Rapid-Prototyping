using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class LightingManager : MonoBehaviour
{
    //references
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;

    //Variables
    [SerializeField, Range(0, 24)] private float timeOfDay;
    public int dayCounter;
    
    public float timeSpeed = 1;

    private void Update()
    {
        if (preset == null)
            return;

        if(Application.isPlaying)
        {
            timeOfDay += Time.deltaTime * timeSpeed;
            timeOfDay %= 24; //clamp between 0 - 24
            UpdateLighting(timeOfDay / 24f);

            if (timeOfDay >= 23)
            {
                dayCounter += 1;
                
                
                timeOfDay = 0;
            }
        }
        //else
        //{
        //    UpdateLighting(timeOfDay / 24f);
        //}

       
    }

    //private void DayCounted()
    //{
    //    dayCounted = false;
    //}

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColour.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColour.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColour.Evaluate(timePercent);

            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0)); 
        }
    }


    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }

        }

        
    }


}
