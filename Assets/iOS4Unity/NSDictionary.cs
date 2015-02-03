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
    }
}
