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

		public UIAlertView()
		{
			ObjC.MessageSendIntPtr(Handle, "init");
			_alertViews.Add(Handle, this);
			ObjC.MessageSend(Handle, "setDelegate:", Handle);
		}

		public event EventHandler<EventArgs<int>> Dismissed = delegate { };

		public UIAlertViewStyle AlertViewStyle
		{
			get { return (UIAlertViewStyle)ObjC.MessageSendInt(Handle, "alertViewStyle"); }
			set { ObjC.MessageSend(Handle, "setAlertViewStyle:", (int)value); }
		}

		public int AddButton(string title)
		{
			return ObjC.MessageSendInt(Handle, "addButtonWithTitle:", title);
		}

		public int ButtonCount
		{
			get { return ObjC.MessageSendInt(Handle, "numberOfButtons"); }
		}

		public int CancelButtonIndex
		{
			get { return ObjC.MessageSendInt (Handle, "cancelButtonIndex"); }
			set { ObjC.MessageSend(Handle, "setCancelButtonIndex:", value); }
		}

		public int FirstOtherButtonIndex
		{
			get { return ObjC.MessageSendInt(Handle, "firstOtherButtonIndex"); }
		}

		public string ButtonTitle(int index)
		{
			return ObjC.MessageSendString(Handle, "buttonTitleAtIndex:", index);
		}

		public bool Visible
		{
			get { return ObjC.MessageSendBool(Handle, "isVisible"); }
		}

		public string Message
		{
			get { return ObjC.MessageSendString(Handle, "message"); }
			set { ObjC.MessageSend(Handle, "setMessage:", value); }
		}

		public string Title
		{
			get { return ObjC.MessageSendString(Handle, "title"); }
			set { ObjC.MessageSend(Handle, "setTitle:", value); }
		}

		public void Show()
		{
			ObjC.MessageSend(Handle, "show");
		}

		public void Dismiss(int buttonIndex, bool animated = true)
		{
			ObjC.MessageSend(Handle, "dismissWithClickedButtonIndex:animated:", buttonIndex, animated);
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

	public enum UIAlertViewStyle
	{
		Default,
		SecureTextInput,
		PlainTextInput,
		LoginAndPasswordInput
	}
}
