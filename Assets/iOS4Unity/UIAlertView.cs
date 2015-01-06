using System;

namespace iOS4Unity
{
	public class UIAlertView : NSObject 
	{
		private static readonly IntPtr _classHandle;

		static UIAlertView()
		{
			_classHandle = ObjC.GetClass("UIAlertView");
		}

		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}

		private readonly IntPtr _handle;

		public override IntPtr Handle 
		{
			get { return _handle; }
		}

		public UIAlertView()
		{
			var init = ObjC.GetSelector("init");
			_handle = ObjC.IntPtr_objc_msgSend(base.Handle, init);
		}

		public int AddButton(string title)
		{
			IntPtr intPtr = ObjC.CreateNSString(title);
			IntPtr selector = ObjC.GetSelector("addButtonWithTitle:");
			int result = ObjC.int_objc_msgSend_IntPtr(Handle, selector, intPtr);
			ObjC.void_objc_msgSend(intPtr, ObjC.GetSelector("release"));
			return result;
		}

		public virtual int ButtonCount
		{
			get
			{
				IntPtr selector = ObjC.GetSelector("numberOfButtons");
				return ObjC.int_objc_msgSend(Handle, selector);
			}
		}
	}
}
