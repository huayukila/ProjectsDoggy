using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:�����̃G�t�F�N�g�̊J����
    [Header("�����̃G�t�F�N�g������")]
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
    //������k��
    public void PlayerSmell()
    {
        //TODO:���o����
        SmellEffectOn();
    }
    public void PlayerLostSmell()
    {
        //TODO:���o����
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
