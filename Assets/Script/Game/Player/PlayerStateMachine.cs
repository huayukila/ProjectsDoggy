using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public CharacterController cController;
    public PlayerInputController inputController;
    public AudioSource playerWalkingAudio;
    protected override void Init()
    {
        AddState("PlayerStand", new PlayerStand());
        AddState("PlayerWalk", new PlayerWalk());
        ChangeStateTo("PlayerStand");
    }

    protected override void Update()
    {
        base.Update();
        cController.Move(_whiteBoard.gravity * Time.deltaTime);
    }
}
