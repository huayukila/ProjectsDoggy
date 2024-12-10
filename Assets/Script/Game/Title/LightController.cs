using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private float _flashTime = 0.1f;
    private Light _titleLight;
    void Start()
    {  
        IniGameObject();
        StartCoroutine(LightConTrol());
    }

    private void IniGameObject()//点灯状態を初期化
    {
        _titleLight = GetComponent<Light>();
        _titleLight.enabled = true;
    }

    IEnumerator LightConTrol()
    {
        while (true)
        {
            //一定の時間を待つ（今は点灯状態）
            yield return new WaitForSecondsRealtime(Random.Range(6f, 16f));

            //フラッシュ開始
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled = true;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=true;
            yield return new WaitForSecondsRealtime(Random.Range(0.8f, 2.8f));
            _titleLight.enabled=false; //最後は消す状態

            //フラッシュ終了（今は消す状態）
            //一定の時間を待つ
            yield return new WaitForSecondsRealtime(Random.Range(3f, 10f));

            //フラッシュ開始
            _titleLight.enabled=true;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=true; //最後は点灯状態
            //最初に戻す（循環）
        }
    }
}
