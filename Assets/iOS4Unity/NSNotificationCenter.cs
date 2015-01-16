using System;
using System.Collections.Generic;
using AOT;

namespace iOS4Unity
{
	public sealed class NSNotificationCenter : NSObject
	{
		private const string SelectorName = "__onNotification:";
		private static readonly IntPtr _classHandle;
		private static readonly Dictionary<IntPtr, Observer> _observers = new Dictionary<IntPtr, Observer>();

		private class Observer : NSObject
		{
			private static readonly IntPtr _classHandle;
			
			static Observer()
			{
				_classHandle = ObjC.AllocateClassPair(ObjC.GetClass ("NSObject"), "__Observer", 0);
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
		}

		static NSNotificationCenter()
		{
			_classHandle = ObjC.GetClass("NSNotificationCenter");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}
		
		private NSNotificationCenter(IntPtr handle)
		{
			Handle = handle;
		}

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

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnNotification(IntPtr @this, IntPtr selector, IntPtr hNotification)
		{
			Observer observer;
			if (_observers.TryGetValue(@this, out observer))
			{
				var notification = new NSNotification(hNotification);
				observer.Action(notification);
			}
		}

		public override void Dispose()
		{
			//Doesn't need to release
		}
	}
}
