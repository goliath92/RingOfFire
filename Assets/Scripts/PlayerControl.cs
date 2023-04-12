
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

    public float forwardSpeed;
    private Vector3 direction;
    private Vector3 targetPosition;

    private int desiredLane = 1;                 // 0:Left 1:Middle 2:Right
    public float laneDistance = 4;               // distance between two lanes
    

    private ColorCheckScript _colorCheckScript;

    public Color ringColor;                                // ??????????????????????????????



    private void Start()
    {
        controller = GetComponent<CharacterController>();

        _colorCheckScript = GetComponent<ColorCheckScript>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)                      // to prevent going outside the bounder
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
            
        }

        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
            
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition, 80 * Time.fixedDeltaTime);
        
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))                    // stop when reaching the finish line
        {
          
            other.gameObject.SetActive(false);
        }
 
        if (other.gameObject.CompareTag("RedRing"))             // change color when pass a ring
        {
            
            ringColor = Color.red;                           // ??????????????????????????????
            _colorCheckScript.checkColor();                  // check if player enters wrong color
            
        }
        if (other.gameObject.CompareTag("BlueRing"))
        {      
            ringColor = Color.blue;                         // ??????????????????????????????
            _colorCheckScript.checkColor();
            
        }
        if (other.gameObject.CompareTag("YellowRing"))
        {
            ringColor = Color.yellow;                          // ??????????????????????????????
            _colorCheckScript.checkColor();
            
        }

    }


}
