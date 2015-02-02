using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_OrientType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.Plugins.Options.OrientType");
		addMember(l,0,"None");
		addMember(l,1,"ToPath");
		addMember(l,2,"LookAtTransform");
		addMember(l,3,"LookAtPosition");
		LuaDLL.lua_pop(l, 1);
	}
}
