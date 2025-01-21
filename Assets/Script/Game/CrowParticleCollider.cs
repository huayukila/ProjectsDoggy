using UnityEngine;

public class CrowParticleCollider : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private AudioSource _audioSource;
 
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

        GameObject ad = GameObject.Find("CrowAudioSource");
        if (ob != null)
        {
            _audioSource = ad.GetComponent<AudioSource>();
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
                _audioSource.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
