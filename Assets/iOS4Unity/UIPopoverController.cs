using System;

namespace iOS4Unity
{
    public class UIPopoverController : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIPopoverController()
        {
            _classHandle = ObjC.GetClass("UIPopoverController");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public UIPopoverController(UIViewController controller)
        {
            Handle = ObjC.MessageSendIntPtr(Handle, "initWithContentViewController:", controller.Handle);
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        internal UIPopoverController(IntPtr handle) : base(handle) { }

        public void PresentFromRect(CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated)
        {
            ObjC.MessageSend(Handle, "presentPopoverFromRect:inView:permittedArrowDirections:animated:", rect, view.Handle, (uint)arrowDirections, animated);
        }

        public void SetContentViewController(UIViewController viewController, bool animated)
        {
            ObjC.MessageSend(Handle, "setContentViewController:animated:", viewController.Handle, animated);
        }

        public void SetPopoverContentSize(CGSize size, bool animated)
        {
            ObjC.MessageSendIntPtr(Handle, "setPopoverContentSize:animated:", size, animated);
        }

        public void Dismiss(bool animated)
        {
            ObjC.MessageSend(Handle, "dismissPopoverAnimated:", animated);
        }

        public UIViewController ContentViewController
        {
            get { return Runtime.GetNSObject<UIViewController>(ObjC.MessageSendIntPtr(Handle, "contentViewController")); }
            set { ObjC.MessageSend(Handle, "setContentViewController:", value.Handle); }
        }

        public UIPopoverArrowDirection PopoverArrowDirection
        {
            get { return (UIPopoverArrowDirection)ObjC.MessageSendUInt(Handle, "popoverArrowDirection"); }
        }

        public CGSize PopoverContentSize
        {
            get { return ObjC.MessageSendCGSize(Handle, "popoverContentSize"); }
            set { ObjC.MessageSend(Handle, "setPopoverContentSize:", value); }
        }

        public bool PopoverVisible
        {
            get { return ObjC.MessageSendBool(Handle, "isPopoverVisible"); }
        }

        public event EventHandler Dismissed
        {
            add { Callbacks.Subscribe(this, "popoverControllerDidDismissPopover:", value); }
            remove { Callbacks.Unsubscribe(this, "popoverControllerDidDismissPopover:", value); }
        }
    }

    public enum UIPopoverArrowDirection : uint
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
        Any = 15,
        Unknown = 4294967295
    }
}
