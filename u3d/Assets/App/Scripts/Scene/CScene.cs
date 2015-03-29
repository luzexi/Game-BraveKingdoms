using UnityEngine;
using System;
using System.Collections;

//  CScene.cs
//  Author: Lu Zexi
//  2014-07-16

 

// base scene
public class CScene
{
    public static CScene s_cCurrentScene;

    public static bool Is(Type type)
    {
        return type == s_cCurrentScene.GetType();
    }

    public static void Switch<T>()
        where T : CScene , new()
    {
        if(s_cCurrentScene != null )
            s_cCurrentScene.OnExit();
        s_cCurrentScene = new T();
        s_cCurrentScene.OnEnter();
    }

    /// <summary>
    /// Raises the enter event.
    /// </summary>
    public virtual void OnEnter()
    {
        //
    }

    //update
    public virtual void Update()
    {
        //
    }

    /// <summary>
    /// Raises the exit event.
    /// </summary>
    public virtual void OnExit()
    {
        //
    }
}