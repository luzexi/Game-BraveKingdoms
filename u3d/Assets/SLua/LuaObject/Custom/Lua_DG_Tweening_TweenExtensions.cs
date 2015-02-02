using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Complete_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.Complete(a1);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.Flip(a1);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			DG.Tweening.TweenExtensions.Goto(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GotoWaypoint_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			DG.Tweening.TweenExtensions.GotoWaypoint(a1,a2,a3);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Kill(a1,a2);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.PlayBackwards(a1);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.PlayForward(a1);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Restart(a1,a2);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Rewind(a1,a2);
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
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.TogglePause(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForCompletion_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			UnityEngine.YieldInstruction ret=DG.Tweening.TweenExtensions.WaitForCompletion(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForKill_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			UnityEngine.YieldInstruction ret=DG.Tweening.TweenExtensions.WaitForKill(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForElapsedLoops_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.YieldInstruction ret=DG.Tweening.TweenExtensions.WaitForElapsedLoops(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForPosition_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			UnityEngine.YieldInstruction ret=DG.Tweening.TweenExtensions.WaitForPosition(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForStart_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			UnityEngine.Coroutine ret=DG.Tweening.TweenExtensions.WaitForStart(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompletedLoops_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 ret=DG.Tweening.TweenExtensions.CompletedLoops(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Delay_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single ret=DG.Tweening.TweenExtensions.Delay(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Duration_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			System.Single ret=DG.Tweening.TweenExtensions.Duration(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Elapsed_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			System.Single ret=DG.Tweening.TweenExtensions.Elapsed(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ElapsedPercentage_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			System.Single ret=DG.Tweening.TweenExtensions.ElapsedPercentage(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsActive_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean ret=DG.Tweening.TweenExtensions.IsActive(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsBackwards_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean ret=DG.Tweening.TweenExtensions.IsBackwards(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPlaying_s(IntPtr l) {
		try{
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean ret=DG.Tweening.TweenExtensions.IsPlaying(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.TweenExtensions");
		addMember(l,Complete_s);
		addMember(l,Flip_s);
		addMember(l,Goto_s);
		addMember(l,GotoWaypoint_s);
		addMember(l,Kill_s);
		addMember(l,PlayBackwards_s);
		addMember(l,PlayForward_s);
		addMember(l,Restart_s);
		addMember(l,Rewind_s);
		addMember(l,TogglePause_s);
		addMember(l,WaitForCompletion_s);
		addMember(l,WaitForKill_s);
		addMember(l,WaitForElapsedLoops_s);
		addMember(l,WaitForPosition_s);
		addMember(l,WaitForStart_s);
		addMember(l,CompletedLoops_s);
		addMember(l,Delay_s);
		addMember(l,Duration_s);
		addMember(l,Elapsed_s);
		addMember(l,ElapsedPercentage_s);
		addMember(l,IsActive_s);
		addMember(l,IsBackwards_s);
		addMember(l,IsPlaying_s);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.TweenExtensions));
	}
}
