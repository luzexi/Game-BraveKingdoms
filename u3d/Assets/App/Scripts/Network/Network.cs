

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Network;

//  Netork.cs
//  Author: Lu Zexi
//  2015-02-09



//network class
[CustomLuaClassAttribute]
public class Network
{
    public static void Request( string url , string param , System.Action<string> callback )
    {
        HttpRequest.Request(url + "?" + param , null , null , null , callback , ErrorCallBack );
    }

    //default error callback
    private static void ErrorCallBack( string error , System.Action retry , System.Action close )
    {
        Debug.LogError("error http request : " + error);
        close();
    }
}

