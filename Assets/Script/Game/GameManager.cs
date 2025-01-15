using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        //各Systemのイニシャル
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Title");
        EventSystem.Register<EventGameClear>(e => { SceneManager.LoadScene("Title"); });
        EventSystem.Register<EventGamePause>(e => { Time.timeScale = 0f; }).UnregisterWhenGameObjectDestroyed(gameObject);
        EventSystem.Register<EventGameResume>(e => { Time.timeScale = 1f; }).UnregisterWhenGameObjectDestroyed(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}