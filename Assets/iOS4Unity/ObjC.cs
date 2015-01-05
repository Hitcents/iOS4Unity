using System;
using System.Runtime.InteropServices;

public static class ObjC
{
	[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_registerName")]
	public static extern IntPtr GetSelector(string name);

	[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_getClass")]
	public static extern IntPtr GetClass(string name);

	[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
	public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector);

	[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
	public static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

	[DllImport("/usr/lib/libobjc.dylib")]
	public static extern void object_getInstanceVariable(IntPtr obj, string name, out IntPtr val);

	[DllImport("/usr/lib/libobjc.dylib")]
	public static extern void object_setInstanceVariable(IntPtr obj, string name, IntPtr val);
}
