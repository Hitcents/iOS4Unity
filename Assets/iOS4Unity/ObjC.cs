using System;
using System.Collections.Generic;
using System.Reflection;
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
		public static extern bool AddMethod(IntPtr cls, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, Delegate imp, string types);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, bool arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, CGRect arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, CGPoint arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, float arg1);

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
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, bool arg2, IntPtr arg3);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, IntPtr arg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg3, IntPtr arg4);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, bool arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void MessageSend(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, bool arg1, IntPtr arg2);

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
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, CGRect arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, double arg1, int arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, uint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, IntPtr arg2);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, int arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, float arg2);

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
        public static extern bool MessageSendBool(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool MessageSendBool(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern double MessageSendDouble(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern float MessageSendFloat(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern float MessageSendFloat(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, float arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
		public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
        public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1);

		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
		public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
        public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
        public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, IntPtr arg1, int arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
        public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringMarshaler))]
        public static extern string MessageSendString(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSStringReleaseMarshaler))] string arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr_NSUrl(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSUrlMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr MessageSendIntPtr_NSUrl(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSUrlMarshaler))] string arg1, uint arg2, out IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool MessageSendBool_NSUrl(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NSUrlMarshaler))] string arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern CGRect MessageSendCGRect(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern CGPoint _MessageSendStretCGPoint(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern CGSize _MessageSendStretCGSize(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        #if XAMARIN

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGPoint _MessageSendCGPoint(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGSize _MessageSendCGSize(IntPtr receiver, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SelectorMarshaler))] string selector);

        #endif

        public static CGSize MessageSendCGSize(IntPtr receiver, string selector)
        {
            //HACK: works for now, Unity will most likely only be on devices anyway
            #if XAMARIN
            if (UIDevice.CurrentDevice.Model.Contains("Simulator"))
            {
                return _MessageSendCGSize(receiver, selector);
            }
            else
            #endif
            {
                return _MessageSendStretCGSize(receiver, selector);
            }
        }

        public static CGPoint MessageSendCGPoint(IntPtr receiver, string selector)
        {
            //HACK: works for now, Unity will most likely only be on devices anyway
            #if XAMARIN
            if (UIDevice.CurrentDevice.Model.Contains("Simulator"))
            {
                return _MessageSendCGPoint(receiver, selector);
            }
            else
            #endif
            {
                return _MessageSendStretCGPoint(receiver, selector);
            }
        }

		[DllImport("/usr/lib/libSystem.dylib")]
		private static extern IntPtr dlsym(IntPtr handle, string symbol);
		
		[DllImport("/usr/lib/libSystem.dylib")]
		private static extern IntPtr dlopen(string path, int mode);

		public static class Libraries
		{
			public static readonly IntPtr Foundation = dlopen("/System/Library/Frameworks/Foundation.framework/Foundation", 0);
			public static readonly IntPtr UIKit = dlopen("/System/Library/Frameworks/UIKit.framework/UIKit", 0);
		}

		public static string FromNSString(IntPtr handle)
		{
            if (handle == IntPtr.Zero)
                return null;

			return Marshal.PtrToStringAuto(ObjC.MessageSendIntPtr(handle, "UTF8String"));
		}

        public static DateTime FromNSDate(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return default(DateTime);

            double secondsSinceReferenceDate = ObjC.MessageSendDouble(handle, "timeIntervalSinceReferenceDate");
            if (secondsSinceReferenceDate < -63113904000)
            {
                return DateTime.MinValue;
            }
            if (secondsSinceReferenceDate > 252423993599)
            {
                return DateTime.MaxValue;
            }
            return new DateTime((long)(secondsSinceReferenceDate * 10000000 + 6.3113904E+17), DateTimeKind.Utc);
        }

        public static string FromNSUrl(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return null;

            return FromNSString(ObjC.MessageSendIntPtr(handle, "absoluteString"));
        }

        public static double FromNSNumber(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                return default(double);

            return ObjC.MessageSendDouble(handle, "doubleValue");
        }

        public static string[] FromNSArray(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            uint count =  ObjC.MessageSendUInt(handle, "count");
            string[] array = new string[count];
            IntPtr obj;
            for (uint num = 0; num < count; num += 1)
            {
                obj = ObjC.MessageSendIntPtr(handle, "objectAtIndex:", num);
                array[(int)num] = FromNSString(obj);
            }
            return array;
        }

        public static string[] FromNSSet(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            IntPtr array = ObjC.MessageSendIntPtr(handle, "allObjects");
            return FromNSArray(array);
        }

        public static T[] FromNSArray<T>(IntPtr handle) where T : NSObject
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            uint count =  ObjC.MessageSendUInt(handle, "count");
            T[] array = new T[count];
            IntPtr obj;
            for (uint num = 0; num < count; num += 1)
            {
                obj = ObjC.MessageSendIntPtr(handle, "objectAtIndex:", num);
                array[(int)num] = Activator.CreateFromHandle<T>(obj);
            }
            return array;
        }

        public static T[] FromNSSet<T>(IntPtr handle) where T : NSObject
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            IntPtr array = ObjC.MessageSendIntPtr(handle, "allObjects");
            return FromNSArray<T>(array);
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

        public unsafe static float GetFloatConstant(IntPtr handle, string symbol)
        {
            IntPtr intPtr = dlsym(handle, symbol);
            if (intPtr == IntPtr.Zero)
            {
                return 0;
            }
            float* ptr = (float*)((void*)intPtr);
            return *ptr;
        }

        public static IntPtr ToNSArray(IntPtr[] items)
        {
            IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)(items.Length * IntPtr.Size));
            for (int i = 0; i < items.Length; i++)
            {
                Marshal.WriteIntPtr(intPtr, i * IntPtr.Size, items[i]);
            }

            IntPtr array = ObjC.MessageSendIntPtr(ObjC.GetClass("NSArray"), "arrayWithObjects:count:", intPtr, items.Length);
            Marshal.FreeHGlobal(intPtr);
            return array;
        }

        public static IntPtr ToNSSet(IntPtr[] items)
        {
            IntPtr array = ToNSArray(items);
            return ObjC.MessageSendIntPtr(GetClass("NSSet"), "setWithArray:", array);
        }

        public static IntPtr ToNSSet(string[] items)
        {
            IntPtr[] strings = new IntPtr[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                strings[i] = ToNSString(items[i]);
            }

            IntPtr array = ToNSArray(strings);
            IntPtr set = ObjC.MessageSendIntPtr(GetClass("NSSet"), "setWithArray:", array);

            //Release everything
            for (int i = 0; i < strings.Length; i++)
            {
                ObjC.MessageSend(strings[i], "release");
            }

            return set;
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

        public static IntPtr ToNSDate(DateTime date)
        {
            return ObjC.MessageSendIntPtr(GetClass("NSDate"), "dateWithTimeIntervalSinceReferenceDate:", (double)((date.ToUniversalTime().Ticks - 631139040000000000) / 10000000));
        }

        public static IntPtr ToNSNumber(double value)
        {
            IntPtr handle = ObjC.MessageSendIntPtr(GetClass("NSDecimalNumber"), "alloc");
            return ObjC.MessageSendIntPtr(handle, "initWithDouble:", value);
        }
	}
}