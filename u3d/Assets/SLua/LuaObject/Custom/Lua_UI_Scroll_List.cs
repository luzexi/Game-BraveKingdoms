using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UI_Scroll_List : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			self.Init();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddDragEvent(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			self.AddDragEvent(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_moveType(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushEnum(l,(int)self.moveType);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_moveType(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			UI_Scroll_List.Movement v;
			checkEnum(l,2,out v);
			self.moveType=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxSpeed(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.MaxSpeed);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxSpeed(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MaxSpeed=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinFixSpeed(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.MinFixSpeed);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MinFixSpeed(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.MinFixSpeed=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxIndex(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.MaxIndex);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxIndex(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.MaxIndex=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxFixPos(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.MaxFixPos);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxFixPos(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.MaxFixPos=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinFixPos(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.MinFixPos);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MinFixPos(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.MinFixPos=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemNum(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.ItemNum);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemNum(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.ItemNum=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemCost(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			pushValue(l,self.ItemCost);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemCost(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.ItemCost=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onChange(IntPtr l) {
		try {
			UI_Scroll_List self=(UI_Scroll_List)checkSelf(l);
			System.Action<UnityEngine.GameObject,System.Int32> v;
			int op=checkDelegate(l,2,out v);
			if(op==0) self.onChange=v;
			else if(op==1) self.onChange+=v;
			else if(op==2) self.onChange-=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UI_Scroll_List");
		addMember(l,Init);
		addMember(l,AddDragEvent);
		addMember(l,"moveType",get_moveType,set_moveType,true);
		addMember(l,"MaxSpeed",get_MaxSpeed,set_MaxSpeed,true);
		addMember(l,"MinFixSpeed",get_MinFixSpeed,set_MinFixSpeed,true);
		addMember(l,"MaxIndex",get_MaxIndex,set_MaxIndex,true);
		addMember(l,"MaxFixPos",get_MaxFixPos,set_MaxFixPos,true);
		addMember(l,"MinFixPos",get_MinFixPos,set_MinFixPos,true);
		addMember(l,"ItemNum",get_ItemNum,set_ItemNum,true);
		addMember(l,"ItemCost",get_ItemCost,set_ItemCost,true);
		addMember(l,"onChange",null,set_onChange,true);
		createTypeMetatable(l,null, typeof(UI_Scroll_List),typeof(UnityEngine.MonoBehaviour));
	}
}
