using System;
using AOT;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
	public class UIAlertView : NSObject 
	{
		private static readonly IntPtr _classHandle;
		private static readonly Dictionary<IntPtr, UIAlertView> _alertViews = new Dictionary<IntPtr, UIAlertView>();

		private static Action<IntPtr, IntPtr, IntPtr, int> _didDismiss;

		static UIAlertView()
		{
			_classHandle = ObjC.GetClass("UIAlertView");

			//Setup callbacks
			_didDismiss = DidDismiss;
			ObjC.AddMethod(_classHandle, ObjC.GetSelector ("alertView:didDismissWithButtonIndex:"), _didDismiss, "v@:@l");
		}

		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}

		private readonly IntPtr _handle;

		public override IntPtr Handle 
		{
			get { return _handle; }
		}

		public UIAlertView()
		{
			_handle = ObjC.MessageSendIntPtr(base.Handle, "init");
			_alertViews.Add(Handle, this);
			Delegate = this;
		}

		public event EventHandler<EventArgs<int>> Dismissed = delegate { };

		public int AddButton(string title)
		{
			IntPtr intPtr = ObjC.CreateNSString(title);
			int result = ObjC.MessageSendInt(Handle, "addButtonWithTitle:", intPtr);
			ObjC.MessageSend(intPtr, "release");
			return result;
		}

		public int ButtonCount
		{
			get { return ObjC.MessageSendInt(Handle, "numberOfButtons"); }
		}

		private NSObject Delegate
		{
			set { ObjC.MessageSend(Handle, "setDelegate:", value.Handle); }
		}

		public string Message
		{
			get
			{
				throw new NotImplementedException();
//				if (this.IsDirectBinding)
//				{
//					return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("message")));
//				}
//				return NSString.FromHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("message")));
			}
			set { ObjC.MessageSend(Handle, "setMessage:", value); }
		}

		public void Show()
		{
			ObjC.MessageSend(Handle, "show");
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void DidDismiss(IntPtr @this, IntPtr selector, IntPtr alertView, int buttonIndex)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.Dismissed(instance, new EventArgs<int> { Value = buttonIndex });
			}
		}

		public override void Dispose ()
		{
			base.Dispose ();

			_alertViews.Remove (Handle);
		}
	}
}
