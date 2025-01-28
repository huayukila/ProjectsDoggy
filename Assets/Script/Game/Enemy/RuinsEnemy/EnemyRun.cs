using UnityEngine;

public class EnemyRun : State
{
    public override void OnEnter()
    {
        _stateMachine.Animator.Play("RUN");
    }

    public override void LogicUpdate()
    {
        var position = ((RuinsEnemyStateMachine)_stateMachine) .PlayerTrans.position;
        (_stateMachine as RuinsEnemyStateMachine)?.Agent.SetDestination(position);
        float distance = Vector3.Distance(((RuinsEnemyStateMachine)_stateMachine).transform.position, position);
        if (distance < 1f) // ’Ç‚¢‚©‚¯”ÍˆÍ‚ðÝ’è
        {
            _stateMachine.ChangeStateTo("Catch");
        }
    }

    public override void PhysicUpdate()
    {
    }

    public override void CameraUpdate()
    {
    }

    public override void OnExit()
    {
    }
}