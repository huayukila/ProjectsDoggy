using DG.Tweening;
using UnityEngine;

public class Gimiku : MonoBehaviour
{
    public Transform Door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.Register<EventOpenTheDoor>(e => { HandleOpenTheDoor(); })
            .UnregisterWhenGameObjectDestroyed(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            EventSystem.Send<EventOpenTheDoor>();
        }
    }

    void HandleOpenTheDoor()
    {
        Door.DOLocalMoveX(-118, 3f);
    }
}