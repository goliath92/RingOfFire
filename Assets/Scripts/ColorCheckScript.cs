using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorCheckScript : MonoBehaviour
{
    private PlayerControl _playerControl;

    [SerializeField] private Color[] Colors;

    public Material playerColor;

    public int ringCounter = 0;
    
    private void Start()
    {
        _playerControl = GetComponent<PlayerControl>();      

        Colors = new[] {Color.red, Color.blue, Color.yellow};
        
        playerColor.color = Color.yellow;             // starting color
        
        _playerControl.ringColor = Color.yellow;      // a color for starting so it doesn't give any error
    }
    

    public void checkColor()                                    // check if player enters wrong color
    {
        if (playerColor.color != _playerControl.ringColor) 
        {
            StartCoroutine(WaitForDeath());            
        }

        else if (playerColor.color == _playerControl.ringColor)
        {
            ringCounter++;                                   // increase collected ring number
            StartCoroutine(collectTimer());
            StartCoroutine(WaitForColorChange());
        }                                                               
        
    }
    

    public void chooseRandomColor()
    {       
        playerColor.color = Colors[Random.Range(0, 3)];
        Debug.Log("New Color Assigned.");                  // Sometimes color doesn't change
    }

    private IEnumerator WaitForColorChange()               // without this coroutine, player changes color during the contact and dies either way
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

    private IEnumerator collectTimer()               // to prevent multiple ring collection at the same time
    {
        this.gameObject.tag = "idle";

        yield return new WaitForSeconds(0.2f);

        this.gameObject.tag = "Player";

    }
}
