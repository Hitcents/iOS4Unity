using System;

namespace iOS4Unity
{
    public class SKProduct : NSObject
    {
        private static readonly IntPtr _classHandle;

        static SKProduct()
        {
            _classHandle = ObjC.GetClass("SKProduct");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal SKProduct(IntPtr handle) : base(handle) { }

        public bool Downloadable
        {
            get { return ObjC.MessageSendBool(Handle, "isDownloadable"); }
        }

        public string LocalizedDescription
        {
            get { return ObjC.MessageSendString(Handle, "localizedDescription"); }
        }

        public string LocalizedTitle
        {
            get { return ObjC.MessageSendString(Handle, "localizedTitle"); }
        }

        public double Price
        {
            get { return ObjC.MessageSendDouble(ObjC.MessageSendIntPtr(Handle, "doubleValue"), "price"); }
        }

        public NSLocale PriceLocale
        {
            get { return new NSLocale(ObjC.MessageSendIntPtr(Handle, "priceLocale")); }
        }

        public string ProductIdentifier
        {
            get { return ObjC.MessageSendString(Handle, "productIdentifier"); }
        }

        public SKPaymentTransactionState TransactionState
        {
            get { return (SKPaymentTransactionState)ObjC.MessageSendInt(Handle, "transactionState"); }
        }
    }

    public enum SKPaymentTransactionState
    {
        Purchasing,
        Purchased,
        Failed,
        Restored,
        Deferred
    }
}
