using System;
namespace SLua {
	public partial class LuaObject {
		public static void BindCustom(IntPtr l) {
			Lua_GfxObject.reg(l);
			Lua_CBluetooth.reg(l);
			Lua_Network.reg(l);
			Lua_LuaUtil.reg(l);
			Lua_Custom.reg(l);
			Lua_Deleg.reg(l);
			Lua_HelloWorld.reg(l);
			Lua_UI_Event.reg(l);
			Lua_UI_FontNum.reg(l);
			Lua_UI_Scroll_List.reg(l);
			Lua_iTween.reg(l);
		}
	}
}
