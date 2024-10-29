using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    //�L�����N�^�̏���ۑ�����p�e��
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
            Debug.Log("Animator�R���|�[�l���g���A�^�b�`���Ă��܂���A����Animator���K�v���Ȃ��Ȃ炱�̃��b�Z�[�W�𖳎����Ă�������");
        }

        Init();
    }

    /// <summary>
    /// �X�e�[�g�}�V���̃C�j�V����
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
    /// �X�e�[�g�ύX
    /// </summary>
    /// <param name="stateName">�ύX�������X�e�[�g</param>
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
            Debug.LogError(stateName + "�����݂��Ȃ��A���O���Ⴂ�܂����H");
        }
    }

    protected void AddState(string stateName, State state)
    {
        if (!_states.TryAdd(stateName, state))
        {
            Debug.LogError(stateName + "�͊��ɑ��݂��Ă��܂�");
        }
    }
}