using System;

namespace iOS4Unity
{
    public class UIApplication : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIApplication()
        {
            _classHandle = ObjC.GetClass("UIApplication");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        private UIApplication(IntPtr handle) : base(handle) { }

        public static UIApplication SharedApplication
        {
            get { return new UIApplication(ObjC.MessageSendIntPtr(_classHandle, "sharedApplication")); }
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
            get { return new UIWindow(ObjC.MessageSendIntPtr(Handle, "keyWindow")); }
        }

        public UIWindow[] Windows
        {
            get { return ObjC.ArrayFromHandle<UIWindow>(ObjC.MessageSendIntPtr(Handle, "windows")); }
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
            set { ObjC.MessageSendBool(Handle, "setStatusBarHidden:", value); }
        }

        public bool NetworkActivityIndicatorVisible
        {
            get { return ObjC.MessageSendBool(Handle, "isNetworkActivityIndicatorVisible"); }
            set { ObjC.MessageSendBool(Handle, "setNetworkActivityIndicatorVisible:", value); }
        }

        public bool IdleTimerDisabled
        {
            get { return ObjC.MessageSendBool(Handle, "isIdleTimerDisabled"); }
            set { ObjC.MessageSendBool(Handle, "setIdleTimerDisabled:", value); }
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
