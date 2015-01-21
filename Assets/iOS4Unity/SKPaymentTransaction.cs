using System;

namespace iOS4Unity
{
    public class SKPaymentTransaction : NSObject
    {
        private static readonly IntPtr _classHandle;

        static SKPaymentTransaction()
        {
            _classHandle = ObjC.GetClass("SKPaymentTransaction");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        internal SKPaymentTransaction(IntPtr handle) : base(handle) { }

        public NSError Error
        {
            get 
            { 
                IntPtr handle = ObjC.MessageSendIntPtr(Handle, "error");
                return handle == IntPtr.Zero ? null : new NSError(handle); 
            }
        }

        public SKPaymentTransaction OriginalTransaction
        {
            get 
            { 
                IntPtr handle = ObjC.MessageSendIntPtr(Handle, "originalTransaction");
                return handle == IntPtr.Zero ? null : new SKPaymentTransaction(handle); 
            }
        }

        public DateTime TransactionDate
        {
            get { return ObjC.FromNSDate(ObjC.MessageSendIntPtr(Handle, "transactionDate")); }
        }

        public string TransactionIdentifier
        {
            get { return ObjC.MessageSendString(Handle, "transactionIdentifier"); }
        }
    }
}
