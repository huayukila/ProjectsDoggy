using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;

    [Header("�R���g���[�����x")]
    public float LookSpeed = 4f;//�R���g���[�����x
    [Header("�}�E�X���x")]
    public float MouseSensitivity = 100f;//�}�E�X���x

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
        //�}�E�X����
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        //�㉺����i�J���������㉺����j
        float lookVertical = Input.GetAxis("RigthStickVertical");

        _rotationY -= lookVertical * LookSpeed;//�R���g���[������_�㉺
        _rotationY += mouseY;//�}�E�X����_�㉺
        _rotationY = Mathf.Clamp(_rotationY, -60f, 60f);

        Camera.transform.localRotation = Quaternion.Euler(-_rotationY, 0f, 0f);

        //���E����i�v���C�������E����j
        float lookHorizontal = Input.GetAxis("RightStickHorizontal");

        _rotationX += lookHorizontal * LookSpeed;//�R���g���[������_���E
        _rotationX += mouseX;//�}�E�X����_���E

        Player.transform.localRotation = Quaternion.Euler(0, _rotationX, 0f);
    }
}
