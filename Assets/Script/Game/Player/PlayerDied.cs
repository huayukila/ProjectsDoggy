using Unity.Cinemachine;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                var camera = other.transform.Find("Camera");

                if (camera != null)
                {
                    camera.GetComponent<CinemachineCamera>().enabled = true;

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
}
