using UnityEngine;

public class RingScript : MonoBehaviour
{
    public AudioClip pickupSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //play pickup sound
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            //disable the object
            this.gameObject.SetActive(false);
        }
            
    }
}
