using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.gameObject.SetActive(false);

    }
}
