using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Color2 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.Color2 o;
		if(matchType(l,1,typeof(UnityEngine.Color),typeof(UnityEngine.Color))){
			UnityEngine.Color a1;
			checkType(l,1,out a1);
			UnityEngine.Color a2;
			checkType(l,2,out a2);
			o=new DG.Tweening.Color2(a1,a2);
			pushObject(l,o);
			return 1;
		}
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Addition(IntPtr l) {
		try{
			DG.Tweening.Color2 a1;
			checkType(l,1,out a1);
			DG.Tweening.Color2 a2;
			checkType(l,2,out a2);
			DG.Tweening.Color2 ret=a1+a2;
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Subtraction(IntPtr l) {
		try{
			DG.Tweening.Color2 a1;
			checkType(l,1,out a1);
			DG.Tweening.Color2 a2;
			checkType(l,2,out a2);
			DG.Tweening.Color2 ret=a1-a2;
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Multiply(IntPtr l) {
		try{
			DG.Tweening.Color2 a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Color2 ret=a1*a2;
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ca(IntPtr l) {
		DG.Tweening.Color2 o = (DG.Tweening.Color2)checkSelf(l);
		pushValue(l,o.ca);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ca(IntPtr l) {
		DG.Tweening.Color2 o = (DG.Tweening.Color2)checkSelf(l);
		UnityEngine.Color v;
		checkType(l,2,out v);
		o.ca=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cb(IntPtr l) {
		DG.Tweening.Color2 o = (DG.Tweening.Color2)checkSelf(l);
		pushValue(l,o.cb);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cb(IntPtr l) {
		DG.Tweening.Color2 o = (DG.Tweening.Color2)checkSelf(l);
		UnityEngine.Color v;
		checkType(l,2,out v);
		o.cb=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Color2");
		addMember(l,op_Addition);
		addMember(l,op_Subtraction);
		addMember(l,op_Multiply);
		addMember(l,"ca",get_ca,set_ca,true);
		addMember(l,"cb",get_cb,set_cb,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Color2));
	}
}
