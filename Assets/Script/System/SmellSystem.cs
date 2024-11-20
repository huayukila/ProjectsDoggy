using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:匂いのエフェクトの開閉制御
    [Header("匂いのエフェクトを入れる")]
    public List<GameObject> Smells = new List<GameObject>();
    private void OnEnable()
    {
        EventSystem.Register<EventPlayerSmell>(e =>
        {
            PlayerSmell();
        }).UnregisterWhenGameObjectDestroyed(gameObject);

        EventSystem.Register<EventPlayerLostSmell>(e =>
        {
            PlayerLostSmell();
        }).UnregisterWhenGameObjectDestroyed(gameObject);
    }
    
    //匂いを嗅ぐ
    public void PlayerSmell()
    {
        //TODO:演出効果
        SmellEffectOn();
    }
    public void PlayerLostSmell()
    {
        //TODO:演出効果
        SmellEffectOff();
    }
    private void SmellEffectOn()
    {
        foreach(GameObject smell in Smells)
        {
            smell.SetActive(true);
        }
    }
    private void SmellEffectOff()
    {
        foreach (GameObject smell in Smells)
        {
            smell.SetActive(false);
        }
    }
}
