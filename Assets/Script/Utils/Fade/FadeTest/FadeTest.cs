﻿using UnityEngine;

public class FadeTest : MonoBehaviour
{
    public static FadeTest Instance;
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
#if UNITY_EDITOR

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            //_fadeEvent.FadeIn(1f);
            SceneSwitcher.Instance.Loading(1f, "Map_Test");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneSwitcher.Instance.Loading(1f, "Map");
        }
    }
#endif
}
