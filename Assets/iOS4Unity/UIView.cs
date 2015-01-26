using System;

namespace iOS4Unity
{
    public class UIView : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UIView()
        {
            _classHandle = ObjC.GetClass("UIView");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public UIView()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public UIView(CGRect frame)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithFrame:", frame);
        }

        internal UIView(IntPtr handle) : base(handle) { }

        public CGRect Frame
        {
            get { return ObjC.MessageSendCGRect(Handle, "frame"); }
            set { ObjC.MessageSend(Handle, "setFrame:", value); }
        }

        public CGRect Bounds
        {
            get { return ObjC.MessageSendCGRect(Handle, "bounds"); }
            set { ObjC.MessageSend(Handle, "setBounds:", value); }
        }

        public CGPoint Center
        {
            get { return ObjC.MessageSendCGPoint(Handle, "center"); }
            set { ObjC.MessageSend(Handle, "setCenter:", value); }
        }

        public void AddSubview(UIView view)
        {
            ObjC.MessageSend(Handle, "addSubview:", view.Handle);
        }

        public UIView[] Subviews
        {
            get { return ObjC.FromNSArray<UIView>(ObjC.MessageSendIntPtr(Handle, "subviews")); }
        }

        public UIView Superview
        {
            get { return Runtime.GetNSObject<UIView>(ObjC.MessageSendIntPtr(Handle, "superview")); }
        }

        public void BringSubviewToFront(UIView view)
        {
            ObjC.MessageSend(Handle, "bringSubviewToFront:", view.Handle);
        }

        public void SendSubviewToBack(UIView view)
        {
            ObjC.MessageSend(Handle, "sendSubviewToBack:", view.Handle);
        }

        public bool Hidden
        {
            get { return ObjC.MessageSendBool(Handle, "isHidden"); }
            set { ObjC.MessageSend(Handle, "setHidden:", value); }
        }

        public float Alpha
        {
            get { return ObjC.MessageSendFloat(Handle, "alpha"); }
            set { ObjC.MessageSend(Handle, "setAlpha:", value); }
        }

        public UIWindow Window
        {
            get { return Runtime.GetNSObject<UIWindow>(ObjC.MessageSendIntPtr(Handle, "window")); }
        }

        public void RemoveFromSuperview()
        {
            ObjC.MessageSend(Handle, "removeFromSuperview");
        }
    }
}
