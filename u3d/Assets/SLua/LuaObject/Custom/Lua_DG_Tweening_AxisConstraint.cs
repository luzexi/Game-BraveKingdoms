using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_AxisConstraint : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.AxisConstraint");
		addMember(l,0,"None");
		addMember(l,2,"X");
		addMember(l,4,"Y");
		addMember(l,8,"Z");
		addMember(l,16,"W");
		LuaDLL.lua_pop(l, 1);
	}
}
