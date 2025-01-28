using DG.Tweening;
using UnityEngine;

public class Gimiku : MonoBehaviour
{
    public Transform Door;
    public AudioSource OpenedAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.Register<EventOpenTheDoor>(e => { HandleOpenTheDoor(); })
            .UnregisterWhenGameObjectDestroyed(gameObject);
    }
    
    void HandleOpenTheDoor()
    {
        OpenedAudio.Play();
        var sequence = DOTween.Sequence();
        sequence.Append(
            Door.DOLocalMoveX(-118, 3f)
                .OnUpdate(() => {
                    
                    Door.localPosition += Random.insideUnitSphere * 0.03f;
                })
        ).OnComplete(() =>
        {
            OpenedAudio.Stop();
        });
    }
}