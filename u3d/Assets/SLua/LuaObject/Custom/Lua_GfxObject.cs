using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_GfxObject : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Awake(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.Awake();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Start(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.Start();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Destory(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.Destory();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Update(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.Update();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsDieOrIdle(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			System.Boolean ret=self.IsDieOrIdle();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AttackState(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			GfxObject a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			System.Int32 a4;
			checkType(l,5,out a4);
			System.Single[] a5;
			checkType(l,6,out a5);
			System.Single[] a6;
			checkType(l,7,out a6);
			System.Single[] a7;
			checkType(l,8,out a7);
			System.Action<System.Int32,System.Int32,System.Single,System.Boolean> a8;
			checkDelegate(l,9,out a8);
			System.Action<System.Int32> a9;
			checkDelegate(l,10,out a9);
			System.Boolean a10;
			checkType(l,11,out a10);
			self.AttackState(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IdleState(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.IdleState();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MoveState(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.MoveState(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HurtState(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.HurtState();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SkillState(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			self.SkillState();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_m_cStateControl(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.m_cStateControl);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_m_cStateControl(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			StateControl v;
			checkType(l,2,out v);
			self.m_cStateControl=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_m_cAni(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.m_cAni);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_m_cAni(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			UnityEngine.Animation v;
			checkType(l,2,out v);
			self.m_cAni=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Hp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.Hp);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Hp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.Hp=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxHp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.MaxHp);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxHp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.MaxHp=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Mp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.Mp);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Mp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.Mp=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_MaxMp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.MaxMp);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_MaxMp(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.MaxMp=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Atk(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.Atk);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Atk(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.Atk=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Def(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.Def);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Def(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.Def=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Hit(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			pushValue(l,self.Hit);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Hit(IntPtr l) {
		try {
			GfxObject self=(GfxObject)checkSelf(l);
			XorInt v;
			checkType(l,2,out v);
			self.Hit=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"GfxObject");
		addMember(l,Awake);
		addMember(l,Start);
		addMember(l,Destory);
		addMember(l,Update);
		addMember(l,IsDieOrIdle);
		addMember(l,AttackState);
		addMember(l,IdleState);
		addMember(l,MoveState);
		addMember(l,HurtState);
		addMember(l,SkillState);
		addMember(l,"m_cStateControl",get_m_cStateControl,set_m_cStateControl,true);
		addMember(l,"m_cAni",get_m_cAni,set_m_cAni,true);
		addMember(l,"Hp",get_Hp,set_Hp,true);
		addMember(l,"MaxHp",get_MaxHp,set_MaxHp,true);
		addMember(l,"Mp",get_Mp,set_Mp,true);
		addMember(l,"MaxMp",get_MaxMp,set_MaxMp,true);
		addMember(l,"Atk",get_Atk,set_Atk,true);
		addMember(l,"Def",get_Def,set_Def,true);
		addMember(l,"Hit",get_Hit,set_Hit,true);
		createTypeMetatable(l,null, typeof(GfxObject),typeof(UnityEngine.MonoBehaviour));
	}
}
