using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_Vector3ArrayOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_axisConstraint(IntPtr l) {
		DG.Tweening.Plugins.Options.Vector3ArrayOptions o = (DG.Tweening.Plugins.Options.Vector3ArrayOptions)checkSelf(l);
		pushValue(l,o.axisConstraint);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_axisConstraint(IntPtr l) {
		DG.Tweening.Plugins.Options.Vector3ArrayOptions o = (DG.Tweening.Plugins.Options.Vector3ArrayOptions)checkSelf(l);
		DG.Tweening.AxisConstraint v;
		checkEnum(l,2,out v);
		o.axisConstraint=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_snapping(IntPtr l) {
		DG.Tweening.Plugins.Options.Vector3ArrayOptions o = (DG.Tweening.Plugins.Options.Vector3ArrayOptions)checkSelf(l);
		pushValue(l,o.snapping);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_snapping(IntPtr l) {
		DG.Tweening.Plugins.Options.Vector3ArrayOptions o = (DG.Tweening.Plugins.Options.Vector3ArrayOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.snapping=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.Vector3ArrayOptions");
		addMember(l,"axisConstraint",get_axisConstraint,set_axisConstraint,true);
		addMember(l,"snapping",get_snapping,set_snapping,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.Vector3ArrayOptions));
	}
}
