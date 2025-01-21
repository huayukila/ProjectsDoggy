using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EventSystem.Send<EventUpdateCheckPoint>();
        }
    }
}
