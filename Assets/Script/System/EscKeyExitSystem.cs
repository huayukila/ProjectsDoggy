using UnityEngine;

public class EscKeyExitSystem : MonoBehaviour
{
    public static EscKeyExitSystem Instance;
    private void Awake()
    {
        //インスタンスの設定
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public bool EscKeyExitSystem_On = true;

    void Update()
    {
        if (EscKeyExitSystem_On)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            }
        }
    }
}
