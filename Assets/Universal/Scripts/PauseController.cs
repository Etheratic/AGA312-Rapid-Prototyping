
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool paused;
    
    void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }

    public void Paused()
    {
        paused = !paused;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
}
