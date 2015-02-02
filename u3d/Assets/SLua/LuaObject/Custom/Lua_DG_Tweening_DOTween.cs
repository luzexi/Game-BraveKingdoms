using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_DOTween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.DOTween o;
		if(matchType(l,1)){
			o=new DG.Tweening.DOTween();
			pushObject(l,o);
			return 1;
		}
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init_s(IntPtr l) {
		try{
			System.Boolean a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.LogBehaviour a3;
			checkEnum(l,3,out a3);
			DG.Tweening.IDOTweenInit ret=DG.Tweening.DOTween.Init(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTweensCapacity_s(IntPtr l) {
		try{
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			DG.Tweening.DOTween.SetTweensCapacity(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear_s(IntPtr l) {
		try{
			System.Boolean a1;
			checkType(l,1,out a1);
			DG.Tweening.DOTween.Clear(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearCachedTweens_s(IntPtr l) {
		try{
			DG.Tweening.DOTween.ClearCachedTweens();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Validate_s(IntPtr l) {
		try{
			System.Int32 ret=DG.Tweening.DOTween.Validate();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int To_s(IntPtr l) {
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
	static public int ToAxis_s(IntPtr l) {
		try{
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			checkDelegate(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			DG.Tweening.AxisConstraint a5;
			checkEnum(l,5,out a5);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3,DG.Tweening.Plugins.Options.VectorOptions> ret=DG.Tweening.DOTween.ToAxis(a1,a2,a3,a4,a5);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToAlpha_s(IntPtr l) {
		try{
			DG.Tweening.Core.DOGetter<UnityEngine.Color> a1;
			checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Color> a2;
			checkDelegate(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.DOTween.ToAlpha(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Punch_s(IntPtr l) {
		try{
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			checkDelegate(l,2,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Single a6;
			checkType(l,6,out a6);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3<>,DG.Tweening.Plugins.Options.Vector3ArrayOptions> ret=DG.Tweening.DOTween.Punch(a1,a2,a3,a4,a5,a6);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Shake_s(IntPtr l) {
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
	static public int ToArray_s(IntPtr l) {
		try{
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			checkDelegate(l,2,out a2);
			UnityEngine.Vector3[] a3;
			checkType(l,3,out a3);
			System.Single[] a4;
			checkType(l,4,out a4);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3<>,DG.Tweening.Plugins.Options.Vector3ArrayOptions> ret=DG.Tweening.DOTween.ToArray(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Sequence_s(IntPtr l) {
		try{
			DG.Tweening.Sequence ret=DG.Tweening.DOTween.Sequence();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Complete_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.Complete();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Complete(a1);
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
	static public int Flip_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.Flip();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Flip(a1);
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
	static public int Goto_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(float),typeof(bool))){
				System.Single a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				System.Int32 ret=DG.Tweening.DOTween.Goto(a1,a2);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object),typeof(float),typeof(bool))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				System.Int32 ret=DG.Tweening.DOTween.Goto(a1,a2,a3);
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
	static public int Kill_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(bool))){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Kill(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object),typeof(bool))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				System.Int32 ret=DG.Tweening.DOTween.Kill(a1,a2);
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
	static public int Pause_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.Pause();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Pause(a1);
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
	static public int Play_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.Play();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Play(a1);
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
	static public int PlayBackwards_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.PlayBackwards();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.PlayBackwards(a1);
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
	static public int PlayForward_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.PlayForward();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.PlayForward(a1);
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
	static public int Restart_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(bool))){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Restart(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object),typeof(bool))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				System.Int32 ret=DG.Tweening.DOTween.Restart(a1,a2);
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
	static public int Rewind_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(bool))){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.Rewind(a1);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object),typeof(bool))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				System.Int32 ret=DG.Tweening.DOTween.Rewind(a1,a2);
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
	static public int TogglePause_s(IntPtr l) {
		try{
			if(matchType(l,1)){
				System.Int32 ret=DG.Tweening.DOTween.TogglePause();
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(System.Object))){
				System.Object a1;
				checkType(l,1,out a1);
				System.Int32 ret=DG.Tweening.DOTween.TogglePause(a1);
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
	static public int IsTweening_s(IntPtr l) {
		try{
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean ret=DG.Tweening.DOTween.IsTweening(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TotalPlayingTweens_s(IntPtr l) {
		try{
			System.Int32 ret=DG.Tweening.DOTween.TotalPlayingTweens();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayingTweens_s(IntPtr l) {
		try{
			List<DG.Tweening.Tween> ret=DG.Tweening.DOTween.PlayingTweens();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PausedTweens_s(IntPtr l) {
		try{
			List<DG.Tweening.Tween> ret=DG.Tweening.DOTween.PausedTweens();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Version(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.Version);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useSafeMode(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.useSafeMode);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useSafeMode(IntPtr l) {
		System.Boolean v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.useSafeMode=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showUnityEditorReport(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.showUnityEditorReport);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showUnityEditorReport(IntPtr l) {
		System.Boolean v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.showUnityEditorReport=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.timeScale);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		System.Single v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.timeScale=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultUpdateType(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultUpdateType);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultUpdateType(IntPtr l) {
		DG.Tweening.UpdateType v;
		checkEnum(l,2,out v);
		DG.Tweening.DOTween.defaultUpdateType=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoPlay(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultAutoPlay);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoPlay(IntPtr l) {
		DG.Tweening.AutoPlay v;
		checkEnum(l,2,out v);
		DG.Tweening.DOTween.defaultAutoPlay=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoKill(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultAutoKill);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoKill(IntPtr l) {
		System.Boolean v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.defaultAutoKill=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultLoopType(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultLoopType);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultLoopType(IntPtr l) {
		DG.Tweening.LoopType v;
		checkEnum(l,2,out v);
		DG.Tweening.DOTween.defaultLoopType=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultRecyclable(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultRecyclable);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultRecyclable(IntPtr l) {
		System.Boolean v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.defaultRecyclable=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseType(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultEaseType);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseType(IntPtr l) {
		DG.Tweening.Ease v;
		checkEnum(l,2,out v);
		DG.Tweening.DOTween.defaultEaseType=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseOvershootOrAmplitude(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseOvershootOrAmplitude(IntPtr l) {
		System.Single v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEasePeriod(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.defaultEasePeriod);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEasePeriod(IntPtr l) {
		System.Single v;
		checkType(l,2,out v);
		DG.Tweening.DOTween.defaultEasePeriod=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logBehaviour(IntPtr l) {
		pushValue(l,DG.Tweening.DOTween.logBehaviour);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logBehaviour(IntPtr l) {
		DG.Tweening.LogBehaviour v;
		checkEnum(l,2,out v);
		DG.Tweening.DOTween.logBehaviour=v;
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.DOTween");
		addMember(l,Init_s);
		addMember(l,SetTweensCapacity_s);
		addMember(l,Clear_s);
		addMember(l,ClearCachedTweens_s);
		addMember(l,Validate_s);
		addMember(l,To_s);
		addMember(l,ToAxis_s);
		addMember(l,ToAlpha_s);
		addMember(l,Punch_s);
		addMember(l,Shake_s);
		addMember(l,ToArray_s);
		addMember(l,Sequence_s);
		addMember(l,Complete_s);
		addMember(l,Flip_s);
		addMember(l,Goto_s);
		addMember(l,Kill_s);
		addMember(l,Pause_s);
		addMember(l,Play_s);
		addMember(l,PlayBackwards_s);
		addMember(l,PlayForward_s);
		addMember(l,Restart_s);
		addMember(l,Rewind_s);
		addMember(l,TogglePause_s);
		addMember(l,IsTweening_s);
		addMember(l,TotalPlayingTweens_s);
		addMember(l,PlayingTweens_s);
		addMember(l,PausedTweens_s);
		addMember(l,"Version",get_Version,null,false);
		addMember(l,"useSafeMode",get_useSafeMode,set_useSafeMode,false);
		addMember(l,"showUnityEditorReport",get_showUnityEditorReport,set_showUnityEditorReport,false);
		addMember(l,"timeScale",get_timeScale,set_timeScale,false);
		addMember(l,"defaultUpdateType",get_defaultUpdateType,set_defaultUpdateType,false);
		addMember(l,"defaultAutoPlay",get_defaultAutoPlay,set_defaultAutoPlay,false);
		addMember(l,"defaultAutoKill",get_defaultAutoKill,set_defaultAutoKill,false);
		addMember(l,"defaultLoopType",get_defaultLoopType,set_defaultLoopType,false);
		addMember(l,"defaultRecyclable",get_defaultRecyclable,set_defaultRecyclable,false);
		addMember(l,"defaultEaseType",get_defaultEaseType,set_defaultEaseType,false);
		addMember(l,"defaultEaseOvershootOrAmplitude",get_defaultEaseOvershootOrAmplitude,set_defaultEaseOvershootOrAmplitude,false);
		addMember(l,"defaultEasePeriod",get_defaultEasePeriod,set_defaultEasePeriod,false);
		addMember(l,"logBehaviour",get_logBehaviour,set_logBehaviour,false);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.DOTween));
	}
}
