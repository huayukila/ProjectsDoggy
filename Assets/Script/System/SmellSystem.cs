using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:�����̃G�t�F�N�g�̊J����
    //TODO:���o����
    public List<GameObject> Smells = new List<GameObject>();
    private void OnEnable()
    {
        EventSystem.Register<PlayerSmellEvent>(e =>
        {
            PlayerSmell();
        }).UnregisterWhenGameObjectDestroyed(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //������k��
    public void PlayerSmell()
    {

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
