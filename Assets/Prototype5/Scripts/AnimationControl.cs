using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : GameBehaviour
{

    public Animator scytheAnimator;
    public bool ColliderActive;


   public void Start()
    {
        ColliderActive = false;
    }
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

        if(ColliderActive == true)
        {
            gameObject.GetComponent<Collider>().enabled = true;

        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator ScytheSwing()
    {
        scytheAnimator.Play("Scythe");
        ColliderActive = true;
        yield return new WaitForSeconds(.8f);
        scytheAnimator.Play("New State");
        ColliderActive = false;

    }

    IEnumerator ScytheRightSwing()
    {
        scytheAnimator.Play("ScytheRight");
        ColliderActive = true;
        yield return new WaitForSeconds(.8f);
        scytheAnimator.Play("New State");
        ColliderActive = false;

    }
}
