using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_RotateMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.RotateMode");
		addMember(l,0,"Fast");
		addMember(l,1,"FastBeyond360");
		addMember(l,2,"WorldAxisAdd");
		addMember(l,3,"LocalAxisAdd");
		LuaDLL.lua_pop(l, 1);
	}
}
