using System;
using System.Collections.Generic;

namespace iOS4Unity
{
    public class SKPaymentQueue : NSObject 
    {
        private static readonly IntPtr _classHandle;

        static SKPaymentQueue()
        {
            _classHandle = ObjC.GetClass("SKPaymentQueue");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        private readonly Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>> _restoreFailed = new Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>>();
        private readonly Dictionary<EventHandler<EventArgs<NSObject[]>>, Action<IntPtr, IntPtr>> _updatedTransactions = new Dictionary<EventHandler<EventArgs<NSObject[]>>, Action<IntPtr, IntPtr>>();

        private SKPaymentQueue(IntPtr handle) : base(handle) 
        { 
            ObjC.MessageSend(Handle, "addTransactionObserver:", Handle);
        }

        public static bool CanMakePayments
        {
            get { return ObjC.MessageSendBool(_classHandle, "canMakePayments"); }
        }

        public SKPaymentTransaction[] Transactions
        {
            get { return ObjC.FromNSArray<SKPaymentTransaction>(ObjC.MessageSendIntPtr(Handle, "transactions")); }
        }

        public static SKPaymentQueue DefaultQueue
        {
            get { return new SKPaymentQueue(ObjC.MessageSendIntPtr(_classHandle, "defaultQueue")); }
        }

        public event EventHandler RestoreCompleted
        {
            add { Callbacks.Subscribe(this, "paymentQueueRestoreCompletedTransactionsFinished:", value); } 
            remove { Callbacks.Unsubscribe(this, "paymentQueueRestoreCompletedTransactionsFinished:", value); }
        }

        public event EventHandler<EventArgs<NSError>> RestoreFailed
        {
            add 
            { 
                Action<IntPtr, IntPtr> callback = (_, i) => value(this, new EventArgs<NSError> { Value = new NSError(i) });
                _restoreFailed[value] = callback;
                Callbacks.Subscribe(this, "paymentQueue:restoreCompletedTransactionsFailedWithError:", callback); 
            } 
            remove 
            { 
                Action<IntPtr, IntPtr> callback;
                if (_restoreFailed.TryGetValue(value, out callback))
                {
                    _restoreFailed.Remove(value);
                    Callbacks.Unsubscribe(this, "paymentQueue:restoreCompletedTransactionsFailedWithError:", callback); 
                }
            }
        }

        public event EventHandler<EventArgs<NSObject[]>> UpdatedTransactions
        {
            add
            {
                Action<IntPtr, IntPtr> callback = (_, i) => value(this, new EventArgs<NSObject[]> { Value = ObjC.FromNSArray<NSObject>(i) });
                _updatedTransactions[value] = callback;
                Callbacks.Subscribe(this, "paymentQueue:updatedTransactions:", callback);
            }
            remove
            {
                Action<IntPtr, IntPtr> callback;
                if (_updatedTransactions.TryGetValue(value, out callback))
                {
                    _updatedTransactions.Remove(value);
                    Callbacks.Unsubscribe(this, "paymentQueue:updatedTransactions:", callback);
                }
            }
        }

        public void AddPayment(SKPayment payment)
        {
            ObjC.MessageSend(Handle, "addPayment:", payment.Handle);
        }

        public void RestoreCompletedTransactions()
        {
            ObjC.MessageSend(Handle, "restoreCompletedTransactions");
        }

        public void FinishTransaction(SKPaymentTransaction transaction)
        {
            ObjC.MessageSend(Handle, "finishTransaction:", transaction.Handle);
        }

        public override void Dispose()
        {
            ObjC.MessageSend(Handle, "removeTransactionObserver:", Handle);

            base.Dispose();

            _restoreFailed.Clear();
            _updatedTransactions.Clear();
        }
    }
}
