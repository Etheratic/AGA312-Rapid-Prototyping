
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string _sceneName) => SceneManager.LoadScene(_sceneName);
    public void ReloadScene() => LoadScene(SceneManager.GetActiveScene().name);
    public void LoadTitleScene() => LoadScene("TitleScene");
    public void Quit() => Application.Quit();
    


}
