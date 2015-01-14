using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using iOS4Unity.Marshalers;

namespace iOS4Unity
{
	public static class ObjC
	{
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_registerName")]
		public static extern IntPtr GetSelector(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_getName")]
		public static extern string GetSelectorName(IntPtr selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_getClass")]
		public static extern IntPtr GetClass(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_allocateClassPair")]
		public static extern IntPtr AllocateClassPair(IntPtr superclass, string name, int extraBytes);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "class_addMethod")]
		public static extern bool AddMethod(IntPtr cls, IntPtr name, Delegate imp, string types);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))] string arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, IntPtr arg2, double arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int MessageSendInt(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int MessageSendInt(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, int arg2);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		public unsafe static IntPtr CreateNSString(string str)
		{
			IntPtr handle = MessageSendIntPtr (GetClass("NSString"), "alloc");
			fixed (char* value = str + (IntPtr)(RuntimeHelpers.OffsetToStringData / 2))
			{
				handle = MessageSendIntPtr(handle, "initWithCharacters:length:", (IntPtr)((void*)value), str.Length);
				return handle;
			}
		}
	}
}