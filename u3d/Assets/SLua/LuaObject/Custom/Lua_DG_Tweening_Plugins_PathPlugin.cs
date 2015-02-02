using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_PathPlugin : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.Plugins.PathPlugin o;
		if(matchType(l,1)){
			o=new DG.Tweening.Plugins.PathPlugin();
			pushObject(l,o);
			return 1;
		}
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
			checkType(l,2,out a1);
			self.Reset(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetFrom(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetFrom(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ConvertToStartValue(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			DG.Tweening.Plugins.Core.PathCore.Path ret=self.ConvertToStartValue(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRelativeEndValue(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
			checkType(l,2,out a1);
			self.SetRelativeEndValue(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetChangeValue(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
			checkType(l,2,out a1);
			self.SetChangeValue(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSpeedBasedDuration(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Plugins.Options.PathOptions a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			DG.Tweening.Plugins.Core.PathCore.Path a3;
			checkType(l,4,out a3);
			System.Single ret=self.GetSpeedBasedDuration(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EvaluateAndApply(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Plugins.Options.PathOptions a1;
			checkType(l,2,out a1);
			DG.Tweening.Tween a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a4;
			checkDelegate(l,5,out a4);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a5;
			checkDelegate(l,6,out a5);
			System.Single a6;
			checkType(l,7,out a6);
			DG.Tweening.Plugins.Core.PathCore.Path a7;
			checkType(l,8,out a7);
			DG.Tweening.Plugins.Core.PathCore.Path a8;
			checkType(l,9,out a8);
			System.Single a9;
			checkType(l,10,out a9);
			System.Boolean a10;
			checkType(l,11,out a10);
			self.EvaluateAndApply(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetOrientation(IntPtr l) {
		try{
			DG.Tweening.Plugins.PathPlugin self=(DG.Tweening.Plugins.PathPlugin)checkSelf(l);
			DG.Tweening.Plugins.Options.PathOptions a1;
			checkType(l,2,out a1);
			DG.Tweening.Tween a2;
			checkType(l,3,out a2);
			DG.Tweening.Plugins.Core.PathCore.Path a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			UnityEngine.Vector3 a5;
			checkType(l,6,out a5);
			self.SetOrientation(a1,a2,a3,a4,a5);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Get_s(IntPtr l) {
		try{
			DG.Tweening.Plugins.Core.ABSTweenPlugin<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> ret=DG.Tweening.Plugins.PathPlugin.Get();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinLookAhead(IntPtr l) {
		pushValue(l,DG.Tweening.Plugins.PathPlugin.MinLookAhead);
		return 1;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.PathPlugin");
		addMember(l,Reset);
		addMember(l,SetFrom);
		addMember(l,ConvertToStartValue);
		addMember(l,SetRelativeEndValue);
		addMember(l,SetChangeValue);
		addMember(l,GetSpeedBasedDuration);
		addMember(l,EvaluateAndApply);
		addMember(l,SetOrientation);
		addMember(l,Get_s);
		addMember(l,"MinLookAhead",get_MinLookAhead,null,false);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.PathPlugin),typeof(DG.Tweening.Plugins.Core.ABSTweenPlugin<<UnityEngine.Vector3, UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null>,<DG.Tweening.Plugins.Core.PathCore.Path, DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>,<DG.Tweening.Plugins.Options.PathOptions, DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>>));
	}
}
