using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_CharacterInfo : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.CharacterInfo o;
			o=new UnityEngine.CharacterInfo();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_index(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.index);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_index(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.index=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uv(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.uv);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uv(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			UnityEngine.Rect v;
			checkType(l,2,out v);
			self.uv=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_vert(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.vert);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_vert(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			UnityEngine.Rect v;
			checkType(l,2,out v);
			self.vert=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_width(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.width);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_width(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.width=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_size(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.size);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_size(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.size=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_style(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushEnum(l,(int)self.style);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_style(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			UnityEngine.FontStyle v;
			checkEnum(l,2,out v);
			self.style=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_flipped(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			pushValue(l,self.flipped);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_flipped(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.flipped=v;
			setBack(l,self);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CharacterInfo");
		addMember(l,"index",get_index,set_index,true);
		addMember(l,"uv",get_uv,set_uv,true);
		addMember(l,"vert",get_vert,set_vert,true);
		addMember(l,"width",get_width,set_width,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"style",get_style,set_style,true);
		addMember(l,"flipped",get_flipped,set_flipped,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CharacterInfo));
	}
}
