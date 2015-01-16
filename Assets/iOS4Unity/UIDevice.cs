using System;

namespace iOS4Unity
{
	public sealed class UIDevice : NSObject 
	{
		private static readonly IntPtr _classHandle;
		
		static UIDevice()
		{
			_classHandle = ObjC.GetClass("UIDevice");
		}
		
		public override IntPtr ClassHandle 
		{
			get { return _classHandle; }
		}

		private UIDevice(IntPtr handle)
		{
			Handle = handle;
		}

		public static UIDevice CurrentDevice
		{
			get { return new UIDevice(ObjC.MessageSendIntPtr(_classHandle, "currentDevice")); }
		}

		public float BatteryLevel
		{
			get { return ObjC.MessageSendFloat(Handle, "batteryLevel"); }
		}

		public override void Dispose ()
		{
			//Don't dispose
		}
	}
}
