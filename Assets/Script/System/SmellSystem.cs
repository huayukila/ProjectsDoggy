using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:�����̃G�t�F�N�g�̊J����
    [Header("�����̃G�t�F�N�g������")]
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
