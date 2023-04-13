using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorCheckScript : MonoBehaviour
{
    private PlayerControl _playerControl;
    
    [SerializeField] private Color[] Colors ;

    public Material playerColor;

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
            StartCoroutine(WaitForColorChange());
        }
        
    }
    

    public void chooseRandomColor()
    {
        playerColor.color = Colors[Random.Range(0, 3)];
    }

    private IEnumerator WaitForColorChange()
    {
        
        yield return new WaitForSeconds(0.1f);

        chooseRandomColor();
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
