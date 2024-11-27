using UnityEngine;

public class TitleUI_ExitButton : MonoBehaviour
{
    public void ExitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
