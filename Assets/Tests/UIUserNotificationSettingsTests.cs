using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

public class UIUserNotificationSettingsTests
{
    [Test]
    public void NewObject()
    {
        var obj = new UIUserNotificationSettings();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new UIUserNotificationSettings();
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new UIUserNotificationSettings();
        var b = Runtime.GetNSObject<UIUserNotificationSettings>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void Types()
    {
        //Just make sure it doesn't crash
        new UIUserNotificationSettings().Types.ToString();
    }

    [Test]
    public void GetSettingsForTypes()
    {
        var types = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
        var settings = UIUserNotificationSettings.GetSettingsForTypes(types);
        Assert.AreEqual(types, settings.Types);
    }
}

#endif