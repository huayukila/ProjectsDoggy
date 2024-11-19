using System.Collections.Generic;
using UnityEngine;

public class SmellSystem : MonoBehaviour
{
    //TODO:匂いのエフェクトの開閉制御
    //TODO:演出効果
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
    //匂いを嗅ぐ
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
