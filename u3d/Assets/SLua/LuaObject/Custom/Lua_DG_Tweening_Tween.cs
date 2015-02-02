using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Tween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.timeScale);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.timeScale=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isBackwards(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.isBackwards);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isBackwards(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.isBackwards=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.id);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Object v;
		checkType(l,2,out v);
		o.id=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.target);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Object v;
		checkType(l,2,out v);
		o.target=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easeOvershootOrAmplitude(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.easeOvershootOrAmplitude);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeOvershootOrAmplitude(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.easeOvershootOrAmplitude=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easePeriod(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		pushValue(l,o.easePeriod);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easePeriod(IntPtr l) {
		DG.Tweening.Tween o = (DG.Tweening.Tween)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.easePeriod=v;
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Tween");
		addMember(l,"timeScale",get_timeScale,set_timeScale,true);
		addMember(l,"isBackwards",get_isBackwards,set_isBackwards,true);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"easeOvershootOrAmplitude",get_easeOvershootOrAmplitude,set_easeOvershootOrAmplitude,true);
		addMember(l,"easePeriod",get_easePeriod,set_easePeriod,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Tween),typeof(DG.Tweening.Core.ABSSequentiable));
	}
}
