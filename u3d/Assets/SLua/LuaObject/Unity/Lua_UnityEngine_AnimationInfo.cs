using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_AnimationInfo : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AnimationInfo o;
			o=new UnityEngine.AnimationInfo();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_clip(IntPtr l) {
		try {
			UnityEngine.AnimationInfo self;
			checkType(l,1,out self);
			pushValue(l,self.clip);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_weight(IntPtr l) {
		try {
			UnityEngine.AnimationInfo self;
			checkType(l,1,out self);
			pushValue(l,self.weight);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimationInfo");
		addMember(l,"clip",get_clip,null,true);
		addMember(l,"weight",get_weight,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimationInfo));
	}
}
