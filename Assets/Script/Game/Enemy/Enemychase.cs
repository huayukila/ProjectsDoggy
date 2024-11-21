using UnityEngine;
using UnityEngine.AI;

public class Enemychase : State
{
    Transform target;
    float speed = 5.0f;
    public override void CameraUpdate()
    {

    }

    public override void LogicUpdate()
    {
        if (target == null) return;

        // �v���C���[�Ɍ������Ĉړ�
        Vector3 dir = target.position - _stateMachine.transform.position;

        _stateMachine.transform.position += dir.normalized * Time.deltaTime * speed;

        // �v���C���[���ǂ������͈͂��痣�ꂽ�ꍇ�A�ʏ�̕��s���[�h�ɖ߂�
        float distance = Vector3.Distance(_stateMachine.transform.position, target.position);
        if (distance > 7.5f) // �ǂ������͈͂�ݒ�
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("EnemyChase");
        target = (_stateMachine as EnemyStateMachine).player; // �v���C���[�̎Q�Ƃ��擾
    }

    public override void OnExit()
    {

    }

    public override void PhysicUpdate()
    {

    }
}
