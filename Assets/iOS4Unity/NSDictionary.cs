using System;

namespace iOS4Unity 
{
    public class NSDictionary : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSDictionary()
        {
            _classHandle = ObjC.GetClass("NSDictionary");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal NSDictionary (IntPtr handle) : base(handle) { }

        public NSDictionary()
        {
            Handle = ObjC.MessageSendIntPtr(Handle, "init");
        }

        public static NSDictionary FromDictionary(NSDictionary dictionary)
        {
            var newDictionary = NSDictionary.FromObjectsAndKeys(dictionary.Values, dictionary.Keys);
            return newDictionary;
        }

        public static NSDictionary FromObjectAndKey(NSObject obj, string key)
        {
            IntPtr handle = ObjC.ToNSString(key);
            var dictionary = Runtime.GetNSObject<NSDictionary>(ObjC.MessageSendIntPtr(_classHandle, "dictionaryWithObject:forKey:", obj.Handle, handle));
            ObjC.MessageSend(handle, "release");
            return dictionary;
        }

        public static NSDictionary FromObjectsAndKeys(NSObject[] objs, string[] keys)
        {
            var objectsHandle = ObjC.ToNSArray(objs);
            var keysHandle = ObjC.ToNSArray(keys);
            var dictionary = Runtime.GetNSObject<NSDictionary>(ObjC.MessageSendIntPtr(_classHandle, "dictionaryWithObjects:forKeys:", objectsHandle, keysHandle));
            ObjC.ReleaseNSArrayItems(keysHandle);
            return dictionary;
        }

        public NSObject ObjectForKey(string key)
        {
            IntPtr handle = ObjC.ToNSString(key);
            var value = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "objectForKey:", handle));
            ObjC.MessageSend(handle, "release");
            return value;
        }

        public NSObject[] ObjectsForKeys(string[] keys)
        {
            var keysHandle = ObjC.ToNSArray(keys);
            var arrayPtr = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "objectsForKeys:notFoundMarker:", keysHandle, new NSObject().Handle));
            var array = ObjC.FromNSArray<NSObject>(arrayPtr.Handle);
            ObjC.ReleaseNSArrayItems(keysHandle);
            return array;
        }

        public string[] KeysForObject(NSObject obj)
        {
            var array = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "allKeysForObject:", obj.Handle));
            return ObjC.FromNSArray(array.Handle);
        }

        public virtual NSObject this[string key]
        {
            get { return ObjectForKey(key); }
            set { throw new NotSupportedException(); }
        }

        public uint Count
        {
            get { return ObjC.MessageSendUInt(Handle, "count"); }
        }

        public string[] Keys
        {
            get
            {
                var array = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "allKeys"));
                return ObjC.FromNSArray(array.Handle);
            }
        }

        public NSObject[] Values
        {
            get
            {
                var array = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "allValues"));
                return ObjC.FromNSArray<NSObject>(array.Handle);
            }
        }

        public static NSDictionary FromFile(string path)
        {
            return Runtime.GetNSObject<NSDictionary>(ObjC.MessageSendIntPtr(_classHandle, "dictionaryWithContentsOfFile:", path));
        }

        public bool ContainsKey(string key)
        {
            return ObjectForKey(key) != null;
        }
    }
}
