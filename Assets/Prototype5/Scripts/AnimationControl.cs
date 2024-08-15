using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : GameBehaviour
{

    public Animator scytheAnimator;

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(ScytheSwing());
        }
    }

    IEnumerator ScytheSwing()
    {
        scytheAnimator.Play("Scythe");
        yield return new WaitForSeconds(.8f);
        scytheAnimator.Play("New State");

    }
}
