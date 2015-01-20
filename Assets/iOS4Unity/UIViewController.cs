using System;

namespace iOS4Unity
{
    public class UIViewController : NSObject 
    {
        private static readonly IntPtr _classHandle;

        static UIViewController()
        {
            _classHandle = ObjC.GetClass("UIViewController");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public UIViewController() { }

        internal UIViewController(IntPtr handle) : base(handle) { }

        public string Title
        {
            get { return ObjC.MessageSendString(Handle, "title"); }
            set { ObjC.MessageSend(Handle, "setTitle:", value); }
        }

        public UIView View
        {
            get { return new UIView(ObjC.MessageSendIntPtr(Handle, "view")); }
            set { ObjC.MessageSend(Handle, "setView:", value.Handle); }
        }

        public bool IsViewLoaded
        {
            get { return ObjC.MessageSendBool(Handle, "isViewLoaded"); }
        }

        public void LoadView()
        {
            ObjC.MessageSend(Handle, "loadView");
        }

        public UIViewController ParentViewController
        {
            get { return new UIViewController(ObjC.MessageSendIntPtr(Handle, "parentViewController")); }
        }

        public UIViewController PresentedViewController
        {
            get { return new UIViewController(ObjC.MessageSendIntPtr(Handle, "presentedViewController")); }
        }

        public UIViewController PresentingViewController
        {
            get { return new UIViewController(ObjC.MessageSendIntPtr(Handle, "presentingViewController")); }
        }

        //TODO: need to add the callback instead of using IntPtr.Zero
        public void PresentViewController(UIViewController controller, bool animated = true)
        {
            ObjC.MessageSend(Handle, "presentViewController:animated:completion:", controller.Handle, animated, IntPtr.Zero);
        }

        //TODO: need to add the callback instead of using IntPtr.Zero
        public void DismissViewController(bool animated = true)
        {
            ObjC.MessageSend(Handle, "dismissViewControllerAnimated:completion:", animated, IntPtr.Zero);  
        }
    }
}