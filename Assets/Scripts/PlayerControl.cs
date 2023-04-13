
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

    

    //Movement
    private float jumpForce = 4.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 7.0f;
    private int desiredLane = 1;   //0:Left 1:middle 2:Right
    public float laneDistance = 3.0f;

    //Color
    private ColorCheckScript _colorCheckScript;
    public Color ringColor;                                // ??????????????????????????????



    private void Start()
    {
        controller = GetComponent<CharacterController>();

        _colorCheckScript = GetComponent<ColorCheckScript>();

        
    }

    private void Update()
    {
        // gather the inputs on which lane we should be
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLane(false);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveLane(true);

        // Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;             // forward is for we always wanna go forward

        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        // calculate move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        //Move the Player
        controller.Move(moveVector * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       
        
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;              // ? is a short way for if else logic (if 1 else -1 in here)
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);

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
