using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenParams : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.TweenParams o;
		if(matchType(l,1)){
			o=new DG.Tweening.TweenParams();
			pushObject(l,o);
			return 1;
		}
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenParams ret=self.Clear();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetAutoKill(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetAutoKill(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetId(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetId(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTarget(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetTarget(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLoops(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Nullable<DG.Tweening.LoopType> a2;
			checkType(l,3,out a2);
			DG.Tweening.TweenParams ret=self.SetLoops(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetEase(IntPtr l) {
		try{
			if(matchType(l,2,typeof(UnityEngine.AnimationCurve))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				UnityEngine.AnimationCurve a1;
				checkType(l,2,out a1);
				DG.Tweening.TweenParams ret=self.SetEase(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,2,typeof(DG.Tweening.Core.EaseFunction))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				DG.Tweening.Core.EaseFunction a1;
				checkDelegate(l,2,out a1);
				DG.Tweening.TweenParams ret=self.SetEase(a1);
				pushValue(l,ret);
				return 1;
			}
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRecyclable(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetRecyclable(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetUpdate(IntPtr l) {
		try{
			if(matchType(l,2,typeof(bool))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				DG.Tweening.TweenParams ret=self.SetUpdate(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,2,typeof(DG.Tweening.UpdateType),typeof(bool))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				DG.Tweening.UpdateType a1;
				checkEnum(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				DG.Tweening.TweenParams ret=self.SetUpdate(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStart(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnStart(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPlay(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnPlay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnRewind(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnRewind(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnUpdate(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnUpdate(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStepComplete(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnStepComplete(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnComplete(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnComplete(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnKill(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnKill(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnWaypointChange(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.Core.TweenCallback<System.Int32> a1;
			checkDelegate(l,2,out a1);
			DG.Tweening.TweenParams ret=self.OnWaypointChange(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetDelay(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetDelay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRelative(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetRelative(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetSpeedBased(IntPtr l) {
		try{
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			DG.Tweening.TweenParams ret=self.SetSpeedBased(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Params(IntPtr l) {
		pushValue(l,DG.Tweening.TweenParams.Params);
		return 1;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.TweenParams");
		addMember(l,Clear);
		addMember(l,SetAutoKill);
		addMember(l,SetId);
		addMember(l,SetTarget);
		addMember(l,SetLoops);
		addMember(l,SetEase);
		addMember(l,SetRecyclable);
		addMember(l,SetUpdate);
		addMember(l,OnStart);
		addMember(l,OnPlay);
		addMember(l,OnRewind);
		addMember(l,OnUpdate);
		addMember(l,OnStepComplete);
		addMember(l,OnComplete);
		addMember(l,OnKill);
		addMember(l,OnWaypointChange);
		addMember(l,SetDelay);
		addMember(l,SetRelative);
		addMember(l,SetSpeedBased);
		addMember(l,"Params",get_Params,null,false);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.TweenParams));
	}
}
