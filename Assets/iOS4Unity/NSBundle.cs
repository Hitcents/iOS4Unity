using System;

namespace iOS4Unity
{
    public class NSBundle : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSBundle()
        {
            _classHandle = ObjC.GetClass("NSBundle");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public NSBundle(IntPtr handle) : base(handle) { }

        public string BundleIdentifier
        {
            get { return ObjC.MessageSendString(Handle, "bundleIdentifier"); }
        }

        public string BundlePath
        {
            get { return ObjC.MessageSendString(Handle, "bundlePath"); }
        }

        public static NSBundle FromIdentifier(string str)
        {
            return new NSBundle(ObjC.MessageSendIntPtr(_classHandle, "bundleWithIdentifier:", str));
        }

        public static NSBundle FromPath(string path)
        {
            return new NSBundle(ObjC.MessageSendIntPtr(_classHandle, "bundleWithPath:", path));
        }

        public static NSBundle MainBundle
        {
            get { return new NSBundle(ObjC.MessageSendIntPtr(_classHandle, "mainBundle")); }
        }

        public string LocalizedString(string key, string value = "", string table = "")
        {
            return ObjC.MessageSendString(Handle, "localizedStringForKey:value:table:", key, value, table);
        }

        public string ResourcePath
        {
            get { return ObjC.MessageSendString(Handle, "resourcePath"); }
        }
    }
}
