using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:匂いのエフェクトの開閉制御
    [Header("匂いのエフェクトを入れる")]
    public Transform SmellsRoot;
    private Transform[] smells;
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
    private void Start()
    {
        smells = SmellsRoot.GetComponentsInChildren<Transform>();
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
        foreach (Transform smell in smells)
        {           
            smell.gameObject.SetActive(true);
        }
    }
    private void SmellEffectOff()
    {
        foreach (Transform smell in SmellsRoot.GetComponentsInChildren<Transform>())
        {
            smell.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {        
            EventSystem.Send<EventPlayerLostSmell>();
        }
    }
}
