using DG.Tweening;
using Unity.Cinemachine;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    [Header("コントローラ感度")] public float LookSpeed = 4f; //コントローラ感度
    [Header("マウス感度")] public float MouseSensitivity = 100f; //マウス感度
    private float _rotationY = 0f;
    private float _rotationX = 0f;

    void Start()
    {
        //マウスをロック
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //マウスを取得
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        //上下制御（カメラだけ上下制御）
        float lookVertical = Input.GetAxis("RigthStickVertical");

        _rotationY -= lookVertical * LookSpeed; //コントローラ制御
        _rotationY += mouseY; //マウス制御
        _rotationY = Mathf.Clamp(_rotationY, -60f, 60f);

        Camera.transform.localRotation = Quaternion.Euler(-_rotationY, 0f, 0f);

        //左右制御（プレイヤが左右制御）
        float lookHorizontal = Input.GetAxis("RightStickHorizontal");

        _rotationX += lookHorizontal * LookSpeed; //コントローラ制御
        _rotationX += mouseX; //マウス制御

        Player.transform.localRotation = Quaternion.Euler(0, _rotationX - 90f, 0f);
    }
}