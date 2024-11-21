using UnityEngine;
using UnityEngine.AI;

public class Enemychase : State
{
    Transform target;
    float speed = 5.0f;
    public override void CameraUpdate()
    {

    }

    public override void LogicUpdate()
    {
        if (target == null) return;

        // プレイヤーに向かって移動
        Vector3 dir = target.position - _stateMachine.transform.position;

        _stateMachine.transform.position += dir.normalized * Time.deltaTime * speed;

        // プレイヤーが追いかけ範囲から離れた場合、通常の歩行モードに戻る
        float distance = Vector3.Distance(_stateMachine.transform.position, target.position);
        if (distance > 7.5f) // 追いかけ範囲を設定
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("EnemyChase");
        target = (_stateMachine as EnemyStateMachine).player; // プレイヤーの参照を取得
    }

    public override void OnExit()
    {

    }

    public override void PhysicUpdate()
    {

    }
}
