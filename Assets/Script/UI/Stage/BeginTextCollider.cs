using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeginTextCollider : MonoBehaviour
{
    public Image BeginningText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BeginningText.enabled = false;
        }
    }
}
