using UnityEngine;
using UnityEngine.Playables;

public class HorroMovie01 : MonoBehaviour
{
    public PlayableDirector Director;
    public Transform spawnPoint;
    public Transform enemy;
    private Transform player;

    private void Start()
    {
        Director.stopped += Stop;
    }

    void Stop(PlayableDirector obj)
    {
        gameObject.SetActive(false);

        enemy.gameObject.SetActive(true);
        player.transform.position = spawnPoint.position;
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            Director.Play();
        }
    }
}