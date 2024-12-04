using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemychase : State
{
    Transform target;
    NavMeshAgent agent;
    float speed = 5.0f;
    public override void CameraUpdate()
    {
       
    }

    public override void LogicUpdate()
    {
        if (target == null) return;

        // プレイヤーに向かって移動
        agent.SetDestination(target.position);

        // プレイヤーが追いかけ範囲から離れた場合、通常の歩行モードに戻る
        float distance = Vector3.Distance(_stateMachine.transform.position, target.position);
        if (distance > 7.5f) // 追いかけ範囲を設定
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
            (_stateMachine as EnemyStateMachine).player = null;
        }
    }

    public override void OnEnter()
    {
        _stateMachine.Animator.Play("RUN");
        Debug.Log("EnemyChase");
        target = (_stateMachine as EnemyStateMachine).player; // プレイヤーの参照を取得
        agent = (_stateMachine as EnemyStateMachine).NavMeshAgent;
    }

    public override void OnExit()
    {
    }

    public override void PhysicUpdate()
    {
        
    }
}
