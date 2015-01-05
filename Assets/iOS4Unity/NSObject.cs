using System;
using System.Runtime.InteropServices;

public class NSObject : IDisposable 
{
	public static readonly IntPtr ClassHandle;

	static NSObject()
	{
		ClassHandle = ObjC.GetClass("NSObject");
	}

	public readonly IntPtr Handle;

	public NSObject()
	{
		var alloc = ObjC.GetSelector("alloc");
		Handle = ObjC.IntPtr_objc_msgSend(ClassHandle, alloc);
	}

	public void Dispose()
	{
		if (Handle != IntPtr.Zero)
		{
			var release = ObjC.GetSelector ("release");
			ObjC.void_objc_msgSend(Handle, release);
		}
	}
}
