using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_PathOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		LuaDLL.luaL_error(l,"New object failed.");
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.mode);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mode(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		DG.Tweening.PathMode v;
		checkEnum(l,2,out v);
		o.mode=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_orientType(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.orientType);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_orientType(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		DG.Tweening.Plugins.Options.OrientType v;
		checkEnum(l,2,out v);
		o.orientType=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lockPositionAxis(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.lockPositionAxis);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lockPositionAxis(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		DG.Tweening.AxisConstraint v;
		checkEnum(l,2,out v);
		o.lockPositionAxis=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lockRotationAxis(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.lockRotationAxis);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lockRotationAxis(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		DG.Tweening.AxisConstraint v;
		checkEnum(l,2,out v);
		o.lockRotationAxis=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isClosedPath(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.isClosedPath);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isClosedPath(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.isClosedPath=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAtPosition(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.lookAtPosition);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAtPosition(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		UnityEngine.Vector3 v;
		checkType(l,2,out v);
		o.lookAtPosition=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAtTransform(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.lookAtTransform);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAtTransform(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		UnityEngine.Transform v;
		checkType(l,2,out v);
		o.lookAtTransform=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAhead(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.lookAhead);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAhead(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		System.Single v;
		checkType(l,2,out v);
		o.lookAhead=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hasCustomForwardDirection(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.hasCustomForwardDirection);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hasCustomForwardDirection(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.hasCustomForwardDirection=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forward(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.forward);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forward(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		UnityEngine.Quaternion v;
		checkType(l,2,out v);
		o.forward=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useLocalPosition(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.useLocalPosition);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useLocalPosition(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		System.Boolean v;
		checkType(l,2,out v);
		o.useLocalPosition=v;
		setBack(l,o);
		return 0;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_parent(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		pushValue(l,o.parent);
		return 1;
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_parent(IntPtr l) {
		DG.Tweening.Plugins.Options.PathOptions o = (DG.Tweening.Plugins.Options.PathOptions)checkSelf(l);
		UnityEngine.Transform v;
		checkType(l,2,out v);
		o.parent=v;
		setBack(l,o);
		return 0;
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.PathOptions");
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"orientType",get_orientType,set_orientType,true);
		addMember(l,"lockPositionAxis",get_lockPositionAxis,set_lockPositionAxis,true);
		addMember(l,"lockRotationAxis",get_lockRotationAxis,set_lockRotationAxis,true);
		addMember(l,"isClosedPath",get_isClosedPath,set_isClosedPath,true);
		addMember(l,"lookAtPosition",get_lookAtPosition,set_lookAtPosition,true);
		addMember(l,"lookAtTransform",get_lookAtTransform,set_lookAtTransform,true);
		addMember(l,"lookAhead",get_lookAhead,set_lookAhead,true);
		addMember(l,"hasCustomForwardDirection",get_hasCustomForwardDirection,set_hasCustomForwardDirection,true);
		addMember(l,"forward",get_forward,set_forward,true);
		addMember(l,"useLocalPosition",get_useLocalPosition,set_useLocalPosition,true);
		addMember(l,"parent",get_parent,set_parent,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.PathOptions));
	}
}
