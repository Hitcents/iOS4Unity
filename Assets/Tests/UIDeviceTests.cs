using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UIDeviceTests 
{
	[Test]
	public void CurrentDevice()
	{
		var device = UIDevice.CurrentDevice;

		Assert.AreNotEqual(IntPtr.Zero, device.Handle);
	}

	[Test]
	public void CurrentDeviceDispose()
	{
		var device = UIDevice.CurrentDevice;
		device.Dispose();
	}

	[Test]
	public void BatteryLevel()
	{
		float level = UIDevice.CurrentDevice.BatteryLevel;
		Assert.AreNotEqual (0, level);
	}

    [Test]
    public void BatteryMonitoringEnabled()
    {
        var device = UIDevice.CurrentDevice;
        device.BatteryMonitoringEnabled = true;
        Assert.AreEqual(true, device.BatteryMonitoringEnabled);
    }

    [Test]
    public void BatteryState()
    {
        var device = UIDevice.CurrentDevice;
        Assert.AreEqual(device.BatteryState, UIDevice.UIDeviceBatteryState.Charging | UIDevice.UIDeviceBatteryState.Full | UIDevice.UIDeviceBatteryState.Unknown | UIDevice.UIDeviceBatteryState.Unplugged);
    }

    [Test]
    public void GeneratesDeviceOrientationNotifications ()
    {
        bool generatesNotifications = UIDevice.CurrentDevice.GeneratesDeviceOrientationNotifications;
        Assert.IsFalse(generatesNotifications);
    }

    [Test]
    public void UIDeviceOrientation()
    {
        var device = UIDevice.CurrentDevice;
        Assert.AreEqual
        (   
            device.BatteryState, 
            UIDevice.UIDeviceOrientation.FaceDown 
            | UIDevice.UIDeviceOrientation.FaceUp 
            | UIDevice.UIDeviceOrientation.LandscapeLeft 
            | UIDevice.UIDeviceOrientation.LandscapeRight 
            | UIDevice.UIDeviceOrientation.Portrait 
            | UIDevice.UIDeviceOrientation.PortraitUpsideDown 
            | UIDevice.UIDeviceOrientation.Unknown
         );
    }
}

#endif