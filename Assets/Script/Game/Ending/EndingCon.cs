using UnityEngine;

public class EndingCon : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("AButton")
                || Input.GetKeyDown(KeyCode.F))
        {
            SceneSwitcher.Instance.Loading(1.5f, "Title");
        }
    }
}
