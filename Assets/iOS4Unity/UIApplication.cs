﻿using System;
using System.Collections.Generic;

namespace iOS4Unity
{
    public class UIApplication : NSObject
    {
        private static readonly IntPtr _classHandle;

        private Dictionary<object, IntPtrHandler2>  _failed;

        static UIApplication()
        {
            _classHandle = ObjC.GetClass("UIApplication");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal UIApplication(IntPtr handle) : base(handle)
        {
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public event EventHandler DidBecomeActive
        {
            add { Callbacks.Subscribe(this, "applicationDidBecomeActive:", value); }
            remove { Callbacks.Unsubscribe(this, "applicationDidBecomeActive:", value); }
        }

        public event EventHandler WillResignActive
        {
            add { Callbacks.Subscribe(this, "applicationWillResignActive:", value); }
            remove { Callbacks.Unsubscribe(this, "applicationWillResignActive:", value); }
        }

        public event EventHandler WillEnterForeground
        {
            add { Callbacks.Subscribe(this, "applicationWillEnterForeground:", value); }
            remove { Callbacks.Unsubscribe(this, "applicationWillEnterForeground:", value); }
        }

        public event EventHandler WillTerminate
        {
            add { Callbacks.Subscribe(this, "applicationWillTerminate:", value); }
            remove { Callbacks.Unsubscribe(this, "applicationWillTerminate:", value); }
        }

        public event EventHandler DidReceiveMemoryWarning
        {
            add { Callbacks.Subscribe(this, "applicationDidReceiveMemoryWarning:", value); }
            remove { Callbacks.Unsubscribe(this, "applicationDidReceiveMemoryWarning:", value); }
        }

        public event EventHandler<NSErrorEventArgs> FailedToRegisterForRemoteNotifications
        {
            add 
            { 
                if (_failed == null)
                    _failed = new Dictionary<object, IntPtrHandler2>();
                IntPtrHandler2 callback = (_, i) => value(this, new NSErrorEventArgs { Error = Runtime.GetNSObject<NSError>(i) });
                _failed[value] = callback;
                Callbacks.Subscribe(this, "application:didFailToRegisterForRemoteNotificationsWithError:", callback); 
            } 
            remove 
            { 
                IntPtrHandler2 callback;
                if (_failed != null && _failed.TryGetValue(value, out callback))
                {
                    _failed.Remove(value);
                    Callbacks.Unsubscribe(this, "application:didFailToRegisterForRemoteNotificationsWithError:", callback); 
                }
            }
        }

        public static UIApplication SharedApplication
        {
            get { return Runtime.GetNSObject<UIApplication>(ObjC.MessageSendIntPtr(_classHandle, "sharedApplication")); }
        }

        public static string DidBecomeActiveNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationDidBecomeActiveNotification"); }
        }

        public static string DidEnterBackgroundNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationDidEnterBackgroundNotification"); }
        }

        public static string DidFinishLaunchingNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationDidFinishLaunchingNotification"); }
        }

        public static string DidReceiveMemoryWarningNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationDidReceiveMemoryWarningNotification"); }
        }

        public static string WillEnterForegroundNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationWillEnterForegroundNotification"); }
        }

        public static string WillResignActiveNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIApplicationWillResignActiveNotification"); }
        }

        public UIWindow KeyWindow
        {
            get { return Runtime.GetNSObject<UIWindow>(ObjC.MessageSendIntPtr(Handle, "keyWindow")); }
        }

        public UIWindow[] Windows
        {
            get { return ObjC.FromNSArray<UIWindow>(ObjC.MessageSendIntPtr(Handle, "windows")); }
        }

        public int ApplicationIconBadgeNumber
        {
            get { return ObjC.MessageSendInt(Handle, "applicationIconBadgeNumber"); }
            set { ObjC.MessageSend(Handle, "setApplicationIconBadgeNumber:", value); }
        }

        public UIApplicationState ApplicationState
        {
            get { return (UIApplicationState)ObjC.MessageSendInt(Handle, "applicationState"); }
        }

        public UIStatusBarStyle StatusBarStyle
        {
            get { return (UIStatusBarStyle)ObjC.MessageSendInt(Handle, "statusBarStyle"); }
            set { ObjC.MessageSend(Handle, "setStatusBarStyle:", (int)value); }
        }

        public bool StatusBarHidden
        {
            get { return ObjC.MessageSendBool(Handle, "isStatusBarHidden"); }
            set { ObjC.MessageSend(Handle, "setStatusBarHidden:", value); }
        }

        public bool NetworkActivityIndicatorVisible
        {
            get { return ObjC.MessageSendBool(Handle, "isNetworkActivityIndicatorVisible"); }
            set { ObjC.MessageSend(Handle, "setNetworkActivityIndicatorVisible:", value); }
        }

        public bool IdleTimerDisabled
        {
            get { return ObjC.MessageSendBool(Handle, "isIdleTimerDisabled"); }
            set { ObjC.MessageSend(Handle, "setIdleTimerDisabled:", value); }
        }

        public void SetStatusBarHidden(bool hidden, bool animated = true)
        {
            ObjC.MessageSend(Handle, "setStatusBarHidden:animated:", hidden, animated);
        }

        public bool CanOpenUrl(string url)
        {
            return ObjC.MessageSendBool_NSUrl(Handle, "canOpenURL:", url);
        }

        public bool OpenUrl(string url)
        {
            return ObjC.MessageSendBool_NSUrl(Handle, "openURL:", url);
        }

        public void RegisterForRemoteNotificationTypes(UIRemoteNotificationType types)
        {
            ObjC.MessageSend(Handle, "registerForRemoteNotificationTypes:", (int)types);
        }

        public void UnregisterForRemoteNotifications()
        {
            ObjC.MessageSend(Handle, "unregisterForRemoteNotifications");
        }
    }

    public enum UIApplicationState
    {
        Active,
        Inactive,
        Background
    }

    [Flags]
    public enum UIRemoteNotificationType
    {
        None = 0,
        Badge = 1,
        Sound = 2,
        Alert = 4,
        NewsstandContentAvailability = 8
    }

    public enum UIStatusBarStyle
    {
        Default,
        BlackTranslucent,
        LightContent = 1,
        BlackOpaque
    }
}
