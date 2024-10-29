using UnityEngine;

public class DefaultState: State
{
    public override void OnEnter()
    {
        Debug.Log("Ç±ÇøÇÁÇÕDefault");
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _stateMachine.ChangeStateTo("Attack");
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
        Debug.Log("Defaultëﬁèo");
    }
}
