using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioClip normalClip;
    private AudioSource bgm;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgm.clip = normalClip;
        bgm.Play();
        
    }
    
}
