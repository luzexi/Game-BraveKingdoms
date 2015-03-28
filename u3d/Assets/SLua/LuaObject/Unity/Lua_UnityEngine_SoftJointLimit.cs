using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_SoftJointLimit : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit o;
			o=new UnityEngine.SoftJointLimit();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limit(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			pushValue(l,self.limit);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limit(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.limit=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spring(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			pushValue(l,self.spring);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spring(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.spring=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_damper(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			pushValue(l,self.damper);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_damper(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.damper=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bounciness(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			pushValue(l,self.bounciness);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bounciness(IntPtr l) {
		try {
			UnityEngine.SoftJointLimit self;
			checkType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.bounciness=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SoftJointLimit");
		addMember(l,"limit",get_limit,set_limit,true);
		addMember(l,"spring",get_spring,set_spring,true);
		addMember(l,"damper",get_damper,set_damper,true);
		addMember(l,"bounciness",get_bounciness,set_bounciness,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SoftJointLimit));
	}
}
