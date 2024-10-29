using UnityEngine;

public class TestSM : StateMachine
{
    protected override void Init()
    {
        AddState("Default", new DefaultState());
        AddState("Attack", new AttackState());

        ChangeStateTo("Default");
    }
}