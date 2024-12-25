using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpBall : MonoBehaviour
{
    private int _bollCnt;  // �{�[���̐����i�[����v���C�x�[�g�ϐ�
    public int BollCnt
    {
        get { return _bollCnt; }
        private set
        {
            _bollCnt = value;
            // �{�[���̐���4�𒴂����ꍇ�A4�ɐ�������
            if (_bollCnt > 4)
            {
                _bollCnt = 4;
            }
            // �{�[���̐���0�����̏ꍇ�A0�ɐ�������
            else if (_bollCnt < 0)
            {
                _bollCnt = 0;
            }
        }
    }

    public float PickupDistance = 1f;  // �s�b�N�A�b�v�̋���
    public LayerMask PickupLayer;  // �s�b�N�A�b�v�̑Ώۃ��C���[
    public List<Renderer> PlayerBalls = new List<Renderer>();

    private BallGimmick _ballGimmick;  // BallGimmick�N���X�̃C���X�^���X
    private Camera _mainCamera;  // ���C���J����

    // �{�[���̐��𑝂₷���\�b�h
    public void AddBollCnt()
    {
        BollCnt++;
        for (int i = 0; i < BollCnt; i++)
        {
            PlayerBalls[i].enabled = true;
        }

        Debug.Log(BollCnt.ToString());
    }

    // �{�[���̐������炷���\�b�h
    public void SubBollCnt()
    {
        PlayerBalls[BollCnt].enabled = false;
        BollCnt--;
        Debug.Log(BollCnt.ToString());
    }

    // �{�[���̐����N���A���郁�\�b�h
    public void ClearBollCnt()
    {
        BollCnt = 0;
        foreach (Renderer r in PlayerBalls)
        {
            r.enabled = false;
        }
    }

    void Start()
    {
        _mainCamera = Camera.main;  // ���C���J�����̎擾

        GameObject ob = GameObject.Find("BallGimmick");
        if (ob != null)
        {
            _ballGimmick = ob.GetComponent<BallGimmick>();
        }
        else
        {
            Debug.Log("BallGimmick_NotFound!");  // BallGimmick��������Ȃ��ꍇ�̃f�o�b�O���O
        }
    }

    private void Update()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);  // ���C�𐶐�
        RaycastHit hit;

        // ���C�L���X�g�����s
        if (Physics.Raycast(ray, out hit, PickupDistance, PickupLayer))
        {
            // �uA�{�^���v�܂��́uF�L�[�v�������ꂽ�ꍇ
            if (Input.GetButtonDown("AButton")
                || Input.GetKeyDown(KeyCode.F))
            {
                // ���������I�u�W�F�N�g���uOOO�v���C���[�̏ꍇ
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
                {
                    hit.collider.gameObject.SetActive(false);  // �I�u�W�F�N�g���A�N�e�B�u�ɂ���
                    AddBollCnt();  // �{�[���̐��𑝂₷
                }
                // ���������I�u�W�F�N�g���uBallGimmick�v���C���[�̏ꍇ
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("BallGimmick"))
                {
                    _ballGimmick.UpdateBallGimmick(BollCnt);  // BallGimmick�̍X�V
                    ClearBollCnt();  // �{�[���̐����N���A
                }
            }
        }

// #if UNITY_EDITOR
//         // �uO�L�[�v�������ꂽ�ꍇ
//         if (Input.GetKeyDown(KeyCode.O))
//         {
//             AddBollCnt();  // �{�[���̐��𑝂₷
//         }
//         // �uP�L�[�v�������ꂽ�ꍇ
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             _ballGimmick.UpdateBallGimmick(BollCnt);  // BallGimmick�̍X�V
//             ClearBollCnt();  // �{�[���̐����N���A
//             EventSystem.Send<EventOpenTheDoor>();  // �h�A���J���C�x���g�𑗐M
//         }
// #endif
    }

    void OnDrawGizmos()
    {
        if (_mainCamera != null)
        {
            Gizmos.color = Color.green;
            Vector3 rayOrigin = _mainCamera.transform.position;
            Vector3 rayDirection = _mainCamera.transform.forward * PickupDistance;
            Gizmos.DrawRay(rayOrigin, rayDirection);  // ���C���M�Y���ŕ`��
        }
    }

}
