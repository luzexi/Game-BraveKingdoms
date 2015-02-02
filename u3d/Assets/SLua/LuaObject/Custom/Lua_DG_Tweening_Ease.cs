using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Ease : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.Ease");
		addMember(l,0,"Unset");
		addMember(l,1,"Linear");
		addMember(l,2,"InSine");
		addMember(l,3,"OutSine");
		addMember(l,4,"InOutSine");
		addMember(l,5,"InQuad");
		addMember(l,6,"OutQuad");
		addMember(l,7,"InOutQuad");
		addMember(l,8,"InCubic");
		addMember(l,9,"OutCubic");
		addMember(l,10,"InOutCubic");
		addMember(l,11,"InQuart");
		addMember(l,12,"OutQuart");
		addMember(l,13,"InOutQuart");
		addMember(l,14,"InQuint");
		addMember(l,15,"OutQuint");
		addMember(l,16,"InOutQuint");
		addMember(l,17,"InExpo");
		addMember(l,18,"OutExpo");
		addMember(l,19,"InOutExpo");
		addMember(l,20,"InCirc");
		addMember(l,21,"OutCirc");
		addMember(l,22,"InOutCirc");
		addMember(l,23,"InElastic");
		addMember(l,24,"OutElastic");
		addMember(l,25,"InOutElastic");
		addMember(l,26,"InBack");
		addMember(l,27,"OutBack");
		addMember(l,28,"InOutBack");
		addMember(l,29,"InBounce");
		addMember(l,30,"OutBounce");
		addMember(l,31,"InOutBounce");
		addMember(l,32,"INTERNAL_Zero");
		addMember(l,33,"INTERNAL_Custom");
		LuaDLL.lua_pop(l, 1);
	}
}
