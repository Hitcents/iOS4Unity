using System;
using System.Collections;

namespace iOS4Unity
{
    public class UIScreenMode : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIScreenMode()
        {
            _classHandle = ObjC.GetClass("UIScreenMode");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        private UIScreenMode(IntPtr handle) : base(handle) { }

        public float PixelAspectRatio
        {
            get { return ObjC.MessageSendFloat( Handle, "pixelAspectRatio"); }
        }

        public CGSize Size
        {
            get{ return ObjC.MessageSendCGSize( Handle, "size"); }
        }
    }
}

