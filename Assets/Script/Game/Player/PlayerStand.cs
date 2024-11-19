using UnityEngine;

public class PlayerStand : State
{
    public override void CameraUpdate()
    {


    }

    public override void LogicUpdate()
    {
        PlayerStateMachine sm = _stateMachine as PlayerStateMachine;

        if (sm.inputController.isInput)
        {
            sm.ChangeStateTo("PlayerWalk");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("Stand");
        (_stateMachine as PlayerStateMachine)._whiteBoard.gravity.y = -9.8f;
    }

    public override void OnExit()
    {


    }

    public override void PhysicUpdate()
    {

    }

}
