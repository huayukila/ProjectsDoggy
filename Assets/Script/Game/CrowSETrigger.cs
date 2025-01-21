using UnityEngine;

public class CrowSETrigger : MonoBehaviour
{
    public AudioSource crowAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            crowAudio.Play();
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
