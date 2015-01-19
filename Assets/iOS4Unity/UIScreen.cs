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

        public float Brightness
        {
            get { return ObjC.MessageSendFloat(Handle, "brightness"); }
            set { ObjC.MessageSendFloat(Handle, "setBrightness", value); }
        }

        public static UIScreen MainScreen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(_classHandle, "mainScreen")); }
        }
    }
}
