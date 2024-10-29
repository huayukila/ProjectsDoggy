public abstract class State
{
    protected StateMachine _stateMachine;

    /// <summary>
    /// ステート入る時一度呼び出し。アニメの変更などはこちらに書きなさい
    /// </summary>
    public abstract void OnEnter();
    
    /// <summary>
    /// 輸入対応,Update
    /// </summary>
    public abstract void LogicUpdate();
    
    /// <summary>
    /// 物理演算,FixedUpdate
    /// </summary>
    public abstract void PhysicUpdate();

    /// <summary>
    /// カメラ制御,LateUpdate
    /// </summary>
    public abstract void CameraUpdate();
    
    /// <summary>
    /// ステート退出した時一度呼び出し、プレイヤーの情報変更などの処理はこちらに書きなさい
    /// </summary>
    public abstract void OnExit();
}