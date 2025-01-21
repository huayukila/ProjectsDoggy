using UnityEngine;

public class SwitchToMoonTrigger : MonoBehaviour
{
    public ToggleDayNight toggleDayNight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            toggleDayNight.SwitchToMoon();
            this.gameObject.SetActive(false);
            EventSystem.Send<EventSwitchToMoomTrigger>();
        }
    }
}
