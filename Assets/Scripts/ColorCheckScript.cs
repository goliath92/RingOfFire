using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorCheckScript : MonoBehaviour
{
    private PlayerControl _playerControl;

    public GameObject gameManager;
    private GameManager _gameManager;

    [SerializeField] private Color[] Colors;

    public Material playerColor;

    public int ringCounter = 0;
    
    
    private void Start()
    {
        _playerControl = GetComponent<PlayerControl>();

        _gameManager = gameManager.GetComponent<GameManager>();

        Colors = new[] {Color.red, Color.blue, Color.yellow};

        // starting color
        playerColor.color = Color.yellow;             

        // a color for starting so it doesn't give any error
        _playerControl.ringColor = Color.yellow;      
    }


    
    public void checkColor()                                 // check if player enters wrong color              
    {
        if (playerColor.color != _playerControl.ringColor) 
        {
            StartCoroutine(WaitForDeath());            
        }

        else if (playerColor.color == _playerControl.ringColor)
        {
            // ring counter
            ringCounter++;

            //increase speed after collecting some rings.
            _gameManager.increaseSpeed();

            // to prevent multiple ring collection at the same time
            StartCoroutine(collectTimer());

            // without this coroutine, player changes color during the contact (correct color) and dies
            StartCoroutine(WaitForColorChange());
        }                                                                   
    }
    
    public void chooseRandomColor()
    {       
        playerColor.color = Colors[Random.Range(0, 3)];
        Debug.Log("New Color Assigned.");                  
    }

    private IEnumerator WaitForColorChange()
    {
        
        yield return new WaitForSeconds(0.1f);

        chooseRandomColor();
    }

    private IEnumerator WaitForDeath()
    {
        Debug.Log("Player Died.");
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        
    }

    private IEnumerator collectTimer()
    {
        this.gameObject.tag = "idle";

        yield return new WaitForSeconds(0.2f);

        this.gameObject.tag = "Player";

    }
}
