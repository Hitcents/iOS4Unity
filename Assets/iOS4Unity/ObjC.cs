using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace iOS4Unity
{
	public static class ObjC
	{
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_registerName")]
		public static extern IntPtr GetSelector(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_getClass")]
		public static extern IntPtr GetClass(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_allocateClassPair")]
		public static extern IntPtr AllocateClassPair(IntPtr superclass, string name, int extraBytes);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "class_addMethod")]
		public static extern bool AddMethod(IntPtr cls, IntPtr name, DidDismissDelegate imp, string types);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void void_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void void_objc_msgSend_IntPtr_IntPtr_Double(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, double arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int int_objc_msgSend(IntPtr receiver, IntPtr selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int int_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		private static extern IntPtr IntPtr_objc_msgSend_IntPtr_int(IntPtr receiver, IntPtr selector, IntPtr arg1, int arg2);

		[DllImport("/usr/lib/libobjc.dylib")]
		public static extern void object_getInstanceVariable(IntPtr obj, string name, out IntPtr val);

		[DllImport("/usr/lib/libobjc.dylib")]
		public static extern void object_setInstanceVariable(IntPtr obj, string name, IntPtr val);

		public unsafe static IntPtr CreateNSString(string str)
		{
			IntPtr alloc = GetSelector ("alloc");
			IntPtr handle = IntPtr_objc_msgSend (GetClass("NSString"), alloc);

			IntPtr selector = GetSelector("initWithCharacters:length:");
			fixed (char* value = str + (IntPtr)(RuntimeHelpers.OffsetToStringData / 2))
			{
				handle = IntPtr_objc_msgSend_IntPtr_int(handle, selector, (IntPtr)((void*)value), str.Length);
				return handle;
			}
		}
	}
}