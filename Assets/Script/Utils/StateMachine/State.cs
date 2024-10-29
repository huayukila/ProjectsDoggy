public abstract class State
{
    protected StateMachine _stateMachine;

    /// <summary>
    /// �X�e�[�g���鎞��x�Ăяo���B�A�j���̕ύX�Ȃǂ͂�����ɏ����Ȃ���
    /// </summary>
    public abstract void OnEnter();
    
    /// <summary>
    /// �A���Ή�,Update
    /// </summary>
    public abstract void LogicUpdate();
    
    /// <summary>
    /// �������Z,FixedUpdate
    /// </summary>
    public abstract void PhysicUpdate();

    /// <summary>
    /// �J��������,LateUpdate
    /// </summary>
    public abstract void CameraUpdate();
    
    /// <summary>
    /// �X�e�[�g�ޏo��������x�Ăяo���A�v���C���[�̏��ύX�Ȃǂ̏����͂�����ɏ����Ȃ���
    /// </summary>
    public abstract void OnExit();
}