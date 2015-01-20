using System;

namespace iOS4Unity
{
    public sealed class UIWindow : UIView
    {
        private static readonly IntPtr _classHandle;

        static UIWindow()
        {
            _classHandle = ObjC.GetClass("UIWindow");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public UIWindow() { }

        public UIWindow(CGRect frame) : base(frame) { }

        internal UIWindow(IntPtr handle) : base(handle) { }

        public bool IsKeyWindow
        {
            get { return ObjC.MessageSendBool(Handle, "isKeyWindow"); }
        }

//        public UIViewController RootViewController
//        {
//            [Export("rootViewController", ArgumentSemantic.Retain)]
//            get
//            {
//                UIApplication.EnsureUIThread();
//                UIViewController nSObject;
//                if (this.IsDirectBinding)
//                {
//                    nSObject = Runtime.GetNSObject<UIViewController>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("rootViewController")));
//                }
//                else
//                {
//                    nSObject = Runtime.GetNSObject<UIViewController>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("rootViewController")));
//                }
//                if (!NSObject.IsNewRefcountEnabled())
//                {
//                    this.__mt_RootViewController_var = nSObject;
//                }
//                return nSObject;
//            }
//            [Export("setRootViewController:", ArgumentSemantic.Retain)]
//            set
//            {
//                UIApplication.EnsureUIThread();
//                if (value == null)
//                {
//                    throw new ArgumentNullException("value");
//                }
//                if (this.IsDirectBinding)
//                {
//                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setRootViewController:"), value.Handle);
//                }
//                else
//                {
//                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setRootViewController:"), value.Handle);
//                }
//                if (!NSObject.IsNewRefcountEnabled())
//                {
//                    this.__mt_RootViewController_var = value;
//                }
//            }
//        }
    }
}
