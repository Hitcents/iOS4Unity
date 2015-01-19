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

        private UIScreen(IntPtr handle) : base(handle) { }

        public CGRect ApplicationFrame
        {
            get { return ObjC.MessageSendCGRect(Handle, "applicationFrame"); }
        }

        public CGRect Bounds
        {
            get { return ObjC.MessageSendCGRect(Handle, "bounds"); }
        }

        public float Brightness
        {
            get { return ObjC.MessageSendFloat(Handle, "brightness"); }
            set { ObjC.MessageSendFloat(Handle, "setBrightness", value); }
        }

        public UIScreenMode CurrentMode
        {
            get { return new UIScreenMode(ObjC.MessageSendIntPtr(Handle, "currentMode")); }
            set { ObjC.MessageSend(Handle, "setCurrentMode", value.Handle); }
        }

        public static UIScreen MainScreen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(_classHandle, "mainScreen")); }
        }

        public UIScreen MirroredScreen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(Handle, "mirroredScreen")); }
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

        public float Scale
        {
            get { return ObjC.MessageSendFloat(Handle, "scale"); }
        }

        public bool WantsSoftwareDimming
        {
            get { return ObjC.MessageSendBool(Handle, "wantsSoftwareDimming"); }
            set{ ObjC.MessageSendBool(Handle, "setWantsSoftwareDimming", value); }
        }

        public UIScreenMode[] AvailableModes
        {
            get { return ObjC.ArrayFromHandle<UIScreenMode>(ObjC.MessageSendIntPtr(Handle, "availableModes")); }
        }
    }
}
