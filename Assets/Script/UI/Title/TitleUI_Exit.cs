using UnityEngine;

public class TitleUI_Exit : MonoBehaviour
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
