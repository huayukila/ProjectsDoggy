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
        HandleOpenTheDoor();
    }
    
    void HandleOpenTheDoor()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(
            Door.DOLocalMoveX(-118, 3f)
                .OnUpdate(() => {
                    
                    Door.localPosition += Random.insideUnitSphere * 0.03f;
                })
        );
    }
}