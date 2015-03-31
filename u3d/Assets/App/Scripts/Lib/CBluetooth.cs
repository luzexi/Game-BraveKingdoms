
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  CBluetooth.cs
//  Author : Lu Zexi
//  2015-03-31


//blue tooth
[CustomLuaClassAttribute]
public class CBluetooth
{
    public static BluetoothDeviceScript Initialize(bool asCentral, bool asPeripheral, Action action, Action<string> errorAction)
    {
        return BluetoothLEHardwareInterface.Initialize(asCentral, asPeripheral, action, errorAction);
    }

    public static void DeInitialize(Action action)
    {
        BluetoothLEHardwareInterface.DeInitialize(action);
    }

    public static void FinishDeInitialize()
    {
        BluetoothLEHardwareInterface.FinishDeInitialize();
    }

    public static void PauseMessages(bool isPaused)
    {
        BluetoothLEHardwareInterface.PauseMessages(isPaused);
    }

    public static void ScanForPeripheralsWithServices(string[] serviceUUIDs, Action<string, string> action)
    {
        BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(serviceUUIDs, action);
    }

    public static void RetrieveListOfPeripheralsWithServices(string[] serviceUUIDs, Action<string, string> action)
    {
        BluetoothLEHardwareInterface.RetrieveListOfPeripheralsWithServices(serviceUUIDs, action);
    }

    public static void StopScan()
    {
        BluetoothLEHardwareInterface.StopScan();
    }

    public static void ConnectToPeripheral(string name, Action<string> connectAction, Action<string, string> serviceAction, Action<string, string, string> characteristicAction)
    {
        BluetoothLEHardwareInterface.ConnectToPeripheral(name, connectAction, serviceAction, characteristicAction);
    }

    public static void DisconnectPeripheral(string name, Action<string> action)
    {
        BluetoothLEHardwareInterface.DisconnectPeripheral(name, action);
    }

    public static void ReadCharacteristic(string name, string service, string characteristic, Action<string, byte[]> action)
    {
        BluetoothLEHardwareInterface.ReadCharacteristic(name, service, characteristic, action);
    }

    public static void WriteCharacteristic(string name, string service, string characteristic, byte[] data, int length, bool withResponse, Action<string> action)
    {
        BluetoothLEHardwareInterface.WriteCharacteristic(name, service, characteristic, data, length, withResponse, action);
    }

    public static void SubscribeCharacteristic(string name, string service, string characteristic, Action<string> notificationAction, Action<string, byte[]> action)
    {
        BluetoothLEHardwareInterface.SubscribeCharacteristic(name, service, characteristic, notificationAction, action);
    }

    public static void UnSubscribeCharacteristic(string name, string service, string characteristic, Action<string> action)
    {
        BluetoothLEHardwareInterface.UnSubscribeCharacteristic(name, service, characteristic, action);
    }

    public static void PeripheralName(string newName)
    {
        BluetoothLEHardwareInterface.PeripheralName(newName);
    }

    public static void CreateService(string uuid, bool primary, Action<string> action)
    {
        BluetoothLEHardwareInterface.CreateService(uuid, primary, action);
    }

    public static void RemoveService(string uuid)
    {
        BluetoothLEHardwareInterface.RemoveService(uuid);
    }

    public static void RemoveServices()
    {
        BluetoothLEHardwareInterface.RemoveServices();
    }

    public static void CreateCharacteristic(string uuid, BluetoothLEHardwareInterface.CBCharacteristicProperties properties, BluetoothLEHardwareInterface.CBAttributePermissions permissions, byte[] data, int length, Action<string, byte[]> action)
    {
        BluetoothLEHardwareInterface.CreateCharacteristic(uuid, properties, permissions, data, length, action);
    }

    public static void RemoveCharacteristic(string uuid)
    {
        BluetoothLEHardwareInterface.RemoveCharacteristic(uuid);
    }

    public static void RemoveCharacteristics()
    {
        BluetoothLEHardwareInterface.RemoveCharacteristics();
    }

    public static void StartAdvertising(Action action)
    {
        BluetoothLEHardwareInterface.StartAdvertising(action);
    }

    public static void StopAdvertising(Action action)
    {
        BluetoothLEHardwareInterface.StopAdvertising(action);
    }

    public static void UpdateCharacteristicValue(string uuid, byte[] data, int length)
    {
        BluetoothLEHardwareInterface.UpdateCharacteristicValue(uuid, data, length);
    }

}
