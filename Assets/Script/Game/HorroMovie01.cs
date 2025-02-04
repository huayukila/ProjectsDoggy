using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class HorroMovie01 : MonoBehaviour
{
    public PlayableDirector Director;
    public Transform spawnPoint;
    public Transform endCamera;

    public Transform enemy;
    private Transform player;

    private Vector3 enemyStartPoint;
    private Quaternion enemyRotate;

    private void Start()
    {
        Director.stopped += Stop;
        enemyStartPoint = enemy.position;
        enemyRotate = enemy.rotation;

        EventSystem.Register<EventLoadCheckPoint>(e => { ReInit(); }).UnregisterWhenGameObjectDestroyed(gameObject);
    }

    public void ReInit()
    {
        enemy.GetComponent<NavMeshAgent>().Warp(enemyStartPoint);
        enemy.GetComponent<NavMeshAgent>().ResetPath();
        enemy.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    void Stop(PlayableDirector obj)
    {
        gameObject.SetActive(false);

        enemy.gameObject.SetActive(true);

        enemy.GetComponent<StateMachine>().ChangeStateTo("Run");
        player.transform.rotation = endCamera.transform.rotation;


        player.GetComponent<StateMachine>().enabled = true;
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            player.GetComponent<StateMachine>().enabled = false;
            player.transform.position = spawnPoint.position;
            Director.Play();
        }
    }
}