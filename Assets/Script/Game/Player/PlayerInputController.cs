using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public bool isInput { get; private set; }


    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical == 0 && moveHorizontal == 0)
        {
            isInput = false;
        }
        else
        {
            isInput = true;
        }

        //������k���{�^��
        //TODO:UI����̏��ɏ���
        //if (Input.GetButtonDown("SmellKey"))
        //{
        //    EventSystem.Send<PlayerSmellEvent>();
        //    Debug.Log("Smell");
        //}
        //if (Input.GetButtonUp("SmellKey"))
        //{
        //    Debug.Log("SmellOver");
        //}
    }
}
