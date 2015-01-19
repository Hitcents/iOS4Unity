using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace iOS4Unity
{
	public class UIAlertView : NSObject 
	{
		private static readonly IntPtr _classHandle;

		static UIAlertView()
		{
			_classHandle = ObjC.GetClass("UIAlertView");
		}

		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}

		public UIAlertView()
		{
			ObjC.MessageSendIntPtr(Handle, "init");
			ObjC.MessageSend(Handle, "setDelegate:", Handle);
		}

		public event EventHandler<EventArgs<int>> Clicked
		{
			add { Callbacks.Subscribe(this, "alertView:clickedButtonAtIndex:", value); }
			remove { Callbacks.UnsubscribeInt(this, "alertView:clickedButtonAtIndex:"); }
		}

		public event EventHandler<EventArgs<int>> Dismissed
		{
			add { Callbacks.Subscribe(this, "alertView:didDismissWithButtonIndex:", value); }
			remove { Callbacks.UnsubscribeInt(this, "alertView:didDismissWithButtonIndex:"); }
		}

		public event EventHandler<EventArgs<int>> WillDismiss
		{
			add { Callbacks.Subscribe(this, "alertView:willDismissWithButtonIndex:", value); }
			remove { Callbacks.UnsubscribeInt(this, "alertView:willDismissWithButtonIndex:"); }
		}

		public event EventHandler Canceled
		{
			add { Callbacks.Subscribe(this, "alertViewCancel:", value); }
			remove { Callbacks.Unsubscribe(this, "alertViewCancel:"); }
		}

		public event EventHandler Presented
		{
			add { Callbacks.Subscribe(this, "didPresentAlertView:", value); }
			remove { Callbacks.Unsubscribe(this, "didPresentAlertView:"); }
		}

		public event EventHandler WillPresent
		{
			add { Callbacks.Subscribe(this, "willPresentAlertView:", value); }
			remove { Callbacks.Unsubscribe(this, "willPresentAlertView:"); }
		}

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
	}

	public enum UIAlertViewStyle
	{
		Default,
		SecureTextInput,
		PlainTextInput,
		LoginAndPasswordInput
	}
}
