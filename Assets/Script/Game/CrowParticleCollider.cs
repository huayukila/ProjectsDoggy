using UnityEngine;

public class CrowParticleCollider : MonoBehaviour
{
    private ParticleSystem _particleSystem;
 
    void Start()
    {
        GameObject ob = GameObject.Find("CrowParticleSystem");
        if (ob != null)
        {
            _particleSystem = ob.GetComponent<ParticleSystem>();
        }
        else
        {
            Debug.Log("CrowParticleSystem_NotFound!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_particleSystem != null)
            {
                _particleSystem.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
