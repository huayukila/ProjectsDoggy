using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    //キャラクタの情報を保存する用容器
    protected class WhiteBoard
    {
    }

    protected Dictionary<string, State> _states = new Dictionary<string, State>();

    protected State _currentState;

    protected WhiteBoard _whiteBoard = new WhiteBoard();

    protected Animator _animator;

    void Awake()
    {
        if (TryGetComponent<Animator>(out Animator animator))
        {
            _animator = animator;
        }
        else
        {
            Debug.Log("Animatorコンポーネントがアタッチしていません、もしAnimatorが必要がないならこのメッセージを無視してください");
        }

        Init();
    }

    /// <summary>
    /// ステートマシンのイニシャル
    /// </summary>
    protected abstract void Init();

    // Update is called once per frame
    void Update()
    {
        _currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _currentState.PhysicUpdate();
    }

    private void LateUpdate()
    {
        _currentState.CameraUpdate();
    }

    /// <summary>
    /// ステート変更
    /// </summary>
    /// <param name="stateName">変更したいステート</param>
    public void ChangeStateTo(string stateName)
    {
        if (_states.TryGetValue(stateName, out State targetState))
        {
            _currentState.OnExit();
            _currentState = targetState;
            _currentState.OnEnter();
        }
        else
        {
            Debug.LogError(stateName + "が存在しない、名前が違いますか？");
        }
    }

    protected void AddState(string stateName, State state)
    {
        if (!_states.TryAdd(stateName, state))
        {
            Debug.LogError(stateName + "は既に存在しています");
        }
    }
}