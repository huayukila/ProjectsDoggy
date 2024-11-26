using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    private float _lookSpeed = 4f;
    private float _rotationY = 0f;
    private float _rotationX = 0f;
   
    // Update is called once per frame
    void Update()
    {
        //上下制御（カメラだけ上下制御）
        float lookVertical = Input.GetAxis("RigthStickVertical");

        _rotationY -= lookVertical * _lookSpeed;
        _rotationY = Mathf.Clamp(_rotationY, -60f, 60f);

        Camera.transform.localRotation = Quaternion.Euler(-_rotationY, 0f, 0f);

        //左右制御（プレイヤが左右制御）
        float lookHorizontal = Input.GetAxis("RightStickHorizontal");

        _rotationX += lookHorizontal * _lookSpeed;

        Player.transform.localRotation = Quaternion.Euler(0, _rotationX, 0f);
    }
}
