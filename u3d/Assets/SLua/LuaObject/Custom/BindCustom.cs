using System;
namespace SLua {
	public partial class LuaObject {
		public static void BindCustom(IntPtr l) {
			Lua_iTween.reg(l);
			Lua_LuaUtil.reg(l);
			Lua_Custom.reg(l);
			Lua_Deleg.reg(l);
			Lua_HelloWorld.reg(l);
			Lua_UI_Event.reg(l);
		}
	}
}
