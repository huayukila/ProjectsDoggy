using UnityEngine;
using UnityEngine.AI;


public class EnemyStateMachine : StateMachine
{
    public Transform[] walkPoints;
    public Transform player;       // プレイヤーのTransform（追跡対象）
    public bool playerInSight;     // プレイヤーが視界内かどうか
    public float ChaseDistance;

    private SphereCollider collider;
    protected override void Init()
    {
        collider = GetComponent<SphereCollider>();
        AddState("EnemyWalk", new EnemyWalk());
        AddState("EnemyStand", new EnemyStand());
        AddState("Enemychase", new Enemychase());

        ChangeStateTo("EnemyWalk");
    }

    bool TryCheckPlayerInSight()
    {
        if (player == null)
            return false;
        Vector3 enemyToPlayerVec = player.position- gameObject.transform.position;


        float angle = Vector3.Angle(transform.forward, enemyToPlayerVec);
        Debug.Log(angle);
        if (enemyToPlayerVec.magnitude < ChaseDistance || (angle < 30 && angle > -30))
            return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        if (collider == null)
            return;


        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, gameObject.transform.forward*5);
        Gizmos.DrawWireSphere(transform.position, collider.radius);

        Gizmos.color= Color.blue;
        Gizmos.DrawWireSphere(transform.position, ChaseDistance);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !playerInSight)
        {
            player = other.gameObject.transform;

            if (TryCheckPlayerInSight())
            {
                playerInSight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // プレイヤーがコライダー外に出た場合
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
            player = null;
        }
    }
}
