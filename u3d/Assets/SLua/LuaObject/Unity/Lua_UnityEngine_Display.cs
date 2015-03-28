using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Display : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Activate(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			self.Activate();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRenderingResolution(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.SetRenderingResolution(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_displays(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Display.displays);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_displays(IntPtr l) {
		try {
			UnityEngine.Display[] v;
			checkType(l,2,out v);
			UnityEngine.Display.displays=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderingWidth(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.renderingWidth);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderingHeight(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.renderingHeight);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_systemWidth(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.systemWidth);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_systemHeight(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.systemHeight);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colorBuffer(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.colorBuffer);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_depthBuffer(IntPtr l) {
		try {
			UnityEngine.Display self=(UnityEngine.Display)checkSelf(l);
			pushValue(l,self.depthBuffer);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_main(IntPtr l) {
		try {
			pushValue(l,UnityEngine.Display.main);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Display");
		addMember(l,Activate);
		addMember(l,SetRenderingResolution);
		addMember(l,"displays",get_displays,set_displays,false);
		addMember(l,"renderingWidth",get_renderingWidth,null,true);
		addMember(l,"renderingHeight",get_renderingHeight,null,true);
		addMember(l,"systemWidth",get_systemWidth,null,true);
		addMember(l,"systemHeight",get_systemHeight,null,true);
		addMember(l,"colorBuffer",get_colorBuffer,null,true);
		addMember(l,"depthBuffer",get_depthBuffer,null,true);
		addMember(l,"main",get_main,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Display));
	}
}
