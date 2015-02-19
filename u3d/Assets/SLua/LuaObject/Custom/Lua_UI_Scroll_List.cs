using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UI_Scroll_List : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		UI_Scroll_List o;
		o=new UI_Scroll_List();
		pushObject(l,o);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init(IntPtr l) {
		try{
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
		try{
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
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushEnum(l,(int)o.moveType);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_moveType(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		UI_Scroll_List.Movement v;
		checkEnum(l,2,out v);
		o.moveType=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxSpeed(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.MaxSpeed);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxSpeed(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.MaxSpeed=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinFixSpeed(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.MinFixSpeed);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MinFixSpeed(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.MinFixSpeed=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxIndex(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.MaxIndex);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxIndex(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.MaxIndex=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxFixPos(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.MaxFixPos);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxFixPos(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.MaxFixPos=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MinFixPos(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.MinFixPos);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MinFixPos(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.MinFixPos=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemNum(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.ItemNum);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemNum(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.ItemNum=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ItemCost(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		pushValue(l,o.ItemCost);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ItemCost(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Int32 v;
		checkType(l,2,out v);
		o.ItemCost=v;
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onChange(IntPtr l) {
		UI_Scroll_List o = (UI_Scroll_List)checkSelf(l);
		System.Action<UnityEngine.GameObject,System.Int32> v;
		int op=checkDelegate(l,2,out v);
		if(op==0) o.onChange=v;
		else if(op==1) o.onChange+=v;
		else if(op==2) o.onChange-=v;
		return 0;
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
		createTypeMetatable(l,constructor, typeof(UI_Scroll_List),typeof(UnityEngine.MonoBehaviour));
	}
}
