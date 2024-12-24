using UnityEngine;

public class PlayerWalk : State
{
    public override void CameraUpdate()
    {

    }

    public override void LogicUpdate()
    {
        PlayerStateMachine sm = _stateMachine as PlayerStateMachine;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = sm.transform.forward;
        Vector3 right = sm.transform.right;

        sm._whiteBoard.moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;
        sm._whiteBoard.moveDirection *= sm._whiteBoard.moveSpeed;

        sm.cController.Move(sm._whiteBoard.moveDirection * Time.deltaTime);


        if (moveVertical == 0 && moveHorizontal == 0)
        {
            sm.ChangeStateTo("PlayerStand");
        }
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void PhysicUpdate()
    {

    }


}
