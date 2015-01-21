using System;

namespace iOS4Unity
{
    public class SKProductsRequest : NSObject
    {
        private static readonly IntPtr _classHandle;

        static SKProductsRequest()
        {
            _classHandle = ObjC.GetClass("SKProductsRequest");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public SKProductsRequest(params string[] productIds)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithProductIdentifiers:", ObjC.ToNSSet(productIds));
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public void Cancel()
        {
            ObjC.MessageSend(Handle, "cancel");
        }

        public void Start()
        {
            ObjC.MessageSend(Handle, "start");
        }

        public event EventHandler<EventArgs<SKProductsResponse>> ReceivedResponse
        {
            add { Callbacks.Subscribe(this, "productsRequest:didReceiveResponse:", value); }
            remove { Callbacks.Unsubscribe(this, "productsRequest:didReceiveResponse:", value); }
        }

        public event EventHandler<EventArgs<NSError>> RequestFailed
        {
            add { Callbacks.Subscribe(this, "request:didFailWithError:", value); }
            remove { Callbacks.Unsubscribe(this, "request:didFailWithError:", value); }
        }

        public event EventHandler RequestFinished
        {
            add { Callbacks.Subscribe(this, "requestDidFinish:", value); }
            remove { Callbacks.Unsubscribe(this, "requestDidFinish:", value); }
        }
    }
}