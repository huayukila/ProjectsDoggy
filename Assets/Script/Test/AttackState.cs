using UnityEngine;

public class AttackState: State
{
    public override void OnEnter()
    {
        Debug.Log("Ç±ÇøÇÁÇÕAttack");
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _stateMachine.ChangeStateTo("Default");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _stateMachine.ChangeStateTo("aaaa");
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
        Debug.Log("Attackëﬁèo");
    }
}
