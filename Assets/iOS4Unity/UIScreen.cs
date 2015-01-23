using System;
using System.Collections;

namespace iOS4Unity
{
    public class UIScreen : NSObject 
    {
        private static readonly IntPtr _classHandle;

        static UIScreen()
        {
            _classHandle = ObjC.GetClass("UIScreen");
        }
        
        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal UIScreen(IntPtr handle) : base(handle) { }

        public CGRect ApplicationFrame
        {
            get { return ObjC.MessageSendCGRect(Handle, "applicationFrame"); }
        }

        public UIScreenMode[] AvailableModes
        {
            get { return ObjC.FromNSArray<UIScreenMode>(ObjC.MessageSendIntPtr(Handle, "availableModes")); }
        }

        public CGRect Bounds
        {
            get { return ObjC.MessageSendCGRect(Handle, "bounds"); }
        }

        public float Brightness
        {
            get { return ObjC.MessageSendFloat(Handle, "brightness"); }
            set { ObjC.MessageSend(Handle, "setBrightness", value); }
        }

        public static string BrightnessDidChangeNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIScreenBrightnessDidChangeNotification"); }
        }

        public UIScreenMode CurrentMode
        {
            get { return new UIScreenMode(ObjC.MessageSendIntPtr(Handle, "currentMode")); }
            set { ObjC.MessageSend(Handle, "setCurrentMode", value.Handle); }
        }
            
        public static string DidConnectNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIScreenDidConnectNotification"); }
        }

        public static string DidDisconnectNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIScreenDidDisconnectNotification"); }
        }

        public static UIScreen MainScreen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(_classHandle, "mainScreen")); }
        }

        public UIScreen MirroredScreen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(Handle, "mirroredScreen")); }
        }

        public static string ModeDidChangeNotification
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.UIKit, "UIScreenModeDidChangeNotification"); }
        }

        /// <summary>
        /// iOS 8 only
        /// </summary>
        public CGRect NativeBounds
        {
            get { return ObjC.MessageSendCGRect(Handle, "nativeBounds"); }
        }

        /// <summary>
        /// iOS 8 only
        /// </summary>
        public float NativeScale
        {
            get { return ObjC.MessageSendFloat(Handle, "nativeScale"); }
        }

        public UIScreenMode PreferredMode
        {
            get { return new UIScreenMode(ObjC.MessageSendIntPtr(Handle, "preferredMode")); }
        }

        public float Scale
        {
            get { return ObjC.MessageSendFloat(Handle, "scale"); }
        }

        public static UIScreen[] Screens
        {
            get { return ObjC.FromNSArray<UIScreen>(ObjC.MessageSendIntPtr(_classHandle, "screens")); }
        }

        public bool WantsSoftwareDimming
        {
            get { return ObjC.MessageSendBool(Handle, "wantsSoftwareDimming"); }
            set{ ObjC.MessageSend(Handle, "setWantsSoftwareDimming", value); }
        }
    }
}
