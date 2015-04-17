using System;

namespace iOS4Unity
{
    public class UINavigationController : UIViewController
    {
        private static readonly IntPtr _classHandle;

        static UINavigationController()
        {
            _classHandle = ObjC.GetClass("UINavigationController");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public UINavigationController()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public UINavigationController(string nibName, NSBundle bundle)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithNibName:bundle:", nibName, bundle.Handle);
        }

        internal UINavigationController(IntPtr handle)
            : base(handle)
        {
        }

        public UIViewController[] PopToRootViewController(bool animated)
        {
            return ObjC.FromNSArray<UIViewController>(ObjC.MessageSendIntPtr(Handle, "popToRootViewControllerAnimated:", animated));
        }

        public UIViewController[] PopToViewController(UIViewController viewController, bool animated)
        {
            return ObjC.FromNSArray<UIViewController>(ObjC.MessageSendIntPtr(Handle, "popToViewController:animated:", viewController.Handle, animated));
        }

        public UIViewController PopViewControllerAnimated(bool animated)
        {
            return Runtime.GetNSObject<UIViewController>(ObjC.MessageSendIntPtr(Handle, "popViewControllerAnimated", animated));
        }

        public void PushViewController(UIViewController viewController, bool animated)
        {
            ObjC.MessageSend(Handle, "pushViewController:animated:", viewController.Handle, animated);
        }

        public void SetNavigationBarHidden(bool hidden, bool animated)
        {
            ObjC.MessageSend(Handle, "pushViewController:animated:", hidden, animated);
        }

        public virtual void SetToolbarHidden(bool hidden, bool animated)
        {
            ObjC.MessageSend(Handle, "setToolbarHidden:animated:", hidden, animated);
        }

        public void SetViewControllers(UIViewController[] controllers, bool animated)
        {
            IntPtr array = ObjC.ToNSArray(controllers);
            ObjC.MessageSend(Handle, "setViewControllers:animated:", array, animated);
        }

        public void ShowViewController(UIViewController controller, NSObject sender)
        {
            ObjC.MessageSend(Handle, "pushViewController:animated:", controller.Handle, (sender != null) ? sender.Handle : IntPtr.Zero);
        }

        public bool HidesBarsOnSwipe
        {
            get { return ObjC.MessageSendBool(Handle, "hidesBarsOnSwipe"); }
            set { ObjC.MessageSend(Handle, "setHidesBarsOnSwipe:", value); }
        }

        //NOTE: iOS 8 and up
        public bool HidesBarsOnTap
        {
            get { return ObjC.MessageSendBool(Handle, "hidesBarsOnTap"); }
            set { ObjC.MessageSend(Handle, "setHidesBarsOnTap:", value); }
        }

        //NOTE: iOS 8 and up
        public bool HidesBarsWhenKeyboardAppears
        {
            get { return ObjC.MessageSendBool(Handle, "hidesBarsWhenKeyboardAppears"); }
            set { ObjC.MessageSend(Handle, "setHidesBarsWhenKeyboardAppears:", value); }
        }

        //NOTE: iOS 8 and up
        public bool HidesBarsWhenVerticallyCompact
        {
            get { return ObjC.MessageSendBool(Handle, "hidesBarsWhenVerticallyCompact"); }
            set { ObjC.MessageSend(Handle, "setHidesBarsWhenVerticallyCompact:", value); }
        }
            
//        public UINavigationBar NavigationBar
//        {
//            [Export("navigationBar")]
//            get{ }
//        }

        public bool NavigationBarHidden
        {
            get { return ObjC.MessageSendBool(Handle, "isNavigationBarHidden"); }
            set { ObjC.MessageSend(Handle, "setNavigationBarHidden:", value); }
        }

        public UIViewController TopViewController
        {
            get { return Runtime.GetNSObject<UIViewController>(ObjC.MessageSendIntPtr(Handle, "topViewController")); }
        }

        public UIViewController[] ViewControllers
        {
            get { return ObjC.FromNSArray<UIViewController>(ObjC.MessageSendIntPtr(Handle, "viewControllers")); }
            set { ObjC.MessageSend(Handle, "setViewControllers:", value); }
        }

        public UIViewController VisibleViewController
        {
            get { return Runtime.GetNSObject<UIViewController>(ObjC.MessageSendIntPtr(Handle, "visibleViewController")); }
        }
    }
}
