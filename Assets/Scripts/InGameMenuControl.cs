using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuControl : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverScreen;

    
    public void restartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
