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

		#pragma warning disable 414
		private static Action<IntPtr, IntPtr, IntPtr, int> _onClicked, _onDismissed, _onWillDismiss;
		private static Action<IntPtr, IntPtr, IntPtr> _onCanceled, _onPresented, _onWillPresent;
		#pragma warning restore 414

		static UIAlertView()
		{
			_classHandle = ObjC.GetClass("UIAlertView");

			//Setup callbacks
			ObjC.AddMethod(_classHandle, "alertViewCancel:", _onCanceled = OnCanceled, "v@:@");
			ObjC.AddMethod(_classHandle, "alertView:clickedButtonAtIndex:", _onClicked = OnClicked, "v@:@l");
			ObjC.AddMethod(_classHandle, "alertView:didDismissWithButtonIndex:", _onDismissed = OnDismissed, "v@:@l");
			ObjC.AddMethod(_classHandle, "didPresentAlertView:", _onPresented = OnPresented, "v@:@");
			ObjC.AddMethod(_classHandle, "alertView:willDismissWithButtonIndex:", _onWillDismiss = OnWillDismiss, "v@:@l");
			ObjC.AddMethod(_classHandle, "willPresentAlertView::", _onWillPresent = OnWillPresent, "v@:@");
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

		public event EventHandler<EventArgs<int>> Clicked = delegate { };
		public event EventHandler<EventArgs<int>> Dismissed = delegate { };
		public event EventHandler<EventArgs<int>> WillDismiss = delegate { };
		public event EventHandler Canceled = delegate { };
		public event EventHandler Presented = delegate { };
		public event EventHandler WillPresent = delegate { };

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

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnCanceled(IntPtr @this, IntPtr selector, IntPtr alertView)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.Canceled(instance, EventArgs.Empty);
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void OnClicked(IntPtr @this, IntPtr selector, IntPtr alertView, int buttonIndex)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.Clicked(instance, new EventArgs<int> { Value = buttonIndex });
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void OnDismissed(IntPtr @this, IntPtr selector, IntPtr alertView, int buttonIndex)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.Dismissed(instance, new EventArgs<int> { Value = buttonIndex });
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr, int>))]
		private static void OnWillDismiss(IntPtr @this, IntPtr selector, IntPtr alertView, int buttonIndex)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.WillDismiss(instance, new EventArgs<int> { Value = buttonIndex });
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnPresented(IntPtr @this, IntPtr selector, IntPtr alertView)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.Presented(instance, EventArgs.Empty);
			}
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr, IntPtr>))]
		private static void OnWillPresent(IntPtr @this, IntPtr selector, IntPtr alertView)
		{
			UIAlertView instance;
			if (_alertViews.TryGetValue (@this, out instance))
			{
				instance.WillPresent(instance, EventArgs.Empty);
			}
		}

//TODO: need to implement this callback
//		[Export("alertViewShouldEnableFirstOtherButton:")]
//		public bool ShouldEnableFirstOtherButton(UIAlertView alertView)

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
