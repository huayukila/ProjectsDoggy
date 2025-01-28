using UnityEngine;
using UnityEngine.AI;

public class RuinsEnemyStateMachine : StateMachine
{
    public Transform PlayerTrans;

    public float RunSpeed;

    public NavMeshAgent Agent;
    // Update is called once per frame
    protected override void Init()
    {
        AddState("Run", new EnemyRun());
        AddState("Catch",new Enemycatch());
        ChangeStateTo("Run");
    }

    private void OnDestroy()
    {
        PlayerTrans = null;
    }
}