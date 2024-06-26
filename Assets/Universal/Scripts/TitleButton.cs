
using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    public Sprite mySplashImage;
    public Image splashImage;

    public void OnMouseEnter()
    {
        splashImage.enabled = true;
        splashImage.sprite = mySplashImage; 
    }

    public void OnMouseExit()
    {
        splashImage.enabled = false;
    }
}
