using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyManager : State
{
    public float patrolRange = 10f;    // �p�j�͈�
    public float waitTime = 3f;        // �ړI�n������̑ҋ@����

    private NavMeshAgent agent;        // NavMeshAgent�̎Q��
    private Vector3 startPosition;     // �����ʒu����Ƃ���
    private float waitTimer;           // �ҋ@�^�C�}�[

    public void Initialize(GameObject obj)
    {
        // �����ʒu��NavMeshAgent�̎Q�Ƃ��擾
        startPosition = obj.transform.position;
        agent = obj.GetComponent<NavMeshAgent>();

        // �ŏ��̖ړI�n��ݒ�
        SetNewDestination();
    }

    public override void OnEnter()
    {
        // �p�j���[�h�ɓ������Ƃ��̏����ݒ�
        waitTimer = waitTime;
        SetNewDestination();
    }

    public override void LogicUpdate()
    {
        // �G�[�W�F���g���ړ����Ȃ珈�����X�L�b�v
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            return;

        // ������̑ҋ@���Ԃ�����������
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            // �ҋ@���Ԃ��o�߂�����V�����ړI�n��ݒ�
            SetNewDestination();
            waitTimer = waitTime; // �^�C�}�[�����Z�b�g
        }
    }

    public override void OnExit()
    {
        // �I�����̏����i�K�v�ɉ����Ēǉ��j
    }

    public override void CameraUpdate()
    {
        // �J�����Ɋւ��鏈�����K�v�ł���΂����ɒǉ�
    }

    public override void PhysicUpdate()
    {
        // �������Z���K�v�ȏ���������΂����ɒǉ�
    }

    // �V�����ړI�n�������_���ɐݒ�
    private void SetNewDestination()
    {
        // �J�n�ʒu����Ƀ����_���Ȉʒu���v�Z
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += startPosition;

        // NavMesh��̃|�C���g���擾
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position); // �ړI�n��ݒ�
        }
    }
}

public class Enemy : MonoBehaviour
{
    public EnemyManager manager = new EnemyManager();
}
