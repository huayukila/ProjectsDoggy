using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    CinemachineCamera _enemyCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy_Hit");
            EventSystem.Send<EventPlayerWasCaught>();//ìGÇÃÉAÉjÉÅÇí‚é~Ç∑ÇÈ

            other.GetComponent<CinemachineCamera>().enabled = true;
            _enemyCamera = other.GetComponent<CinemachineCamera>();


            StartCoroutine(PlayerReborn());
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                Debug.Log("Enemy_aaaaaaaa");
                //var camera = other.GetComponent<Camera>();

                //if (camera != null)
                //{
                //    EventSystem.Send<EventPlayerWasCaught>();//ìGÇÃÉAÉjÉÅÇí‚é~Ç∑ÇÈ

                //    camera.GetComponent<CinemachineCamera>().enabled = true;

                //    StartCoroutine(PlayerReborn());

                //    if (gameObject.activeSelf)
                //    {
                //        //gameObject.SetActive(false);
                //    }
                //}
                //else
                //{
                //    Debug.Log("CameraNotFound");
                //}
            }

        }
    }
    IEnumerator PlayerReborn()
    {
        while (true)
        {
            Debug.Log("PlayerReborn() is Start");
            yield return new WaitForSeconds(2f);
            EventSystem.Send<EventLoadCheckPoint>();
            yield return new WaitForSeconds(1.5f);
            _enemyCamera.enabled = false;
            yield break;
        }
    }
}
