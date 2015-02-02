using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_StringOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scramble(IntPtr l) {
		DG.Tweening.Plugins.Options.StringOptions o = (DG.Tweening.Plugins.Options.StringOptions)checkSelf(l);
		pushValue(l,o.scramble);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scramble(IntPtr l) {
		DG.Tweening.Plugins.Options.StringOptions o = (DG.Tweening.Plugins.Options.StringOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.scramble=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrambledChars(IntPtr l) {
		DG.Tweening.Plugins.Options.StringOptions o = (DG.Tweening.Plugins.Options.StringOptions)checkSelf(l);
		pushValue(l,o.scrambledChars);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrambledChars(IntPtr l) {
		DG.Tweening.Plugins.Options.StringOptions o = (DG.Tweening.Plugins.Options.StringOptions)checkSelf(l);
		System.Char[] v;
		checkType(l,2,out v);
		o.scrambledChars=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.StringOptions");
		addMember(l,"scramble",get_scramble,set_scramble,true);
		addMember(l,"scrambledChars",get_scrambledChars,set_scrambledChars,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.StringOptions));
	}
}
