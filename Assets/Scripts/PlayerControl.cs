
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class PlayerControl : MonoBehaviour
{
    private ColorCheckScript _colorCheckScript;
    
    private Rigidbody rb;
    
    public float playerSpeed = 10;
    
    public float rotateSpeed = 2;
    
    private float HorizontalValue;
    
    public Color ringColor;

    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        _colorCheckScript = GetComponent<ColorCheckScript>();
    }

    private void Update()
    {
        HorizontalValue = Input.GetAxis("Horizontal");           // keyboard input
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(HorizontalValue * rotateSpeed, 0, 1) * playerSpeed);                 // player movement
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))                    // stop when reaching the finish line
        {
            playerSpeed = 0;
            rotateSpeed = 0;
            other.gameObject.SetActive(false);
        }
 
        if (other.gameObject.CompareTag("RedRing"))             // change color when pass a ring
        {
            
            ringColor = Color.red;                           // to compare player's and rings colors
            _colorCheckScript.checkColor();                  // check if player enters wrong color
            
        }
        if (other.gameObject.CompareTag("BlueRing"))
        {      
            ringColor = Color.blue;
            _colorCheckScript.checkColor();
            
        }
        if (other.gameObject.CompareTag("YellowRing"))
        {
            ringColor = Color.yellow;
            _colorCheckScript.checkColor();
            
        }

    }


}
