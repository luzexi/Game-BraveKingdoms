﻿

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

    // cast to the action int function
    public static System.Action<int> ToActionInt( LuaFunction fun )
    {
        return (System.Action<int>)(( arg )=>{
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

    // cast to the action string string function
    public static System.Action<string,string> ToActionStrStr( LuaFunction fun )
    {
        return (System.Action<string,string>)(( arg1, arg2 )=>{
            fun.call( arg1, arg2 );
        });
    }

    // cast to the action string string function
    public static System.Action<string,string,string> ToActionStrStrStr( LuaFunction fun )
    {
        return (System.Action<string,string,string>)(( arg1, arg2, arg3 )=>{
            fun.call( arg1, arg2, arg3 );
        });
    }

    // cast to the action string function
    public static System.Action<GameObject,int> ToActionGameObjectInt( LuaFunction fun )
    {
        return (System.Action<GameObject,int>)(( arg1 , arg2 )=>{
            fun.call( arg1 , arg2 );
        });
    }

    public static System.Action<int,int,float,bool> ToActionIntIntFloatBool( LuaFunction fun )
    {
        return (System.Action<int,int,float,bool>)(( arg1 , arg2 , arg3 , arg4 )=>{
            fun.call( arg1 , arg2 , arg3 , arg4 );
        });
    }
}

