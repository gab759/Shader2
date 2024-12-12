using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("TrabajoFinal");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}