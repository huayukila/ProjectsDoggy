using DG.Tweening;
using UnityEngine;

public class EnemyJumpScare2 : MonoBehaviour
{
    public GameObject Enemy;

    private Animator _animator;

    private bool isPlayerEnter = false;

    private Animator enemyAnimator;

    private Transform Player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        enemyAnimator = Enemy.GetComponent<Animator>();
    }

    public void EnemyShow()
    {
        Enemy.SetActive(true);
    }

    public void EnemyHide()
    {
        Player = null;
        Enemy.transform.DOKill();
        Enemy.SetActive(false);
    }

    public void RunToPlayer()
    {
        enemyAnimator.Play("RUN");
        // Enemy.transform.DOLookAt(position, 0.1f);
        Enemy.transform.DOMove(Player.position, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerEnter)
            return;

        if (other.CompareTag("Player"))
        {
            Player = other.transform;
            Enemy.transform.LookAt(Player);
            _animator.Play("EnemyFlick");
            isPlayerEnter = true;
        }
    }
}