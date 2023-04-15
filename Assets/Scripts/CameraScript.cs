using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;    // player
    public Vector3 offset;
    Vector3 newPosition;

    public int distance;        // to change camera distance

    private void Start()
    {
        offset = transform.position - target.position;
        Debug.Log("Game started.");
    }


    // Fixed update is better option here, otherwise (in laterUpdate) object trembles
    private void FixedUpdate()
    {
        // future camera point.
        // i've added distance var to change camera distance
        newPosition = new Vector3(transform.position.x, transform.position.y,target.position.z + offset.z + distance);
        
        // camera movement
        transform.position = Vector3.Lerp(transform.position, newPosition, 10*Time.deltaTime);     
    }
}
