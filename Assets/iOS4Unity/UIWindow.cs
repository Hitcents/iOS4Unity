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

        public void BecomeKeyWindow()
        {
            ObjC.MessageSend(Handle, "becomeKeyWindow");
        }

        public void MakeKeyAndVisible()
        {
            ObjC.MessageSend(Handle, "makeKeyAndVisible");
        }

        public void MakeKeyWindow()
        {
            ObjC.MessageSend(Handle, "makeKeyWindow");
        }

        public void ResignKeyWindow()
        {
            ObjC.MessageSend(Handle, "resignKeyWindow");
        }

        public UIScreen Screen
        {
            get { return new UIScreen(ObjC.MessageSendIntPtr(Handle, "screen")); }
            set { ObjC.MessageSend(Handle, "setScreen:", value.Handle); }
        }

        public float WindowLevel
        {
            get { return ObjC.MessageSendFloat(Handle, "windowLevel"); }
            set { ObjC.MessageSend(Handle, "setWindowLevel:", value); }
        }

        public UIViewController RootViewController
        {
            get { return Runtime.GetNSObject<UIViewController>(ObjC.MessageSendIntPtr(Handle, "rootViewController")); }
            set { ObjC.MessageSend(Handle, "setRootViewController:", value.Handle); }
        }
    }

    public static class UIWindowLevel
    {
        public static float Alert
        {
            get { return ObjC.GetFloatConstant(ObjC.Libraries.UIKit, "UIWindowLevelAlert"); }
        }

        public static float Normal
        {
            get { return ObjC.GetFloatConstant(ObjC.Libraries.UIKit, "UIWindowLevelNormal"); }
        }

        public static float StatusBar
        {
            get { return ObjC.GetFloatConstant(ObjC.Libraries.UIKit, "UIWindowLevelStatusBar"); }
        }
    }
}
