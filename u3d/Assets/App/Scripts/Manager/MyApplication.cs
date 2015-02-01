using UnityEngine;
using System.IO;
using System;
using SLua;


/// MyApplaction.cd
/// Author: Lu Zexi
/// 2015-01-17


//my applaction
public class MyApplication : MonoBehaviour
{

    private const string UIROOT = "UICamera/Canvas";
    private MyLua m_cLua = new MyLua();

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
        this.m_cLua.OnDestroy();
    }

    void Init()
    {
        UIManager.sInstance.UIRoot = GameObject.Find(UIROOT).gameObject;
        this.m_cLua.Init();
    }

    //update
    void Update()
    {
        this.m_cLua.Update();
    }

    //fixed update
    void FixedUpdate()
    {
        //
    }
}
