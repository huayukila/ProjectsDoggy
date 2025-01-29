using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Barria : MonoBehaviour
{
    public PlayableDirector Director;

    public GameObject Block;

    public NavMeshAgent enemyNav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Director.Play();
            Block.SetActive(true);

            GetComponent<Collider>().enabled = false;
            enemyNav.Warp(Vector3.zero);
        }
    }
}