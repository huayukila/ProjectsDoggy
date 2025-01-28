using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                var camera = other.transform.Find("Camera");

                if (camera != null)
                {
                    EventSystem.Send<EventPlayerWasCaught>();//ìGÇÃÉAÉjÉÅÇí‚é~Ç∑ÇÈ

                    camera.GetComponent<CinemachineCamera>().enabled = true;

                    StartCoroutine(PlayerReborn());

                    if (gameObject.activeSelf)
                    {
                        //gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("CameraNotFound");
                }
            }

        }
    }
    IEnumerator PlayerReborn()
    {
        while (true)
        {
            Debug.Log("PlayerReborn() is Start");
            yield return new WaitForSeconds(2);
            EventSystem.Send<EventLoadCheckPoint>();
            yield break;
        }
    }
}
