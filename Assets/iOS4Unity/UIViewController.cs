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
    }
}