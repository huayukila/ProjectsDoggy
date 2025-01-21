using UnityEngine;

public class ToggleDayNight : MonoBehaviour
{
    public Light sunLight;
    public Light moonLight;
    public float transitionDuration = 2f;  // 
    public KeyCode toggleKey = KeyCode.T;  // 
    public AudioSource changeToNightAudioSource;//��ɓ]������Ƃ��̉���

    private bool isDay = true;
    private float transitionProgress = 0f;
    private bool isTransitioning = false;

    void Start()
    {
        if (sunLight == null || moonLight == null)
        {
            Debug.LogError("SunLight �� MoonLight ��ݒu���Ă�������");
        }

        // �������̋���
        sunLight.intensity = 100000f;
        moonLight.intensity = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            SwitchToMoon();         
        }

        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime / transitionDuration;
            if (transitionProgress >= 1f)
            {
                transitionProgress = 1f;
                isTransitioning = false;
            }

            // ���̋�����ݒu
            float sunTargetIntensity = isDay ? 100000f : 0f;
            float moonTargetIntensity = isDay ? 0f : 0.2f;

            sunLight.intensity = Mathf.Lerp(sunLight.intensity, sunTargetIntensity, transitionProgress);
            moonLight.intensity = Mathf.Lerp(moonLight.intensity, moonTargetIntensity, transitionProgress);
        }
    }

    public void SwitchToMoon()
    {
        if (!isTransitioning)
        {
            changeToNightAudioSource.Play();
            isDay = !isDay;
            isTransitioning = true;
            transitionProgress = 0f;

        }
    }
}
