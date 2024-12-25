using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpBall : MonoBehaviour
{
    private int _bollCnt;  // ボールの数を格納するプライベート変数
    public int BollCnt
    {
        get { return _bollCnt; }
        private set
        {
            _bollCnt = value;
            // ボールの数が4を超えた場合、4に制限する
            if (_bollCnt > 4)
            {
                _bollCnt = 4;
            }
            // ボールの数が0未満の場合、0に制限する
            else if (_bollCnt < 0)
            {
                _bollCnt = 0;
            }
        }
    }

    public float PickupDistance = 1f;  // ピックアップの距離
    public LayerMask PickupLayer;  // ピックアップの対象レイヤー
    public List<Renderer> PlayerBalls = new List<Renderer>();

    private BallGimmick _ballGimmick;  // BallGimmickクラスのインスタンス
    private Camera _mainCamera;  // メインカメラ

    // ボールの数を増やすメソッド
    public void AddBollCnt()
    {
        BollCnt++;
        for (int i = 0; i < BollCnt; i++)
        {
            PlayerBalls[i].enabled = true;
        }

        Debug.Log(BollCnt.ToString());
    }

    // ボールの数を減らすメソッド
    public void SubBollCnt()
    {
        PlayerBalls[BollCnt].enabled = false;
        BollCnt--;
        Debug.Log(BollCnt.ToString());
    }

    // ボールの数をクリアするメソッド
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
        _mainCamera = Camera.main;  // メインカメラの取得

        GameObject ob = GameObject.Find("BallGimmick");
        if (ob != null)
        {
            _ballGimmick = ob.GetComponent<BallGimmick>();
        }
        else
        {
            Debug.Log("BallGimmick_NotFound!");  // BallGimmickが見つからない場合のデバッグログ
        }
    }

    private void Update()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);  // レイを生成
        RaycastHit hit;

        // レイキャストを実行
        if (Physics.Raycast(ray, out hit, PickupDistance, PickupLayer))
        {
            // 「Aボタン」または「Fキー」が押された場合
            if (Input.GetButtonDown("AButton")
                || Input.GetKeyDown(KeyCode.F))
            {
                // 当たったオブジェクトが「OOO」レイヤーの場合
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
                {
                    hit.collider.gameObject.SetActive(false);  // オブジェクトを非アクティブにする
                    AddBollCnt();  // ボールの数を増やす
                }
                // 当たったオブジェクトが「BallGimmick」レイヤーの場合
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("BallGimmick"))
                {
                    _ballGimmick.UpdateBallGimmick(BollCnt);  // BallGimmickの更新
                    ClearBollCnt();  // ボールの数をクリア
                }
            }
        }

// #if UNITY_EDITOR
//         // 「Oキー」が押された場合
//         if (Input.GetKeyDown(KeyCode.O))
//         {
//             AddBollCnt();  // ボールの数を増やす
//         }
//         // 「Pキー」が押された場合
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             _ballGimmick.UpdateBallGimmick(BollCnt);  // BallGimmickの更新
//             ClearBollCnt();  // ボールの数をクリア
//             EventSystem.Send<EventOpenTheDoor>();  // ドアを開くイベントを送信
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
            Gizmos.DrawRay(rayOrigin, rayDirection);  // レイをギズモで描画
        }
    }

}
