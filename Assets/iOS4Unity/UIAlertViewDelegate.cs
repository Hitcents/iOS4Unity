using System;
using iOS4Unity;
using System.Runtime.InteropServices;

public delegate void DidDismissDelegate(IntPtr p0, IntPtr p1, IntPtr p2, int p3);

public class UIAlertViewDelegate : NSObject 
{
	private static readonly IntPtr _classHandle;
	
	static UIAlertViewDelegate()
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
	
	public UIAlertViewDelegate()
	{
		var init = ObjC.GetSelector("init");
		_handle = ObjC.IntPtr_objc_msgSend(base.Handle, init);

		//Create class for callbacks
		ObjC.AllocateClassPair (ObjC.GetClass ("NSObject"), "UIAlertViewDelegate", 0);

		//Create method
		_didDismiss = DidDismiss;
		ObjC.AddMethod(ClassHandle, ObjC.GetSelector ("alertView:didDismissWithButtonIndex:"), _didDismiss, "v@:@l");
	}

	private DidDismissDelegate _didDismiss;

	public virtual void DidDismiss(IntPtr @this, IntPtr selector, IntPtr alertView, int buttonIndex)
	{
		Console.WriteLine ("OMG, no way!");
	}
}
