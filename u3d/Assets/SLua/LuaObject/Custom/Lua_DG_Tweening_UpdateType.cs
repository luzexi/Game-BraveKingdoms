using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_UpdateType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.UpdateType");
		addMember(l,0,"Normal");
		addMember(l,1,"Late");
		addMember(l,2,"Fixed");
		LuaDLL.lua_pop(l, 1);
	}
}
