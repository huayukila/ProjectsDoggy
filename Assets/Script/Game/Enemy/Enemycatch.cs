using UnityEngine;

public class Enemycatch : State
{
    public override void CameraUpdate()
    {
        
    }

    public override void LogicUpdate()
    {
        
    }

    public override void OnEnter()
    {
        _stateMachine.Animator.Play("IDOL2");
    }

    public override void OnExit()
    {
        
    }

    public override void PhysicUpdate()
    {
        
    }
}
