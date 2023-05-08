using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    public void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
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
