using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
