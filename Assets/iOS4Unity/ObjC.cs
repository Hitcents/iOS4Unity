using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using iOS4Unity.Marshalers;
using System.Collections.Generic;

namespace iOS4Unity
{
	public static class ObjC
	{
		private static readonly Dictionary<IntPtr, Delegate> _blockCache = new Dictionary<IntPtr, Delegate>();

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_registerName")]
		public static extern IntPtr GetSelector(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "sel_getName")]
		public static extern string GetSelectorName(IntPtr selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_getClass")]
		public static extern IntPtr GetClass(string name);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_allocateClassPair")]
		public static extern IntPtr AllocateClassPair(IntPtr superclass, string name, int extraBytes);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "class_addMethod")]
		public static extern bool AddMethod(IntPtr cls, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, Delegate imp, string types);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, int arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, int arg2, IntPtr arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, IntPtr arg2, double arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, IntPtr arg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg3, IntPtr arg4);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern uint MessageSendUInt(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int MessageSendInt(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int MessageSendInt(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, int arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, uint arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, uint arg2, bool arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, uint arg2, out IntPtr arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern bool MessageSendBool(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool MessageSendBool(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, bool arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern float MessageSendFloat(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern float MessageSendFloat(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, float arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
		public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
		public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr_NSUrl(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSUrlMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern CGRect MessageSendCGRect(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern CGSize MessageSendCGSize(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern UIScreenMode MessageSendUIScreenMode(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern UIScreenMode MessageSendUIScreenMode(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, UIScreenMode arg1);

		[DllImport("/usr/lib/libSystem.dylib")]
		private static extern IntPtr dlsym(IntPtr handle, string symbol);
		
		[DllImport("/usr/lib/libSystem.dylib")]
		private static extern IntPtr dlopen(string path, int mode);

		public static class Libraries
		{
			public static readonly IntPtr Foundation = dlopen("/System/Library/Frameworks/Foundation.framework/Foundation", 0);
			public static readonly IntPtr UIKit = dlopen("/System/Library/Frameworks/UIKit.framework/UIKit", 0);
		}

		public unsafe static IntPtr ToNSString(string str)
		{
			IntPtr handle = MessageSendIntPtr(GetClass("NSString"), "alloc");
			fixed (char* value = str + (IntPtr)(RuntimeHelpers.OffsetToStringData / 2))
			{
				handle = MessageSendIntPtr(handle, "initWithCharacters:length:", (IntPtr)((void*)value), str.Length);
				return handle;
			}
		}

        public static IntPtr ToNSUrl(string str)
        {
            //NOTE: NSURL is all caps
            return ObjC.MessageSendIntPtr(GetClass("NSURL"), "URLWithString:", str);
        }

		public static Delegate GetDelegateForBlock(IntPtr methodPtr, Type type)
		{
			lock (_blockCache)
			{
				Delegate del;
				if (!_blockCache.TryGetValue(methodPtr, out del))
				{
					_blockCache[methodPtr] =
						del = Marshal.GetDelegateForFunctionPointer(methodPtr, type);
				}
				return del;
			}
		}

		public static string FromNSString(IntPtr handle)
		{
			return Marshal.PtrToStringAuto(ObjC.MessageSendIntPtr(handle, "UTF8String"));
		}

        public static string FromNSUrl(IntPtr handle)
        {
            return FromNSString(ObjC.MessageSendIntPtr(handle, "absoluteString"));
        }

		public static string GetStringConstant(IntPtr handle, string symbol)
		{
			IntPtr intPtr = dlsym(handle, symbol);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			intPtr = Marshal.ReadIntPtr(intPtr);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return FromNSString(intPtr);
		}
	}
}