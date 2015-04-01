using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UI_FontNum : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Setup(IntPtr l) {
		try {
			UI_FontNum self=(UI_FontNum)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.Setup(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Num(IntPtr l) {
		try {
			UI_FontNum self=(UI_FontNum)checkSelf(l);
			pushValue(l,self.Num);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Num(IntPtr l) {
		try {
			UI_FontNum self=(UI_FontNum)checkSelf(l);
			UnityEngine.Sprite[] v;
			checkType(l,2,out v);
			self.Num=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_interval(IntPtr l) {
		try {
			UI_FontNum self=(UI_FontNum)checkSelf(l);
			pushValue(l,self.interval);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_interval(IntPtr l) {
		try {
			UI_FontNum self=(UI_FontNum)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.interval=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UI_FontNum");
		addMember(l,Setup);
		addMember(l,"Num",get_Num,set_Num,true);
		addMember(l,"interval",get_interval,set_interval,true);
		createTypeMetatable(l,null, typeof(UI_FontNum),typeof(UnityEngine.MonoBehaviour));
	}
}
