using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class SmellUIController : MonoBehaviour
{
    public Image Smell_UI;
    public float FillDuration = 1f;
    private bool IsSmelled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IniFillAmount();
    }
    private void IniFillAmount()
    {
        Smell_UI.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSmelled == false)
        {
            //“õ‚¢‚ðšk‚®ƒ{ƒ^ƒ“
            if (Input.GetButtonDown("SmellKey")||Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("StartSmell");
            }
            if (Input.GetButton("SmellKey") || Input.GetKey(KeyCode.F))
            {
                Smell_UI.DOFillAmount(1.2f, FillDuration);
                if (Smell_UI.fillAmount >= 0.99f)
                {
                    Smell_UI.DOKill();//DoTween‚ð’âŽ~
                    Smell_UI.fillAmount = 1f;//fillAmount‚ð–žƒ^ƒ“
                    EventSystem.Send<EventPlayerSmell>();
                    Debug.Log("Smell!");
                    IsSmelled = true;
                    IniFillAmount();
                }
            }

        }
        if (Input.GetButtonUp("SmellKey") || Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("SmellOver");
            Smell_UI.DOFillAmount(0f, FillDuration);
            IsSmelled = false;
        }

    }
}
