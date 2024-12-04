using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemychase : State
{
    Transform target;
    NavMeshAgent agent;
    float speed = 5.0f;
    public override void CameraUpdate()
    {
       
    }

    public override void LogicUpdate()
    {
        if (target == null) return;

        // �v���C���[�Ɍ������Ĉړ�
        agent.SetDestination(target.position);

        // �v���C���[���ǂ������͈͂��痣�ꂽ�ꍇ�A�ʏ�̕��s���[�h�ɖ߂�
        float distance = Vector3.Distance(_stateMachine.transform.position, target.position);
        if (distance > 7.5f) // �ǂ������͈͂�ݒ�
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
            (_stateMachine as EnemyStateMachine).player = null;
        }
    }

    public override void OnEnter()
    {
        _stateMachine.Animator.Play("RUN");
        Debug.Log("EnemyChase");
        target = (_stateMachine as EnemyStateMachine).player; // �v���C���[�̎Q�Ƃ��擾
        agent = (_stateMachine as EnemyStateMachine).NavMeshAgent;
    }

    public override void OnExit()
    {
    }

    public override void PhysicUpdate()
    {
        
    }
}
