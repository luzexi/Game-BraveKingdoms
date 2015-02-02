using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Tweener : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ChangeStartValue(IntPtr l) {
		try{
			DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			DG.Tweening.Tweener ret=self.ChangeStartValue(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ChangeEndValue(IntPtr l) {
		try{
			if(matchType(l,2,typeof(System.Object),typeof(float),typeof(bool))){
				DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				DG.Tweening.Tweener ret=self.ChangeEndValue(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,2,typeof(System.Object),typeof(bool))){
				DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				DG.Tweening.Tweener ret=self.ChangeEndValue(a1,a2);
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
	static public int ChangeValues(IntPtr l) {
		try{
			DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Object a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			DG.Tweening.Tweener ret=self.ChangeValues(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Tweener");
		addMember(l,ChangeStartValue);
		addMember(l,ChangeEndValue);
		addMember(l,ChangeValues);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Tweener),typeof(DG.Tweening.Tween));
	}
}
