using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Core_PathCore_Path : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.lua_remove(l,1);
		DG.Tweening.Plugins.Core.PathCore.Path o;
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Core.PathCore.Path");
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Core.PathCore.Path));
	}
}
