using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyManager : State
{
    public float patrolRange = 10f;    // 徘徊範囲
    public float waitTime = 3f;        // 目的地到着後の待機時間

    private NavMeshAgent agent;        // NavMeshAgentの参照
    private Vector3 startPosition;     // 初期位置を基準とする
    private float waitTimer;           // 待機タイマー

    public void Initialize(GameObject obj)
    {
        // 初期位置とNavMeshAgentの参照を取得
        startPosition = obj.transform.position;
        agent = obj.GetComponent<NavMeshAgent>();

        // 最初の目的地を設定
        SetNewDestination();
    }

    public override void OnEnter()
    {
        // 徘徊モードに入ったときの初期設定
        waitTimer = waitTime;
        SetNewDestination();
    }

    public override void LogicUpdate()
    {
        // エージェントが移動中なら処理をスキップ
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            return;

        // 到着後の待機時間を減少させる
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            // 待機時間が経過したら新しい目的地を設定
            SetNewDestination();
            waitTimer = waitTime; // タイマーをリセット
        }
    }

    public override void OnExit()
    {
        // 終了時の処理（必要に応じて追加）
    }

    public override void CameraUpdate()
    {
        // カメラに関する処理が必要であればここに追加
    }

    public override void PhysicUpdate()
    {
        // 物理演算が必要な処理があればここに追加
    }

    // 新しい目的地をランダムに設定
    private void SetNewDestination()
    {
        // 開始位置を基準にランダムな位置を計算
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += startPosition;

        // NavMesh上のポイントを取得
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position); // 目的地を設定
        }
    }
}

public class Enemy : MonoBehaviour
{
    public EnemyManager manager = new EnemyManager();
}
