using Unity.VisualScripting;
using UnityEngine;

public class EnemyJumpScare1 : MonoBehaviour
{
    public Transform enemy;
    public float speed;
    public float durationTime;


    private float currentTime;
    private bool isStart;
    private void Awake()
    {
        enemy.gameObject.SetActive(false);
    }

    public void Jump()
    {
        isStart = true;
        enemy.gameObject.SetActive(isStart);
    }


    private void Update()
    {
        if (!isStart) return;

        currentTime += Time.deltaTime;
        enemy.transform.position += enemy.forward * speed * Time.deltaTime;
        if (currentTime > durationTime)
        {
            enemy.gameObject.SetActive(false);
            currentTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Jump();
        }
    }
}