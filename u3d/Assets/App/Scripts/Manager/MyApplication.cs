using UnityEngine;
using System.IO;
using System;
using SLua;
using DG.Tweening;


/// MyApplaction.cd
/// Author: Lu Zexi
/// 2015-01-17


//my applaction
public class MyApplication : MonoBehaviour
{

    private const string UIROOT = "UICamera/Canvas";

    //awake
    void Awake()
    {
    }

    //start
    void Start()
    {
        Init();
    }

    void OnDestroy()
    {
        MyLua.sInstance.OnDestroy();
    }

    void Init()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
        UIManager.sInstance.UIRoot = GameObject.Find(UIROOT).gameObject;
        MyLua.sInstance.Init();
    }

    //update
    void Update()
    {
        MyLua.sInstance.Update();
    }

    //fixed update
    void FixedUpdate()
    {
        //
    }
}
