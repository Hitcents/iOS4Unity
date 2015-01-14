using System;
using System.Runtime.InteropServices;

namespace iOS4Unity.Marshalers
{
	public class NSStringMarshaler : ICustomMarshaler 
	{
		private static readonly NSStringMarshaler _instance = new NSStringMarshaler();
		
		public static ICustomMarshaler GetInstance(string cookie)
		{
			return _instance;
		}
		
		public void CleanUpManagedData(object managedObj)
		{
			//Doesn't need to do anything
		}
		
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (pNativeData != IntPtr.Zero)
				ObjC.MessageSend(pNativeData, "release");
		}
		
		public int GetNativeDataSize()
		{
			return IntPtr.Size;
		}
		
		public IntPtr MarshalManagedToNative (object managedObj)
		{
			string text = managedObj as string;
			if (text == null)
				return IntPtr.Zero;
			return ObjC.CreateNSString(text);
		}
		
		public object MarshalNativeToManaged (IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero)
				return default(string);
			return ObjC.MessageSendString(pNativeData, "UTF8String");
		}
	}
}