﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_ABSSequentiable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.ABSSequentiable");
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Core.ABSSequentiable));
	}
}
