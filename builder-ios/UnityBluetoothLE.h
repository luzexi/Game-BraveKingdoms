//
//  UnityBluetoothLE.h
//  Unity-iPhone
//
//  Created by Tony Pitman on 03/05/2014.
//
//

#import <Foundation/Foundation.h>
#import <CoreBluetooth/CoreBluetooth.h>

@interface UnityBluetoothLE : NSObject <CBCentralManagerDelegate, CBPeripheralManagerDelegate, CBPeripheralDelegate>

{
    CBCentralManager *_centralManager;
    
    NSMutableDictionary *_peripherals;
    NSMutableDictionary *_peripheralCharacteristics;
    
    CBPeripheralManager *_peripheralManager;
    
    NSString *_peripheralName;
    
    NSMutableDictionary *_services;
    NSMutableDictionary *_characteristics;
    
    NSMutableArray *_backgroundMessages;
    BOOL _isPaused;
    BOOL _alreadyNotified;
    BOOL _isInitializing;
}

@property (atomic, strong) NSMutableDictionary *_peripherals;

- (void)initialize:(BOOL)asCentral asPeripheral:(BOOL)asPeripheral;
- (void)deInitialize;
- (void)scanForPeripheralsWithServices:(NSArray *)serviceUUIDs options:(NSDictionary *)options;
- (void)stopScan;
- (void)retrieveListOfPeripheralsWithServices:(NSArray *)serviceUUIDs;
- (void)connectToPeripheral:(NSString *)name;
- (void)disconnectPeripheral:(NSString *)name;
- (void)readCharacteristic:(NSString *)name service:(NSString *)serviceString characteristic:(NSString *)characteristicString;
- (void)writeCharacteristic:(NSString *)name service:(NSString *)serviceString characteristic:(NSString *)characteristicString data:(NSData *)data withResponse:(BOOL)withResponse;
- (void)subscribeCharacteristic:(NSString *)name service:(NSString *)serviceString characteristic:(NSString *)characteristicString;
- (void)unsubscribeCharacteristic:(NSString *)name service:(NSString *)serviceString characteristic:(NSString *)characteristicString;
- (void)peripheralName:(NSString *)newName;
- (void)createService:(NSString *)uuid primary:(BOOL)primary;
- (void)removeService:(NSString *)uuid;
- (void)removeServices;
- (void)createCharacteristic:(NSString *)uuid properties:(CBCharacteristicProperties)properties permissions:(CBAttributePermissions)permissions value:(NSData *)value;
- (void)removeCharacteristic:(NSString *)uuid;
- (void)removeCharacteristics;
- (void)startAdvertising;
- (void)stopAdvertising;
- (void)updateCharacteristicValue:(NSString *)uuid value:(NSData *)value;
- (void)pauseMessages:(BOOL)isPaused;
- (void)sendUnityMessage:(BOOL)isString message:(NSString *)message;

+ (NSString *) base64StringFromData:(NSData *)data length:(int)length;

@end

@interface UnityMessage : NSObject

{
    BOOL _isString;
    NSString *_message;
}

- (void)initialize:(BOOL)isString message:(NSString *)message;
- (void)deInitialize;
- (void)sendUnityMessage;

@end
