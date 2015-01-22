
using UnityEngine;
using System.IO;
using System;
using UniLua;


/// MyApplaction.cd
/// Author: Lu Zexi
/// 2015-01-17


//my applaction
public class MyApplaction : MonoBehaviour
{

    private const string UIROOT = "UICamera/Canvas";
    private ILuaState   Lua;

    //awake
    void Awake()
    {
    }

    //start
    void Start()
    {
        Init();
    }

    void Init()
    {
        UIManager.sInstance.UIRoot = GameObject.Find(UIROOT).gameObject;
        InitLua();
    }

    void InitLua()
    {
        // // LuaScriptMgr luaMgr = LuaScriptMgr.Instance;

        Lua = LuaAPI.NewState();
        Lua.L_OpenLibs();

        var status = Lua.L_DoFile("Main.lua");
        if( status != ThreadStatus.LUA_OK )
        {
            throw new Exception( Lua.ToString(-1) );
        }

        if( ! Lua.IsTable(-1) )
        {
            throw new Exception(
                "framework main's return value is not a table" );
        }

        int funRef = StoreMethod("main");
        Lua.Pop(1);
        CallMethod(funRef);
        Debug.Log("Lua Init Done");
    }

    private int StoreMethod( string name )
    {
        Lua.GetField( -1, name );
        if( !Lua.IsFunction( -1 ) )
        {
            throw new Exception( string.Format(
                "method {0} not found!", name ) );
        }
        return Lua.L_Ref( LuaDef.LUA_REGISTRYINDEX );
    }

    private void CallMethod( int funcRef )
    {
        Lua.RawGetI( LuaDef.LUA_REGISTRYINDEX, funcRef );

        // insert `traceback' function
        var b = Lua.GetTop();
        Lua.PushCSharpFunction( Traceback );
        Lua.Insert(b);

        var status = Lua.PCall( 0, 0, b );
        if( status != ThreadStatus.LUA_OK )
        {
            Debug.LogError( Lua.ToString(-1) );
        }

        // remove `traceback' function
        Lua.Remove(b);
    }

    private static int Traceback(ILuaState lua) {
        var msg = lua.ToString(1);
        if(msg != null) {
            lua.L_Traceback(lua, msg, 1);
        }
        // is there an error object?
        else if(!lua.IsNoneOrNil(1)) {
            // try its `tostring' metamethod
            if(!lua.L_CallMeta(1, "__tostring")) {
                lua.PushString("(no error message)");
            }
        }
        return 1;
    }

    //update
    void Update()
    {
        //
    }

    //fixed update
    void FixedUpdate()
    {
        //
    }
}
