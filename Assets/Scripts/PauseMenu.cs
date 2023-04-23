
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    public void resumeGame() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game Continues");
    }
}
