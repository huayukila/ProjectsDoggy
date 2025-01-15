using UnityEngine;
using System.Collections;

public class PositionSwitcher : MonoBehaviour
{
    public static PositionSwitcher Instance;
    private void Awake()
    {
        //インスタンスの設定
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public FadeEvent _fadeEvent;
    public CharacterController PlayerCon;

    IEnumerator LoadPositionCoroutine(float _fadeDuration, Vector3 position)
    {
        while (true)
        {
            _fadeEvent.FadeIn(_fadeDuration);
            yield return new WaitForSeconds(_fadeDuration + 1f);

            PlayerCon.transform.position = position;

            yield return new WaitForSeconds(_fadeDuration + 1.5f);
            _fadeEvent.FadeOut(_fadeDuration + 0.2f);
            yield break;
        }
    }
    /// <summary>
    /// シーンをFadeInと共にプレイヤの位置を変更
    /// </summary>
    /// <param name="_fadeDuration">FadeIn変化スピード</param>
    /// <param name="position">指定する位置</param>
    public void Load(float _fadeDuration, Vector3 position)
    {
        if (PlayerCon != null)
        {
            StartCoroutine(LoadPositionCoroutine(_fadeDuration, position));
        }
    }
}
