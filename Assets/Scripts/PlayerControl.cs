using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] GameObject winScreen;

    //Movement
    public float speed = 15;                // Starting speed
    private int desiredLane = 1;            //0:Left 1:middle 2:Right
    private float laneDistance = 3.0f;

    Vector3 moveVector;
    Vector3 targetPosition;

    //Color
    private ColorCheckScript _colorCheckScript;
    public Color ringColor;


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
        moveVector.x = (targetPosition - transform.position).normalized.x * (speed/2);  // speed/2 is to prevent trembling, otherwise player trembles when going sides in high speeds                    
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

    // Joystick movement for mobile devices
    public void joystickLeft()
    {
        MoveLane(false);
    }

    public void joyStickRight()
    {
        MoveLane(true);
    }
  
    //Contact with objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))                                           // stop when reaching the finish line
        {
            Time.timeScale = 0;
            winScreen.SetActive(true); 
        }
 
        if (other.gameObject.CompareTag("RedRing") && gameObject.tag == "Player")             // change color when pass a ring
        {            
            ringColor = Color.red;                           
            _colorCheckScript.checkColor();                                                   // check if player enters wrong color        
        }

        if (other.gameObject.CompareTag("BlueRing") && gameObject.tag == "Player")
        {      
            ringColor = Color.blue;                         
            _colorCheckScript.checkColor();
        }

        if (other.gameObject.CompareTag("YellowRing") && gameObject.tag == "Player")
        {
            ringColor = Color.yellow;                          
            _colorCheckScript.checkColor();         
        }

    }


}
