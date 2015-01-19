using System;
using System.Collections.Generic;

namespace iOS4Unity
{
	public sealed class NSNotificationCenter : NSObject
	{
		private const string SelectorName = "__onNotification:";
		private static readonly IntPtr _classHandle;

		private class Observer : NSObject
		{
			private static readonly IntPtr _classHandle;
			
			static Observer()
			{
				_classHandle = ObjC.AllocateClassPair(ObjC.GetClass("NSObject"), "__Observer", 0);
			}
			
			public override IntPtr ClassHandle
			{
				get { return _classHandle; }
			}

			public Observer(Action<NSNotification> action)
			{
				Action = action;
			}

			public readonly Action<NSNotification> Action;

            public override void Dispose()
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(this);

                base.Dispose();
            }
		}

		static NSNotificationCenter()
		{
			_classHandle = ObjC.GetClass("NSNotificationCenter");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}
		
        private NSNotificationCenter(IntPtr handle) : base(handle) { }

		public static NSNotificationCenter DefaultCenter
		{
			get { return new NSNotificationCenter(ObjC.MessageSendIntPtr(_classHandle, "defaultCenter")); }
		}

		public NSObject AddObserver(string name, Action<NSNotification> action, NSObject fromObject = null)
		{
			var handler = new Observer(action);
			Callbacks.Subscribe(handler, SelectorName, n => action(new NSNotification(n)));
			ObjC.MessageSend(Handle, "addObserver:selector:name:object:", handler.Handle, ObjC.GetSelector(SelectorName), name, fromObject == null ? IntPtr.Zero : fromObject.Handle); 
			return handler;
		}

		public void PostNotificationName(string name, NSObject obj = null)
		{
			ObjC.MessageSend(Handle, "postNotificationName:object:", name, obj == null ? IntPtr.Zero : obj.Handle);
		}

		public void RemoveObserver(NSObject observer)
		{
			ObjC.MessageSend(Handle, "removeObserver:", observer.Handle);
		}
	}
}
