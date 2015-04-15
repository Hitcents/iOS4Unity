using iOS4Unity;
using NUnit.Framework;
using System;

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
    public void ObjectSame()
    {
        var a = UIDevice.CurrentDevice;
        var b = Runtime.GetNSObject<UIDevice>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void BatteryLevel()
    {
        float level = UIDevice.CurrentDevice.BatteryLevel;
        Assert.AreNotEqual(0, level);
    }

    [Test]
    public void BatteryMonitoringEnabled()
    {
        //Just make sure this doesn't crash
        var device = UIDevice.CurrentDevice;
        device.BatteryMonitoringEnabled = true;
        device.BatteryMonitoringEnabled.ToString();
    }

    [Test]
    public void Notifications()
    {
        Assert.IsNotNull(UIDevice.BatteryLevelDidChangeNotification);
        Assert.IsNotNull(UIDevice.BatteryStateDidChangeNotification);
        Assert.IsNotNull(UIDevice.OrientationDidChangeNotification);
        Assert.IsNotNull(UIDevice.ProximityStateDidChangeNotification);
    }

    [Test]
    public void BatteryState()
    {
        //Just make sure this doesn't crash
        var device = UIDevice.CurrentDevice;
        device.BatteryState.ToString();
    }

    [Test]
    public void CheckSystemVersion()
    {
        bool iOS8 = UIDevice.CurrentDevice.CheckSystemVersion(8, 0);
        Assert.IsTrue(iOS8);
    }

    [Test]
    public void GeneratesDeviceOrientationNotifications()
    {
        //Just make sure this doesn't crash
        UIDevice.CurrentDevice.GeneratesDeviceOrientationNotifications.ToString();
    }

    [Test]
    public void LocalizedModel()
    {
        string localizedModel = UIDevice.CurrentDevice.LocalizedModel;
        Assert.IsNotNull(localizedModel);
    }

    [Test]
    public void Model()
    {
        string model = UIDevice.CurrentDevice.Model;
        Assert.IsNotNull(model);
    }

    [Test]
    public void Name()
    {
        string name = UIDevice.CurrentDevice.Name;
        Assert.IsNotNull(name);
    }

    [Test]
    public void Orientation()
    {
        var device = UIDevice.CurrentDevice;
        Assert.AreNotEqual(UIDeviceOrientation.Unknown, device.Orientation);
    }

    [Test]
    public void PlayInputClick()
    {
        //Just to make sure this doesn't crash
        UIDevice.CurrentDevice.PlayInputClick();
    }

    [Test]
    public void ProximityMonitoringEnabled()
    {
        //Just make sure this doesn't crash
        var device = UIDevice.CurrentDevice;
        device.ProximityMonitoringEnabled = true;
        device.ProximityMonitoringEnabled.ToString();
    }

    [Test]
    public void ProximityState()
    {
        //Just make sure this doesn't crash
        UIDevice.CurrentDevice.ProximityState.ToString();
    }

    [Test]
    public void SystemName()
    {
        string systemName = UIDevice.CurrentDevice.SystemName;
        Assert.IsNotNull(systemName);
    }

    [Test]
    public void SystemVersion()
    {
        string systemVersion = UIDevice.CurrentDevice.SystemVersion;
        Assert.IsNotNull(systemVersion);
    }

    [Test]
    public void UserInterfaceIdiom()
    {
        var device = UIDevice.CurrentDevice;
        Assert.AreNotEqual(UIUserInterfaceIdiom.Unspecified, device.Orientation);
    }
}

#endif