using System;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
    public class NSData : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSData()
        {
            _classHandle = ObjC.GetClass("NSData");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal NSData(IntPtr handle) : base(handle) { }

        public unsafe static NSData FromArray(byte[] buffer)
        {
            if (buffer.Length == 0)
            {
                return NSData.FromBytes(IntPtr.Zero, 0);
            }
            fixed (void* ptr = &buffer[0])
            {
                return NSData.FromBytes((IntPtr)ptr, (uint)buffer.Length);
            }
        }

        public static NSData FromBytes(IntPtr bytes, uint size)
        {
            return new NSData(ObjC.MessageSendIntPtr(_classHandle, "dataWithBytes:length:", bytes, size));
        }

        public static NSData FromData(NSData source)
        {
            return new NSData(ObjC.MessageSendIntPtr(_classHandle, "dataWithData:", source.Handle));
        }

        public static NSData FromUrl(string url)
        {
            return new NSData(ObjC.MessageSendIntPtr_NSUrl(_classHandle, "dataWithContentsOfURL:", url));
        }
    }
}