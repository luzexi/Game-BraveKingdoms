using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Renderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Renderer o;
			o=new UnityEngine.Renderer();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetPropertyBlock(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.MaterialPropertyBlock a1;
			checkType(l,2,out a1);
			self.SetPropertyBlock(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPropertyBlock(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.MaterialPropertyBlock a1;
			checkType(l,2,out a1);
			self.GetPropertyBlock(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Render(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.Render(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPartOfStaticBatch(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.isPartOfStaticBatch);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_worldToLocalMatrix(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.worldToLocalMatrix);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_localToWorldMatrix(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.localToWorldMatrix);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.enabled);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_castShadows(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.castShadows);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_castShadows(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.castShadows=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_receiveShadows(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.receiveShadows);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_receiveShadows(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.receiveShadows=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.material);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.sharedMaterial);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.sharedMaterial=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sharedMaterials(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.sharedMaterials);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sharedMaterials(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Material[] v;
			checkType(l,2,out v);
			self.sharedMaterials=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_materials(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.materials);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_materials(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Material[] v;
			checkType(l,2,out v);
			self.materials=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bounds(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.bounds);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightmapIndex(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.lightmapIndex);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightmapIndex(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.lightmapIndex=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightmapTilingOffset(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.lightmapTilingOffset);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightmapTilingOffset(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.lightmapTilingOffset=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isVisible(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.isVisible);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useLightProbes(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.useLightProbes);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useLightProbes(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useLightProbes=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lightProbeAnchor(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.lightProbeAnchor);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lightProbeAnchor(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.lightProbeAnchor=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingLayerName(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.sortingLayerName);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingLayerName(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.sortingLayerName=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingLayerID(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.sortingLayerID);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingLayerID(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.sortingLayerID=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingOrder(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			pushValue(l,self.sortingOrder);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingOrder(IntPtr l) {
		try {
			UnityEngine.Renderer self=(UnityEngine.Renderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.sortingOrder=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Renderer");
		addMember(l,SetPropertyBlock);
		addMember(l,GetPropertyBlock);
		addMember(l,Render);
		addMember(l,"isPartOfStaticBatch",get_isPartOfStaticBatch,null,true);
		addMember(l,"worldToLocalMatrix",get_worldToLocalMatrix,null,true);
		addMember(l,"localToWorldMatrix",get_localToWorldMatrix,null,true);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"castShadows",get_castShadows,set_castShadows,true);
		addMember(l,"receiveShadows",get_receiveShadows,set_receiveShadows,true);
		addMember(l,"material",get_material,set_material,true);
		addMember(l,"sharedMaterial",get_sharedMaterial,set_sharedMaterial,true);
		addMember(l,"sharedMaterials",get_sharedMaterials,set_sharedMaterials,true);
		addMember(l,"materials",get_materials,set_materials,true);
		addMember(l,"bounds",get_bounds,null,true);
		addMember(l,"lightmapIndex",get_lightmapIndex,set_lightmapIndex,true);
		addMember(l,"lightmapTilingOffset",get_lightmapTilingOffset,set_lightmapTilingOffset,true);
		addMember(l,"isVisible",get_isVisible,null,true);
		addMember(l,"useLightProbes",get_useLightProbes,set_useLightProbes,true);
		addMember(l,"lightProbeAnchor",get_lightProbeAnchor,set_lightProbeAnchor,true);
		addMember(l,"sortingLayerName",get_sortingLayerName,set_sortingLayerName,true);
		addMember(l,"sortingLayerID",get_sortingLayerID,set_sortingLayerID,true);
		addMember(l,"sortingOrder",get_sortingOrder,set_sortingOrder,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Renderer),typeof(UnityEngine.Component));
	}
}
