using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;    // player
    public Vector3 offset = new Vector3(0, 5.0f, -10f);

    private void Start()
    {
        transform.position = target.position + offset;
    }

    private void LateUpdate()
    {
        // camera's position according to the target
        Vector3 desiredPosition = target.position + offset;                      
        desiredPosition.x = 0;

        // Camera will chase the target
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}
