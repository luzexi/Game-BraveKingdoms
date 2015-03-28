using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ClothRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ClothRenderer o;
			o=new UnityEngine.ClothRenderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pauseWhenNotVisible(IntPtr l) {
		try {
			UnityEngine.ClothRenderer self=(UnityEngine.ClothRenderer)checkSelf(l);
			pushValue(l,self.pauseWhenNotVisible);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pauseWhenNotVisible(IntPtr l) {
		try {
			UnityEngine.ClothRenderer self=(UnityEngine.ClothRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.pauseWhenNotVisible=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ClothRenderer");
		addMember(l,"pauseWhenNotVisible",get_pauseWhenNotVisible,set_pauseWhenNotVisible,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ClothRenderer),typeof(UnityEngine.Renderer));
	}
}
