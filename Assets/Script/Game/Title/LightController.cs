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

    private void IniGameObject()//�_����Ԃ�������
    {
        _titleLight = GetComponent<Light>();
        _titleLight.enabled = true;
    }

    IEnumerator LightConTrol()
    {
        while (true)
        {
            //���̎��Ԃ�҂i���͓_����ԁj
            yield return new WaitForSecondsRealtime(Random.Range(6f, 16f));

            //�t���b�V���J�n
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled = true;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=true;
            yield return new WaitForSecondsRealtime(Random.Range(0.8f, 2.8f));
            _titleLight.enabled=false; //�Ō�͏������

            //�t���b�V���I���i���͏�����ԁj
            //���̎��Ԃ�҂�
            yield return new WaitForSecondsRealtime(Random.Range(3f, 10f));

            //�t���b�V���J�n
            _titleLight.enabled=true;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=false;
            yield return new WaitForSecondsRealtime(_flashTime);
            _titleLight.enabled=true; //�Ō�͓_�����
            //�ŏ��ɖ߂��i�z�j
        }
    }
}
