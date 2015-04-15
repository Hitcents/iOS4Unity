iOS4Unity - Native iOS APIs from C#
=========

iOS4Unity is a Unity plugin that finally brings native iOS APIs to C# using only managed code -- with no Objective-C libraries involved! iOS4Unity takes advantage of the core C functions that comprise the building blocks of Objective-C to expose native iOS APIs to C#. iOS4Unity also provides native callbacks to C# without using UnitySendMessage that is completed supported under AOT! 

Download [here](https://www.assetstore.unity3d.com/en/#!/content/28817) on the Unity Asset Store.

APIs Included
--------
- UIAlertView and UIActionSheet - for displaying native popups 
- UIApplication and UILocalNotification - Local and remote notifications
- UIDevice, NSLocal, and UIScreen - for native iOS settings 
- Native iAds - direct access to ADBannerView 
- UIView, UIWindow, and UIViewController - for working with native views 
- IAPs through StoreKit - for simplified in-app purchases 
- Setup third party Obj-C libraries for use from C# - bind libraries missing a Unity plugin! 

Coming Soon
--------
- Game Center
- Full callback support for Obj-C blocks (none are implemented currently)
- Coroutines where applicable (if this is even possible)

Disclaimer
--------
- iOS4Unity is not trying to cover the entire iOS API surface area or compete with Xamarin.iOS. We are merely trying to expose frequently used native iOS APIs to game developers who are using Unity. Who wants to write Objective-C?
- Being meant for game developers, iOS4Unity is lightweight and meant for simple scenarios. We don't want to support things like: inheritance, subclassing native objects, cross-thread UI checks, etc.
