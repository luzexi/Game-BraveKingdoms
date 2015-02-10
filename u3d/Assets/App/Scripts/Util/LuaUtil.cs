

using System;
using UnityEngine;
using LuaInterface;
using SLua;

//  LuaUtil.cs
//  Author: Lu Zexi
//  2015-02-04


[CustomLuaClassAttribute]
public class LuaUtil
{
    // cast to the action function
    public static System.Action ToAction( LuaFunction fun )
    {
        return (System.Action)(()=>{
            fun.call();
        });
    }

    // cast to the action float function
    public static System.Action<float> ToActionFloat( LuaFunction fun )
    {
        return (System.Action<float>)(( arg )=>{
            fun.call( arg );
        });
    }

    // cast to the action string function
    public static System.Action<string> ToActionStr( LuaFunction fun )
    {
        return (System.Action<string>)(( arg )=>{
            fun.call( arg );
        });
    }
}

