using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private PlayerControl _playerControlScript;

    private ColorCheckScript _colorCheckScript;

    public TextMeshProUGUI text;

    // speed management
    public float speedTrigger;                //  player's speed will increase after reaching this value. Will be a managable number
    public int speedCounter;                  // count as rings collected
    public int speedAmount;                   // how much will speed increase


    private void Start()
    {
        Application.targetFrameRate = 30;
        _colorCheckScript = player.GetComponent<ColorCheckScript>();
        _playerControlScript = player.GetComponent<PlayerControl>();       
    }


    private void Update()
    {
        //score UI
        text.text = _colorCheckScript.ringCounter.ToString();

    }

    public void increaseSpeed()
    {
        speedCounter++;

        if (speedCounter == speedTrigger)
        {
            _playerControlScript.speed = _playerControlScript.speed + speedAmount;
            speedCounter = 0;

        }
    }

    

}
