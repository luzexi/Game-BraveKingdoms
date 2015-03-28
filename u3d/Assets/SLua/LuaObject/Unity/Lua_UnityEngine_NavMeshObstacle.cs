using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_NavMeshObstacle : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle o;
			o=new UnityEngine.NavMeshObstacle();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_height(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			pushValue(l,self.height);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_height(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.height=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_radius(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			pushValue(l,self.radius);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_radius(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.radius=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			pushValue(l,self.velocity);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_velocity(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.velocity=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_carving(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			pushValue(l,self.carving);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_carving(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.carving=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_carvingMoveThreshold(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			pushValue(l,self.carvingMoveThreshold);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_carvingMoveThreshold(IntPtr l) {
		try {
			UnityEngine.NavMeshObstacle self=(UnityEngine.NavMeshObstacle)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.carvingMoveThreshold=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.NavMeshObstacle");
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"carving",get_carving,set_carving,true);
		addMember(l,"carvingMoveThreshold",get_carvingMoveThreshold,set_carvingMoveThreshold,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.NavMeshObstacle),typeof(UnityEngine.Behaviour));
	}
}
