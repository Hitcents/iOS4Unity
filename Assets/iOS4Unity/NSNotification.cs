using System;

namespace iOS4Unity
{
    public class NSNotification : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSNotification()
        {
            _classHandle = ObjC.GetClass("NSNotification");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public static NSNotification FromName(string name, NSObject obj = null)
        {
            return Runtime.GetNSObject<NSNotification>(ObjC.MessageSendIntPtr(_classHandle, "notificationWithName:object:", name, obj == null ? IntPtr.Zero : obj.Handle));
        }

        internal NSNotification(IntPtr handle)
            : base(handle)
        {
        }

        public string Name
        {
            get { return ObjC.MessageSendString(Handle, "name"); }
        }

        public NSObject Object
        {
            get { return Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "object")); }
        }
    }
}