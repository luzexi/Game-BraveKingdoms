using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using SLua;

//  MyLua.cs
//  Author: Lu Zexi
//  2015-02-01


//my lua
public class MyLua : MonoBehaviour
{
    private static MyLua s_cInstance;
    public static MyLua sInstance
    {
        get
        {
            if(s_cInstance == null)
            {
                GameObject go = new GameObject("MyLua");
                s_cInstance = go.AddComponent<MyLua>();
            }
            return s_cInstance;
        }
    }

    private LuaState m_cLuaState = null;   //lua state
    public LuaState LuaState
    {
        get
        {
            if(m_cLuaState == null )
                return null;
            return m_cLuaState;
        }
    }

    //init
    public void Init()
    {
        this.m_cLuaState = new LuaState();
        LuaObject.init(this. m_cLuaState.handle);
        LuaState.loaderDelegate = RequireLua;
        Bind("BindUnity");
        Bind("BindUnityUI");
        Bind("BindCustom");

        LuaTimer.reg(this.m_cLuaState.L);
        LuaCoroutine.reg(this.m_cLuaState.L, this);

        this.m_cLuaState.doFile("Main");
        LuaFunction func = (LuaFunction)this.m_cLuaState["main"];
        func.call();
    }

    //update
    void Update()
    {
        if(this.m_cLuaState != null)
            this.m_cLuaState.checkRef();
    }

    //on destroy
    void OnDestroy()
    {
        if(this.m_cLuaState != null)
            this.m_cLuaState.Close();
        this.m_cLuaState = null;
    }

    //require lua
    private byte[] RequireLua(string fn)
    {
        try
        {
            string WorkPath =  Application.dataPath + "/App/Scripts/lua/";
            byte[] bytes;
            {
                if (fn.EndsWith(".txt") || fn.EndsWith(".lua"))
                {
                    fn = WorkPath + fn;
                }
                else
                {
                    fn = fn.Replace('.', '/');
                    fn = WorkPath + fn + ".lua";
                }
                FileStream fs = File.Open(fn, FileMode.Open);
                long length = fs.Length;
                bytes = new byte[length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
            }
            return bytes;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        return null;
    }

    void Bind(string name)
    {
        MethodInfo mi = typeof(LuaObject).GetMethod(name,BindingFlags.Public|BindingFlags.Static);
        if (mi != null) mi.Invoke(null, new object[] { this.m_cLuaState.handle });
        else if(name=="BindUnity") Debug.LogError(string.Format("Miss {0}, click SLua=>Make to regenerate them",name));
    }
}
