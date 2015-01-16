using System;

namespace iOS4Unity
{
	public class NSNotification : NSObject 
	{
		private static readonly IntPtr _classHandle;
		
		static NSNotification()
		{
			_classHandle = ObjC.GetClass("NSNotification");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}
		
		public NSNotification(IntPtr handle)
		{
			Handle = handle;
		}

		public string Name
		{
			get { return ObjC.MessageSendString(Handle, "name"); }
		}

		public NSObject Object
		{
			get { return new NSObject(ObjC.MessageSendIntPtr(Handle, "object")); }
		}
	}
}
