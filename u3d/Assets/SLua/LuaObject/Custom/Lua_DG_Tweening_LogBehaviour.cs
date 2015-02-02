using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_LogBehaviour : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.LogBehaviour");
		addMember(l,0,"Default");
		addMember(l,1,"Verbose");
		addMember(l,2,"ErrorsOnly");
		LuaDLL.lua_pop(l, 1);
	}
}
