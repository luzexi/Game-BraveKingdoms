using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenSettingsExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Append_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.Append(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Prepend_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.Prepend(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Join_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.Join(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Insert_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Tween a3;
			checkType(l,3,out a3);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.Insert(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendInterval_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.AppendInterval(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrependInterval_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.PrependInterval(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendCallback_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.TweenCallback a2;
			checkDelegate(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.AppendCallback(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrependCallback_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.TweenCallback a2;
			checkDelegate(l,2,out a2);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.PrependCallback(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InsertCallback_s(IntPtr l) {
		try{
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Core.TweenCallback a3;
			checkDelegate(l,3,out a3);
			DG.Tweening.Sequence ret=DG.Tweening.TweenSettingsExtensions.InsertCallback(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetOptions_s(IntPtr l) {
		try{
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLookAt_s(IntPtr l) {
		try{
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.TweenSettingsExtensions");
		addMember(l,Append_s);
		addMember(l,Prepend_s);
		addMember(l,Join_s);
		addMember(l,Insert_s);
		addMember(l,AppendInterval_s);
		addMember(l,PrependInterval_s);
		addMember(l,AppendCallback_s);
		addMember(l,PrependCallback_s);
		addMember(l,InsertCallback_s);
		addMember(l,SetOptions_s);
		addMember(l,SetLookAt_s);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.TweenSettingsExtensions));
	}
}
