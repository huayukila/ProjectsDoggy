using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneSwitcher.Instance.Loading(3f, "Ending");
            gameObject.SetActive(false);
        }
    }
}