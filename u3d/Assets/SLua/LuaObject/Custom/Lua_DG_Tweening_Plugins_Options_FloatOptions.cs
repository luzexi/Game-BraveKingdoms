using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_FloatOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_snapping(IntPtr l) {
		DG.Tweening.Plugins.Options.FloatOptions o = (DG.Tweening.Plugins.Options.FloatOptions)checkSelf(l);
		pushValue(l,o.snapping);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_snapping(IntPtr l) {
		DG.Tweening.Plugins.Options.FloatOptions o = (DG.Tweening.Plugins.Options.FloatOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.snapping=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.FloatOptions");
		addMember(l,"snapping",get_snapping,set_snapping,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.FloatOptions));
	}
}
