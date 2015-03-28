
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace SLua
{
    public partial class LuaObject
    {

        static internal int checkDelegate(IntPtr l,int p,out System.Action<UnityEngine.GameObject,System.Int32> ua) {
            int op = extractFunction(l,p);
			if(LuaDLL.lua_isnil(l,-1)) {
				ua=null;
				return op;
			}
            else if (LuaDLL.lua_isuserdata(l, p)==1)
            {
                ua = (System.Action<UnityEngine.GameObject,System.Int32>)checkObj(l, p);
                return op;
            }
            LuaDelegate ld;
            checkType(l, -1, out ld);
            if(ld.d!=null)
            {
                ua = (System.Action<UnityEngine.GameObject,System.Int32>)ld.d;
                return op;
            }
			LuaDLL.lua_pop(l,1);
            ua = (UnityEngine.GameObject a1,int a2) =>
            {
                int error = pushTry(l);

				pushValue(l,a1);
				pushValue(l,a2);
				ld.call(2, error);
				LuaDLL.lua_settop(l, error-1);
			};
			ld.d=ua;
			return op;
		}
	}
}
