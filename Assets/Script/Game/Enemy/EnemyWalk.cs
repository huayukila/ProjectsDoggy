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
        // �v���C���[�����o����Ă���ꍇ��Chase���[�h�Ɉڍs
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
        // �I�����̏����i�K�v�ɉ����Ēǉ��j
    }

    public override void CameraUpdate()
    {
        // �J�����Ɋւ��鏈�����K�v�ł���΂����ɒǉ�
    }

    public override void PhysicUpdate()
    {
        // �������Z���K�v�ȏ���������΂����ɒǉ�
    }
}