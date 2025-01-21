using UnityEngine;

public class BGM_Controller : MonoBehaviour
{
    public AudioSource BGM_Daytime;
    public AudioSource[] BGM_Night;
    private void OnEnable()
    {
        EventSystem.Register<EventSwitchToMoomTrigger>(e =>
        {
            BGM_Daytime.Stop();
            foreach (var item in BGM_Night)
            {
                item.Play();
            }
        }).UnregisterWhenGameObjectDestroyed(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
