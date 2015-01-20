using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
    public class UIImage : NSObject
    {
        [DllImport("/System/Library/Frameworks/UIKit.framework/UIKit")]
        private static extern IntPtr UIImageJPEGRepresentation(IntPtr image, float compressionQuality);
        [DllImport("/System/Library/Frameworks/UIKit.framework/UIKit")]
        private static extern IntPtr UIImagePNGRepresentation(IntPtr image);

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

        public NSData AsJPEG(float compressionQuality = 1)
        {
            return new NSData(UIImageJPEGRepresentation(Handle, compressionQuality));
        }

        public NSData AsPNG()
        {
            return new NSData(UIImagePNGRepresentation(Handle));
        }

        public float CurrentScale
        {
            get { return ObjC.MessageSendFloat(Handle, "scale"); }
        }

        public static UIImage FromBundle(string name)
        {
            return new UIImage(ObjC.MessageSendIntPtr(_classHandle, "imageNamed:", name));
        }

        public static UIImage FromFile(string filename)
        {
            return new UIImage(ObjC.MessageSendIntPtr(_classHandle, "imageWithContentsOfFile:", filename));
        }

        public static UIImage LoadFromData(NSData data)
        {
            return new UIImage(ObjC.MessageSendIntPtr(_classHandle, "imageWithData:", data.Handle));
        }

        public static UIImage LoadFromData(NSData data, float scale)
        {
            return new UIImage(ObjC.MessageSendIntPtr(_classHandle, "imageWithData:scale:", data.Handle, scale));
        }

        public CGSize Size
        {
            get { return new CGSize(ObjC.MessageSendCGSize(Handle, "size")); }
        }
    }
}
