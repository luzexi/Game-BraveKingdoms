using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CBluetooth : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CBluetooth o;
			o=new CBluetooth();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Log_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			CBluetooth.Log(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Initialize_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			System.Action a3;
			checkDelegate(l,3,out a3);
			System.Action<System.String> a4;
			checkDelegate(l,4,out a4);
			BluetoothDeviceScript ret=CBluetooth.Initialize(a1,a2,a3,a4);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DeInitialize_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			CBluetooth.DeInitialize(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FinishDeInitialize_s(IntPtr l) {
		try {
			CBluetooth.FinishDeInitialize();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PauseMessages_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			CBluetooth.PauseMessages(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ScanForPeripheralsWithServices_s(IntPtr l) {
		try {
			System.String[] a1;
			checkType(l,1,out a1);
			System.Action<System.String,System.String> a2;
			checkDelegate(l,2,out a2);
			CBluetooth.ScanForPeripheralsWithServices(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RetrieveListOfPeripheralsWithServices_s(IntPtr l) {
		try {
			System.String[] a1;
			checkType(l,1,out a1);
			System.Action<System.String,System.String> a2;
			checkDelegate(l,2,out a2);
			CBluetooth.RetrieveListOfPeripheralsWithServices(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int StopScan_s(IntPtr l) {
		try {
			CBluetooth.StopScan();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ConnectToPeripheral_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<System.String> a2;
			checkDelegate(l,2,out a2);
			System.Action<System.String,System.String> a3;
			checkDelegate(l,3,out a3);
			System.Action<System.String,System.String,System.String> a4;
			checkDelegate(l,4,out a4);
			CBluetooth.ConnectToPeripheral(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DisconnectPeripheral_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<System.String> a2;
			checkDelegate(l,2,out a2);
			CBluetooth.DisconnectPeripheral(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReadCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Action<System.String,System.Byte[]> a4;
			checkDelegate(l,4,out a4);
			CBluetooth.ReadCharacteristic(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Byte[] a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Boolean a6;
			checkType(l,6,out a6);
			System.Action<System.String> a7;
			checkDelegate(l,7,out a7);
			CBluetooth.WriteCharacteristic(a1,a2,a3,a4,a5,a6,a7);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SubscribeCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Action<System.String> a4;
			checkDelegate(l,4,out a4);
			System.Action<System.String,System.String> a5;
			checkDelegate(l,5,out a5);
			CBluetooth.SubscribeCharacteristic(a1,a2,a3,a4,a5);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnSubscribeCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Action<System.String> a4;
			checkDelegate(l,4,out a4);
			CBluetooth.UnSubscribeCharacteristic(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PeripheralName_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			CBluetooth.PeripheralName(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateService_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			System.Action<System.String> a3;
			checkDelegate(l,3,out a3);
			CBluetooth.CreateService(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveService_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			CBluetooth.RemoveService(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveServices_s(IntPtr l) {
		try {
			CBluetooth.RemoveServices();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			BluetoothLEHardwareInterface.CBCharacteristicProperties a2;
			checkEnum(l,2,out a2);
			BluetoothLEHardwareInterface.CBAttributePermissions a3;
			checkEnum(l,3,out a3);
			System.Byte[] a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Action<System.String,System.Byte[]> a6;
			checkDelegate(l,6,out a6);
			CBluetooth.CreateCharacteristic(a1,a2,a3,a4,a5,a6);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateReadCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Action<System.String,System.String> a3;
			checkDelegate(l,3,out a3);
			CBluetooth.CreateReadCharacteristic(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateWriteCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Action<System.String,System.String> a3;
			checkDelegate(l,3,out a3);
			CBluetooth.CreateWriteCharacteristic(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveCharacteristic_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			CBluetooth.RemoveCharacteristic(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveCharacteristics_s(IntPtr l) {
		try {
			CBluetooth.RemoveCharacteristics();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int StartAdvertising_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			CBluetooth.StartAdvertising(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int StopAdvertising_s(IntPtr l) {
		try {
			System.Action a1;
			checkDelegate(l,1,out a1);
			CBluetooth.StopAdvertising(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateCharacteristicValue_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			CBluetooth.UpdateCharacteristicValue(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CBluetooth");
		addMember(l,Log_s);
		addMember(l,Initialize_s);
		addMember(l,DeInitialize_s);
		addMember(l,FinishDeInitialize_s);
		addMember(l,PauseMessages_s);
		addMember(l,ScanForPeripheralsWithServices_s);
		addMember(l,RetrieveListOfPeripheralsWithServices_s);
		addMember(l,StopScan_s);
		addMember(l,ConnectToPeripheral_s);
		addMember(l,DisconnectPeripheral_s);
		addMember(l,ReadCharacteristic_s);
		addMember(l,WriteCharacteristic_s);
		addMember(l,SubscribeCharacteristic_s);
		addMember(l,UnSubscribeCharacteristic_s);
		addMember(l,PeripheralName_s);
		addMember(l,CreateService_s);
		addMember(l,RemoveService_s);
		addMember(l,RemoveServices_s);
		addMember(l,CreateCharacteristic_s);
		addMember(l,CreateReadCharacteristic_s);
		addMember(l,CreateWriteCharacteristic_s);
		addMember(l,RemoveCharacteristic_s);
		addMember(l,RemoveCharacteristics_s);
		addMember(l,StartAdvertising_s);
		addMember(l,StopAdvertising_s);
		addMember(l,UpdateCharacteristicValue_s);
		createTypeMetatable(l,constructor, typeof(CBluetooth));
	}
}
