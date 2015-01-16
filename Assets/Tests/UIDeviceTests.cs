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
	public void Notifications()
	{
		Assert.IsNotNull(UIDevice.BatteryLevelDidChangeNotification);
		Assert.IsNotNull(UIDevice.BatteryStateDidChangeNotification);
		Assert.IsNotNull(UIDevice.OrientationDidChangeNotification);
		Assert.IsNotNull(UIDevice.ProximityStateDidChangeNotification);
	}
}

#endif