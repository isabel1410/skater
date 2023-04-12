using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneManager : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
