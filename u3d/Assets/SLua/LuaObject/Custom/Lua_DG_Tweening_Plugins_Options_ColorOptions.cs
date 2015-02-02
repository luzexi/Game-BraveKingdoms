using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_ColorOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alphaOnly(IntPtr l) {
		DG.Tweening.Plugins.Options.ColorOptions o = (DG.Tweening.Plugins.Options.ColorOptions)checkSelf(l);
		pushValue(l,o.alphaOnly);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alphaOnly(IntPtr l) {
		DG.Tweening.Plugins.Options.ColorOptions o = (DG.Tweening.Plugins.Options.ColorOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.alphaOnly=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.ColorOptions");
		addMember(l,"alphaOnly",get_alphaOnly,set_alphaOnly,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.ColorOptions));
	}
}
