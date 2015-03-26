using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaUtil : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaUtil o;
		o=new LuaUtil();
		pushObject(l,o);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToAction_s(IntPtr l) {
		try{
			SLua.LuaFunction a1;
			checkType(l,1,out a1);
			System.Action ret=LuaUtil.ToAction(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToActionFloat_s(IntPtr l) {
		try{
			SLua.LuaFunction a1;
			checkType(l,1,out a1);
			System.Action<System.Single> ret=LuaUtil.ToActionFloat(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToActionStr_s(IntPtr l) {
		try{
			SLua.LuaFunction a1;
			checkType(l,1,out a1);
			System.Action<System.String> ret=LuaUtil.ToActionStr(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToActionGameObjectInt_s(IntPtr l) {
		try{
			SLua.LuaFunction a1;
			checkType(l,1,out a1);
			System.Action<UnityEngine.GameObject,System.Int32> ret=LuaUtil.ToActionGameObjectInt(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToActionIntIntFloatBool_s(IntPtr l) {
		try{
			SLua.LuaFunction a1;
			checkType(l,1,out a1);
			System.Action<System.Int32,System.Int32,System.Single,System.Boolean> ret=LuaUtil.ToActionIntIntFloatBool(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaUtil");
		addMember(l,ToAction_s);
		addMember(l,ToActionFloat_s);
		addMember(l,ToActionStr_s);
		addMember(l,ToActionGameObjectInt_s);
		addMember(l,ToActionIntIntFloatBool_s);
		createTypeMetatable(l,constructor, typeof(LuaUtil));
	}
}
