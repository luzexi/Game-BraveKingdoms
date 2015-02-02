using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_DOTweenComponent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.Core.DOTweenComponent o;
		if(matchType(l,1)){
			o=new DG.Tweening.Core.DOTweenComponent();
			pushObject(l,o);
			return 1;
		}
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCapacity(IntPtr l) {
		try{
			DG.Tweening.Core.DOTweenComponent self=(DG.Tweening.Core.DOTweenComponent)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			DG.Tweening.IDOTweenInit ret=self.SetCapacity(a1,a2);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inspectorUpdater(IntPtr l) {
		DG.Tweening.Core.DOTweenComponent o = (DG.Tweening.Core.DOTweenComponent)checkSelf(l);
		pushValue(l,o.inspectorUpdater);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inspectorUpdater(IntPtr l) {
		DG.Tweening.Core.DOTweenComponent o = (DG.Tweening.Core.DOTweenComponent)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.inspectorUpdater=v;
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.DOTweenComponent");
		addMember(l,SetCapacity);
		addMember(l,"inspectorUpdater",get_inspectorUpdater,set_inspectorUpdater,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Core.DOTweenComponent),typeof(UnityEngine.MonoBehaviour));
	}
}
