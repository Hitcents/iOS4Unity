using System;

namespace iOS4Unity
{
    public sealed class SKProductsResponse : NSObject
    {
        private static readonly IntPtr _classHandle;

        static SKProductsResponse()
        {
            _classHandle = ObjC.GetClass("SKProductsResponse");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal SKProductsResponse(IntPtr handle) : base(handle) { }

        public string[] InvalidProducts
        {
            get { return ObjC.FromNSArray(ObjC.MessageSendIntPtr(Handle, "invalidProductIdentifiers")); }
        }

        public SKProduct[] Products
        {
            get { return ObjC.FromNSArray<SKProduct>(ObjC.MessageSendIntPtr(Handle, "products")); }
        }
    }
}
