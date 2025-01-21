using DG.Tweening;
using UnityEngine;

public class EnemyJumpScare2 : MonoBehaviour
{
    public GameObject Enemy;

    private Animator _animator;

    private bool isPlayerEnter = false;

    private Animator enemyAnimator;

    private Transform Player;

    private AudioSource enemyAudio;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        enemyAnimator = Enemy.GetComponent<Animator>();
        enemyAudio = Enemy.GetComponent<AudioSource>();
    }

    public void EnemyShow()
    {
        Enemy.SetActive(true);
    }

    public void EnemyHide()
    {
        Enemy.SetActive(false);
    }

    public void KillAndHide()
    {
        Enemy.transform.DOKill();
        EnemyHide();
    }

    public void RunToPlayer()
    {
        enemyAnimator.Play("Crawl");
        enemyAudio.Play();
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

    public void ClearPlayerTrans()
    {
        Player = null;
    }
}