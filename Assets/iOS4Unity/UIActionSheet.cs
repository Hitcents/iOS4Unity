using System;
using System.Collections;

namespace iOS4Unity
{
    public class UIActionSheet : UIView
    {
        private static readonly IntPtr _classHandle;

        static UIActionSheet()
        {
            _classHandle = ObjC.GetClass("UIActionSheet");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public UIActionSheet() 
        {
            ObjC.MessageSendIntPtr(Handle, "init");
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public int AddButton(string title)
        {
            return ObjC.MessageSendInt(Handle, "addButtonWithTitle:", title);
        }

        public event EventHandler<EventArgs<int>> Clicked
        {
            add { Callbacks.Subscribe(this, "actionSheet:clickedButtonAtIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "actionSheet:clickedButtonAtIndex:", value); }
        }

        public event EventHandler<EventArgs<int>> Dismissed
        {
            add { Callbacks.Subscribe(this, "actionSheet:didDismissWithButtonIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "actionSheet:didDismissWithButtonIndex:", value); }
        }

        public event EventHandler<EventArgs<int>> WillDismiss
        {
            add { Callbacks.Subscribe(this, "actionSheet:willDismissWithButtonIndex:", value); }
            remove { Callbacks.Unsubscribe(this, "actionSheet:willDismissWithButtonIndex:", value); }
        }

        public event EventHandler Canceled
        {
            add { Callbacks.Subscribe(this, "actionSheetCancel:", value); }
            remove { Callbacks.Unsubscribe(this, "actionSheetCancel:", value); }
        }

        public event EventHandler Presented
        {
            add { Callbacks.Subscribe(this, "didPresentActionSheet:", value); }
            remove { Callbacks.Unsubscribe(this, "didPresentActionSheet:", value); }
        }

        public event EventHandler WillPresent
        {
            add { Callbacks.Subscribe(this, "willPresentActionSheet:", value); }
            remove { Callbacks.Unsubscribe(this, "willPresentActionSheet:", value); }
        }

        public int ButtonCount
        {
            get { return ObjC.MessageSendInt(Handle, "numberOfButtons"); }
        }

        public string ButtonTitle(int index)
        {
            return ObjC.MessageSendString(Handle, "buttonTitleAtIndex:", index);
        }

        public int CancelButtonIndex
        {
            get { return ObjC.MessageSendInt (Handle, "cancelButtonIndex"); }
            set { ObjC.MessageSend(Handle, "setCancelButtonIndex:", value); }
        }

        public void DismissWithClickedButtonIndex(int buttonIndex, bool animated)
        {
            ObjC.MessageSendIntPtr(Handle, "dismissWithClickedButtonIndex:animated:", buttonIndex, animated);
        }

        public int FirstOtherButtonIndex
        {
            get { return ObjC.MessageSendInt(Handle, "firstOtherButtonIndex"); }
        }

        public void ShowInView(UIView view)
        {
            ObjC.MessageSendIntPtr(Handle, "showInView:", view.Handle);
        }

        public string Title
        {
            get { return ObjC.MessageSendString(Handle, "title"); }
            set { ObjC.MessageSend(Handle, "setTitle:", value); }
        }

        public bool Visible
        {
            get { return ObjC.MessageSendBool(Handle, "isVisible"); }
        }
    }
}