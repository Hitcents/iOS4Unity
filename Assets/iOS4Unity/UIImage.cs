using System;
using System.Collections;

namespace iOS4Unity
{
    public class UIImage : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIImage()
        {
            _classHandle = ObjC.GetClass("UIImage");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal UIImage(IntPtr handle) : base(handle) { }

        public static UIImage FromFile(string filename)
        {
            return new UIImage(ObjC.MessageSendIntPtr(_classHandle, "imageWithContentsOfFile:", filename));
        }

        public CGSize Size
        {
            get { return new CGSize(ObjC.MessageSendCGSize(Handle, "size")); }
        }
    }
}
