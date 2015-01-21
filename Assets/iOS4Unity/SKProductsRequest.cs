using System;
using System.Collections.Generic;

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

        private readonly Dictionary<EventHandler<EventArgs<SKProductsResponse>>, Action<IntPtr, IntPtr>> _receivedResponse = new Dictionary<EventHandler<EventArgs<SKProductsResponse>>, Action<IntPtr, IntPtr>>();
        private readonly Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>> _failed = new Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>>();

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
            add 
            { 
                Action<IntPtr, IntPtr> callback = (_, i) => value(this, new EventArgs<SKProductsResponse> { Value = new SKProductsResponse(i) });
                _receivedResponse[value] = callback;
                Callbacks.Subscribe(this, "productsRequest:didReceiveResponse:", callback); 
            } 
            remove 
            { 
                Action<IntPtr, IntPtr> callback;
                if (_receivedResponse.TryGetValue(value, out callback))
                {
                    _receivedResponse.Remove(value);
                    Callbacks.Unsubscribe(this, "productsRequest:didReceiveResponse:", callback); 
                }
            }
        }

        public event EventHandler<EventArgs<NSError>> Failed
        {
            add 
            { 
                Action<IntPtr, IntPtr> callback = (_, i) => value(this, new EventArgs<NSError> { Value = new NSError(i) });
                _failed[value] = callback;
                Callbacks.Subscribe(this, "request:didFailWithError:", callback); 
            } 
            remove 
            { 
                Action<IntPtr, IntPtr> callback;
                if (_failed.TryGetValue(value, out callback))
                {
                    _failed.Remove(value);
                    Callbacks.Unsubscribe(this, "request:didFailWithError:", callback); 
                }
            }
        }

        public event EventHandler Finished
        {
            add { Callbacks.Subscribe(this, "requestDidFinish:", value); }
            remove { Callbacks.Unsubscribe(this, "requestDidFinish:", value); }
        }
    }
}