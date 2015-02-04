using System;

namespace iOS4Unity
{
    public class NSMutableDictionary : NSDictionary
    {
        private static readonly IntPtr _classHandle;

        static NSMutableDictionary()
        {
            _classHandle = ObjC.GetClass("NSMutableDictionary");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal NSMutableDictionary (IntPtr handle) : base(handle) { }

        public NSMutableDictionary()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public new static NSMutableDictionary FromObjectAndKey(NSObject obj, string key)
        {
            IntPtr handle = ObjC.ToNSString(key);
            var dictionary = Runtime.GetNSObject<NSMutableDictionary>(ObjC.MessageSendIntPtr(_classHandle, "dictionaryWithObject:forKey:", obj.Handle, handle));
            ObjC.MessageSend(handle, "release");
            return dictionary;
        }

        public void Add(NSObject obj, string key)
        {
            IntPtr handle = ObjC.ToNSString(key);
            ObjC.MessageSendIntPtr(Handle, "setObject:forKey:", obj.Handle, handle);
            ObjC.MessageSend(handle, "release");
        }

        public void Remove(string key)
        {
            IntPtr handle = ObjC.ToNSString(key);
            ObjC.MessageSendIntPtr(Handle, "removeObjectForKey", handle);
            ObjC.MessageSend(handle, "release");
        }

        public void Clear()
        {
            ObjC.MessageSend(Handle, "removeAllObjects");
        }

        public override NSObject this[string key]
        {
            get { return ObjectForKey(key); }
            set { Add(value, key); }
        }
    }
}
