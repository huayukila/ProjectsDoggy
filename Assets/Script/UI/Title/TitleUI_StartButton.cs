using UnityEngine;

public class TitleUI_StartButton : MonoBehaviour
{
    public string GameStartSceneName;
    public void StartButton()
    {
        if (!string.IsNullOrEmpty(GameStartSceneName))
        {
            SceneSwitcher.Instance.Loading(1f, GameStartSceneName);
        }
    }
}
