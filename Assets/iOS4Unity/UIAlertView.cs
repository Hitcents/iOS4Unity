using System;
using AOT;
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

		private EventHandler<EventArgs<int>> _clicked = delegate { };
		private EventHandler<EventArgs<int>> _dismissed = delegate { };
		private EventHandler<EventArgs<int>> _willDismiss = delegate { };
		private EventHandler _canceled = delegate { };
		private EventHandler _presented = delegate { };
		private EventHandler _willPresent = delegate { };

		public event EventHandler<EventArgs<int>> Clicked
		{
			add
			{
				Callbacks.SubscribeIntPtrInt(this, "alertView:clickedButtonAtIndex:", (_, i) => _clicked(this, new EventArgs<int> { Value = i }));
				_clicked += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtrInt(this);
				_clicked -= value;
			}
		}

		public event EventHandler<EventArgs<int>> Dismissed
		{
			add
			{
				Callbacks.SubscribeIntPtrInt(this, "alertView:didDismissWithButtonIndex:", (_, i) => _dismissed(this, new EventArgs<int> { Value = i }));
				_dismissed += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtrInt(this);
				_dismissed -= value;
			}
		}

		public event EventHandler<EventArgs<int>> WillDismiss
		{
			add
			{
				Callbacks.SubscribeIntPtrInt(this, "alertView:willDismissWithButtonIndex:", (_, i) => _willDismiss(this, new EventArgs<int> { Value = i }));
				_willDismiss += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtrInt(this);
				_willDismiss -= value;
			}
		}

		public event EventHandler Canceled
		{
			add
			{
				Callbacks.SubscribeIntPtr(this, "alertViewCancel:", _ => _canceled(this, EventArgs.Empty));
				_canceled += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtr(this);
				_canceled -= value;
			}
		}

		public event EventHandler Presented
		{
			add
			{
				Callbacks.SubscribeIntPtr(this, "didPresentAlertView:", _ => _presented(this, EventArgs.Empty));
				_presented += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtr(this);
				_presented -= value;
			}
		}

		public event EventHandler WillPresent
		{
			add
			{
				Callbacks.SubscribeIntPtr(this, "willPresentAlertView:", _ => _willPresent(this, EventArgs.Empty));
				_willPresent += value;
			}
			remove
			{
				Callbacks.UnsubscribeIntPtr(this);
				_willPresent -= value;
			}
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

		public override void Dispose ()
		{
			base.Dispose ();

			Callbacks.UnsubscribeAll(this);
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
