using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_ShortcutExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOFade_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(UnityEngine.CanvasGroup),typeof(float),typeof(float))){
				UnityEngine.CanvasGroup a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Graphic),typeof(float),typeof(float))){
				UnityEngine.UI.Graphic a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Image),typeof(float),typeof(float))){
				UnityEngine.UI.Image a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Outline),typeof(float),typeof(float))){
				UnityEngine.UI.Outline a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Text),typeof(float),typeof(float))){
				UnityEngine.UI.Text a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
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
	static public int DOColor_s(IntPtr l) {
		try{
			if(matchType(l,1,typeof(UnityEngine.UI.Graphic),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.UI.Graphic a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Image),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.UI.Image a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Outline),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.UI.Outline a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,ret);
				return 1;
			}
			else if(matchType(l,1,typeof(UnityEngine.UI.Text),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.UI.Text a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
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
	static public int DOFlexibleSize_s(IntPtr l) {
		try{
			UnityEngine.UI.LayoutElement a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOFlexibleSize(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOMinSize_s(IntPtr l) {
		try{
			UnityEngine.UI.LayoutElement a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOMinSize(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPreferredSize_s(IntPtr l) {
		try{
			UnityEngine.UI.LayoutElement a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOPreferredSize(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOScale_s(IntPtr l) {
		try{
			UnityEngine.UI.Outline a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOScale(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOAnchorPos_s(IntPtr l) {
		try{
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOAnchorPos(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOAnchorPos3D_s(IntPtr l) {
		try{
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOAnchorPos3D(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOSizeDelta_s(IntPtr l) {
		try{
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOSizeDelta(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOValue_s(IntPtr l) {
		try{
			UnityEngine.UI.Slider a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			DG.Tweening.Tweener ret=DG.Tweening.ShortcutExtensions.DOValue(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.ShortcutExtensions");
		addMember(l,DOFade_s);
		addMember(l,DOColor_s);
		addMember(l,DOFlexibleSize_s);
		addMember(l,DOMinSize_s);
		addMember(l,DOPreferredSize_s);
		addMember(l,DOScale_s);
		addMember(l,DOAnchorPos_s);
		addMember(l,DOAnchorPos3D_s);
		addMember(l,DOSizeDelta_s);
		addMember(l,DOValue_s);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.ShortcutExtensions));
	}
}
