using UnityEngine;
using UnityEngine.AI;

public class Enemychase : State
{
    Transform target;
    NavMeshAgent agent;
    float speed = 8.0f;

    public override void CameraUpdate()
    {
    }

    public override void LogicUpdate()
    {
        // �v���C���[�Ɍ������Ĉړ�
        agent.SetDestination(target.position);
        // �v���C���[���ǂ������͈͂��痣�ꂽ�ꍇ�A�ʏ�̕��s���[�h�ɖ߂�
        float distance = Vector3.Distance(_stateMachine.transform.position, target.position);
        if (distance > 7.5f) // �ǂ������͈͂�ݒ�
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
        }
    }

    public override void OnEnter()
    {
        _stateMachine.Animator.Play("RUN");
        target = (_stateMachine as EnemyStateMachine).player; // �v���C���[�̎Q�Ƃ��擾
        agent = (_stateMachine as EnemyStateMachine).NavMeshAgent;
    }

    public override void OnExit()
    {
        Debug.Log("Exit");
    }

    public override void PhysicUpdate()
    {
    }
}