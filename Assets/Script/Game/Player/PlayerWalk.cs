using UnityEngine;
using UnityEngine.EventSystems;

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


        float lookHorizontal = Input.GetAxis("RightStickHorizontal");
        float lookVertical = Input.GetAxis("RigthStickVertical");

        sm._whiteBoard.rotationX += lookHorizontal * sm._whiteBoard.lookSpeed;
        sm._whiteBoard.rotationY -= lookVertical * sm._whiteBoard.lookSpeed;
        sm._whiteBoard.rotationY = Mathf.Clamp(sm._whiteBoard.rotationY, -60f, 60f);

        sm.transform.localRotation = Quaternion.Euler(-sm._whiteBoard.rotationY, sm._whiteBoard.rotationX, 0f);

        if (moveVertical == 0 || moveHorizontal == 0)
        {
            sm.ChangeStateTo("PlayerStand");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("Walk");
    }

    public override void OnExit()
    {
    }

    public override void PhysicUpdate()
    {

    }


}
