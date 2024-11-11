using UnityEngine;

public class PlayerStand : State
{
    public override void CameraUpdate()
    {


    }

    public override void LogicUpdate()
    {
        PlayerStateMachine sm = _stateMachine as PlayerStateMachine;

        {
            float lookHorizontal = Input.GetAxis("RightStickHorizontal");
            float lookVertical = Input.GetAxis("RigthStickVertical");

            sm._whiteBoard.rotationX += lookHorizontal * sm._whiteBoard.lookSpeed;
            sm._whiteBoard.rotationY -= lookVertical * sm._whiteBoard.lookSpeed;
            sm._whiteBoard.rotationY = Mathf.Clamp(sm._whiteBoard.rotationY, -60f, 60f);

            sm.transform.localRotation = Quaternion.Euler(-sm._whiteBoard.rotationY, sm._whiteBoard.rotationX, 0f);
        }


        if (sm.inputController.isInput)
        {
            sm.ChangeStateTo("PlayerWalk");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("Stand");
        (_stateMachine as PlayerStateMachine)._whiteBoard._gravity.y = -9.8f;
    }

    public override void OnExit()
    {


    }

    public override void PhysicUpdate()
    {

    }

}
