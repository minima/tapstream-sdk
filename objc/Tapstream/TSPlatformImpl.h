#pragma once
#import <Foundation/Foundation.h>
#import "TSPlatform.h"
#import "TSResponse.h"

@interface TSPlatformImpl : NSObject<TSPlatform> {}

- (NSString *)loadUuid;
- (NSMutableSet *)loadFiredEvents;
- (void)saveFiredEvents:(NSMutableSet *)firedEvents;
- (NSString *)getResolution;
- (NSString *)getManufacturer;
- (NSString *)getModel;
- (NSString *)getOs;
- (NSString *)getLocale;
- (NSString *)getWifiMac;
#if !(TARGET_OS_IPHONE || TARGET_IPHONE_SIMULATOR)
- (NSString *)getSerialNumber;
#endif
- (NSString *)getAppName;
- (NSString *)getPackageName;
- (TSResponse *)request:(NSString *)url data:(NSString *)data;

@end