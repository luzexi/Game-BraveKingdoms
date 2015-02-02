using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_AutoPlay : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.AutoPlay");
		addMember(l,0,"None");
		addMember(l,1,"AutoPlaySequences");
		addMember(l,2,"AutoPlayTweeners");
		addMember(l,3,"All");
		LuaDLL.lua_pop(l, 1);
	}
}
