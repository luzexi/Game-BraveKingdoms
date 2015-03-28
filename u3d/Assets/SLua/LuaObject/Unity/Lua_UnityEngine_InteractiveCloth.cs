using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_InteractiveCloth : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth o;
			o=new UnityEngine.InteractiveCloth();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddForceAtPosition(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ForceMode a4;
				checkEnum(l,5,out a4);
				self.AddForceAtPosition(a1,a2,a3,a4);
				return 0;
			}
			else if(argc==4){
				UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddForceAtPosition(a1,a2,a3);
				return 0;
			}
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AttachToCollider(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
				UnityEngine.Collider a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.AttachToCollider(a1,a2,a3);
				return 0;
			}
			else if(argc==3){
				UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
				UnityEngine.Collider a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.AttachToCollider(a1,a2);
				return 0;
			}
			else if(argc==2){
				UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
				UnityEngine.Collider a1;
				checkType(l,2,out a1);
				self.AttachToCollider(a1);
				return 0;
			}
			LuaDLL.luaL_error(l,"No matched override function to call");
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DetachFromCollider(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			UnityEngine.Collider a1;
			checkType(l,2,out a1);
			self.DetachFromCollider(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.mesh);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_friction(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.friction);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_friction(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.friction=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_density(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.density);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_density(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.density=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressure(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.pressure);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressure(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.pressure=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_collisionResponse(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.collisionResponse);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_collisionResponse(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.collisionResponse=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tearFactor(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.tearFactor);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tearFactor(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.tearFactor=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_attachmentTearFactor(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.attachmentTearFactor);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_attachmentTearFactor(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.attachmentTearFactor=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_attachmentResponse(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.attachmentResponse);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_attachmentResponse(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.attachmentResponse=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isTeared(IntPtr l) {
		try {
			UnityEngine.InteractiveCloth self=(UnityEngine.InteractiveCloth)checkSelf(l);
			pushValue(l,self.isTeared);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.InteractiveCloth");
		addMember(l,AddForceAtPosition);
		addMember(l,AttachToCollider);
		addMember(l,DetachFromCollider);
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"friction",get_friction,set_friction,true);
		addMember(l,"density",get_density,set_density,true);
		addMember(l,"pressure",get_pressure,set_pressure,true);
		addMember(l,"collisionResponse",get_collisionResponse,set_collisionResponse,true);
		addMember(l,"tearFactor",get_tearFactor,set_tearFactor,true);
		addMember(l,"attachmentTearFactor",get_attachmentTearFactor,set_attachmentTearFactor,true);
		addMember(l,"attachmentResponse",get_attachmentResponse,set_attachmentResponse,true);
		addMember(l,"isTeared",get_isTeared,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.InteractiveCloth),typeof(UnityEngine.Cloth));
	}
}
