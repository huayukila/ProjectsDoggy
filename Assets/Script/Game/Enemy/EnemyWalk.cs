using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : State
{
    int pointIndex = 0;
    Vector3 currentTargetPos;
    NavMeshAgent agent;
    float speed = 3.0f;

    public override void OnEnter()
    {
        _stateMachine.Animator.Play("WALKING");
        agent = (_stateMachine as EnemyStateMachine).NavMeshAgent;
        if ((_stateMachine as EnemyStateMachine).walkPoints.Length <= 0)
            return;
        currentTargetPos = (_stateMachine as EnemyStateMachine).walkPoints[pointIndex].position;
    }

    public override void LogicUpdate()
    {
        // プレイヤーが検出されている場合はChaseモードに移行
        if ((_stateMachine as EnemyStateMachine).playerInSight)
        {
            _stateMachine.ChangeStateTo("Enemychase");
            return;
        }

        if (Vector3.Distance(_stateMachine.transform.position, currentTargetPos) < 1f)
        {
            pointIndex++;
            pointIndex = pointIndex % (_stateMachine as EnemyStateMachine).walkPoints.Length;
            currentTargetPos = (_stateMachine as EnemyStateMachine).walkPoints[pointIndex].position;
            _stateMachine.ChangeStateTo("EnemyStand");
        }

        agent.SetDestination(currentTargetPos);
    }

    public override void OnExit()
    {
        // 終了時の処理（必要に応じて追加）
    }

    public override void CameraUpdate()
    {
        // カメラに関する処理が必要であればここに追加
    }

    public override void PhysicUpdate()
    {
        // 物理演算が必要な処理があればここに追加
    }
}