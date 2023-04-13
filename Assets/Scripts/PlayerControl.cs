using UnityEngine;



public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

    //Movement
    public float speed = 7.0f;
    private int desiredLane = 1;   //0:Left 1:middle 2:Right
    public float laneDistance = 3.0f;

    Vector3 moveVector;
    Vector3 targetPosition;

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
        targetPosition = transform.position.z * Vector3.forward;             // forward is for we always wanna go forward

        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        // calculate move delta
        moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        
    }

    private void FixedUpdate()
    {
        //Move the Player
        controller.Move(moveVector * Time.deltaTime);

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
