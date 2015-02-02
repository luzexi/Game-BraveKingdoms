using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.TweenType");
		addMember(l,0,"Tweener");
		addMember(l,1,"Sequence");
		addMember(l,2,"Callback");
		LuaDLL.lua_pop(l, 1);
	}
}
