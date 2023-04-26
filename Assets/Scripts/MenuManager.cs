using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    // Will disable quit button,because game will work on WebGL
    public void Quit() 
    {
        Application.Quit();
    }
}
