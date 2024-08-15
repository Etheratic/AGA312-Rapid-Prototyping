using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : GameBehaviour
{

    public Animator scytheAnimator;

    // Update is called once per frame
    void Update()
    {
     

        if (Input.mousePosition.x < Screen.width / 2f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("left");
            StartCoroutine(ScytheSwing());
        }

        if (Input.mousePosition.x > Screen.width / 2f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("right");
            StartCoroutine(ScytheRightSwing());
        }
    }

    IEnumerator ScytheSwing()
    {
        scytheAnimator.Play("Scythe");
        yield return new WaitForSeconds(.8f);
        scytheAnimator.Play("New State");

    }

    IEnumerator ScytheRightSwing()
    {
        scytheAnimator.Play("ScytheRight");
        yield return new WaitForSeconds(.8f);
        scytheAnimator.Play("New State");

    }
}
