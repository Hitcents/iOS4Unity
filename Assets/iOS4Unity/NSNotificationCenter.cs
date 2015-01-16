using System;

namespace iOS4Unity
{
	public sealed class NSNotificationCenter : NSObject
	{
		private static readonly IntPtr _classHandle;
		
		static NSNotificationCenter()
		{
			_classHandle = ObjC.GetClass("NSNotificationCenter");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}
		
		private NSNotificationCenter(IntPtr handle)
		{
			Handle = handle;
		}

		public static NSNotificationCenter DefaultCenter
		{
			get { return new NSNotificationCenter(ObjC.MessageSendIntPtr(_classHandle, "defaultCenter")); }
		}

		public override void Dispose()
		{
			//Doesn't need to release
		}
	}
}
