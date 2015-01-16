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
		Assert.AreNotEqual(UIDeviceBatteryState.Unknown, device.BatteryState);
    }

    [Test]
    public void GeneratesDeviceOrientationNotifications()
    {
		//Just make sure this doesn't crash
        bool generatesNotifications = UIDevice.CurrentDevice.GeneratesDeviceOrientationNotifications;
    }

    [Test]
    public void Orientation()
    {
        var device = UIDevice.CurrentDevice;
		Assert.AreNotEqual(UIDeviceOrientation.Unknown, device.Orientation);
    }
}

#endif