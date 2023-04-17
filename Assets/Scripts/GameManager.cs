using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private ColorCheckScript _colorCheckScript;

    public TextMeshProUGUI text;

    

    private void Start()
    {
        _colorCheckScript = player.GetComponent<ColorCheckScript>();
    }


    private void Update()
    {
        text.text = _colorCheckScript.ringCounter.ToString();
        
    }


}
