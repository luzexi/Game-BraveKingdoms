using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_PathMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.PathMode");
		addMember(l,0,"Full3D");
		addMember(l,1,"TopDown2D");
		addMember(l,2,"Sidescroller2D");
		LuaDLL.lua_pop(l, 1);
	}
}
