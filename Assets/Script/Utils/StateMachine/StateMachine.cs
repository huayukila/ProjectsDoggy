using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachine : MonoBehaviour
{
    //キャラクタの情報を保存する用容器
    public class WhiteBoard
    {
        public Vector3 gravity = Vector3.zero;
        public Vector3 moveDirection = Vector3.zero;
        public float moveSpeed = 5f;
        
        //カメラ制御-------------------
        public float lookSpeed = 4f;
        public float rotationX = 0f;
        public float rotationY = 0f;
    }

    protected Dictionary<string, State> _states = new Dictionary<string, State>();

    protected State _currentState;

    public WhiteBoard _whiteBoard = new WhiteBoard();

    private Animator _animator;

    public Animator Animator => _animator;

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
   protected virtual void Update()
    {
        if (_currentState == null)
            return;
        _currentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        if (_currentState == null)
            return;
        _currentState.PhysicUpdate();
    }

    protected virtual void LateUpdate()
    {
        if (_currentState == null)
            return;
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
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

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
            return;
        }

        state.Init(this);
    }
}