using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuControl : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverScreen;

    
    public void restartGame()
    {
        SceneManager.LoadScene("Level-1");
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
