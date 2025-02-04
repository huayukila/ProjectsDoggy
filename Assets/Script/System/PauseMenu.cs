using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject GameObject_PauseMenu;

    public CharacterController PlayerCon;

    private Vector3 _checkPointPosition = default;

    //private bool _isPauseMenuON = false;

    private void Awake()
    {
        EventSystem.Register<EventUpdateCheckPoint>(e =>
        {
            UpdateCheckPointPosition();
        }).UnregisterWhenGameObjectDestroyed(gameObject);

        EventSystem.Register<EventLoadCheckPoint>(e =>
        {
            PositionSwitcher.Instance.Load(1f, _checkPointPosition); ;
        }).UnregisterWhenGameObjectDestroyed(gameObject);
    }

    void Start()
    {
        EventSystem.Send<EventUpdateCheckPoint>();//èâä˙âª
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PauseMenu") || Input.GetKeyDown(KeyCode.P))
        {
            if (GameObject_PauseMenu.gameObject.activeSelf == false)
            {
                EventSystem.Send<EventGamePause>();
                GameObject_PauseMenu.SetActive(true);
            }
            else
            {
                ResumeButton();
            }
        }
        if (Input.GetButtonDown("AButton") && GameObject_PauseMenu.gameObject.activeSelf == true)
        {
            ResumeButton();
        }
    }
    public void UpdateCheckPointPosition()
    {
        if (PlayerCon != null)
        {
            _checkPointPosition = PlayerCon.transform.position;
            Debug.Log("UpdateCheckPoint");
        }
    }
    public void ResumeButton()
    {
        EventSystem.Send<EventGameResume>();
        GameObject_PauseMenu.SetActive(false);
    }
    public void LoadCheckPointButton()
    {
        ResumeButton();
        EventSystem.Send<EventLoadCheckPoint>();
    }
    public void TitleButton()
    {
        ResumeButton();
        SceneSwitcher.Instance.Loading(1f, "Title");
    }
    public void ExitButton()
    {
        ResumeButton();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
