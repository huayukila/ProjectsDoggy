using UnityEngine;
using UnityEngine.AI;


public class EnemyStateMachine : StateMachine
{
    public Transform[] walkPoints;
    protected override void Init()
    {
        AddState("EnemyWalk", new EnemyWalk());
        AddState("EnemyStand", new EnemyStand());
        AddState("Enemychase", new Enemychase());

        ChangeStateTo("EnemyWalk");
    }
}
