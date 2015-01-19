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

        public void AddSubview(UIView view)
        {
            ObjC.MessageSend(Handle, "addSubview:", view.Handle);
        }
    }
}
