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

		public bool BatteryMonitoringEnabled
        {
            get { return  ObjC.MessageSendBool(Handle, "isBatteryMonitoringEnabled"); }
            set  { ObjC.MessageSendBool(Handle, "setBatteryMonitoringEnabled:", value); }
        }

        public UIDeviceBatteryState BatteryState
        {
            get { return (UIDeviceBatteryState)ObjC.MessageSendInt(Handle, "batteryState"); }
        }

        public bool GeneratesDeviceOrientationNotifications
        {
            get { return  ObjC.MessageSendBool(Handle, "isGeneratingDeviceOrientationNotifications"); }
        }

        public UIDeviceOrientation Orientation
        {
            get { return  (UIDeviceOrientation)ObjC.MessageSendBool(Handle, "orientation"); }
        }

		public override void Dispose ()
		{
			//Don't dispose
		}

        public enum UIDeviceBatteryState
        {
            Unknown,
            Unplugged,
            Charging,
            Full
        }

        public enum UIDeviceOrientation
        {
            Unknown,
            Portrait,
            PortraitUpsideDown,
            LandscapeLeft,
            LandscapeRight,
            FaceUp,
            FaceDown
        }
	}
}
