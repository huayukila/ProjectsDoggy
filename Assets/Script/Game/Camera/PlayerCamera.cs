using DG.Tweening;
using Unity.Cinemachine;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    [Header("�R���g���[�����x")] public float LookSpeed = 4f; //�R���g���[�����x
    [Header("�}�E�X���x")] public float MouseSensitivity = 100f; //�}�E�X���x
    private float _rotationY = 0f;
    private float _rotationX = 0f;

    void Start()
    {
        //�}�E�X�����b�N
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //�}�E�X���擾
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        //�㉺����i�J���������㉺����j
        float lookVertical = Input.GetAxis("RigthStickVertical");

        _rotationY -= lookVertical * LookSpeed; //�R���g���[������
        _rotationY += mouseY; //�}�E�X����
        _rotationY = Mathf.Clamp(_rotationY, -60f, 60f);

        Camera.transform.localRotation = Quaternion.Euler(-_rotationY, 0f, 0f);

        //���E����i�v���C�������E����j
        float lookHorizontal = Input.GetAxis("RightStickHorizontal");

        _rotationX += lookHorizontal * LookSpeed; //�R���g���[������
        _rotationX += mouseX; //�}�E�X����

        Player.transform.localRotation = Quaternion.Euler(0, _rotationX - 90f, 0f);
    }
}