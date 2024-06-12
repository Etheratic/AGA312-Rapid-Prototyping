using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : GameBehaviour
{
    CanvasGroup cvg;

    private void Awake()
    {
        cvg = GetComponent<CanvasGroup>();
        cvg.alpha = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        FadeX.FadeCanvas(cvg, 0, 5);
    }

}
