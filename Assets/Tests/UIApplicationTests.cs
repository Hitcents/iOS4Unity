using iOS4Unity;
using NUnit.Framework;
using System;

#if !UNITY_EDITOR

public class UIApplicationTests
{
    [Test]
    public void SharedApplication()
    {
        var app = UIApplication.SharedApplication;

        Assert.AreNotEqual(IntPtr.Zero, app.Handle);
    }

    [Test]
    public void ApplicationEvents()
    {
        var app = UIApplication.SharedApplication;

        app.DidBecomeActive += (sender, e) =>
        {
            Console.WriteLine("DidBecomeActive!");
        };
        app.WillResignActive += (sender, e) =>
        {
            Console.WriteLine("WillResignActive!");
        };
    }

    [Test]
    public void SharedApplicationDispose()
    {
        var app = UIApplication.SharedApplication;
        app.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = UIApplication.SharedApplication;
        var b = UIApplication.SharedApplication;
        Assert.AreSame(a, b);
    }

    [Test]
    public void KeyWindow()
    {
        var window = UIApplication.SharedApplication.KeyWindow;
        Assert.IsNotNull(window);
        Assert.AreNotEqual(IntPtr.Zero, window.Handle);
    }

    [Test]
    public void BadgeNumber()
    {
        //Just make sure this doesn't crash
        var app = UIApplication.SharedApplication;
        app.ApplicationIconBadgeNumber = 1;
        app.ApplicationIconBadgeNumber.ToString();
    }

    [Test]
    public void ApplicationState()
    {
        Assert.AreEqual(UIApplicationState.Active, UIApplication.SharedApplication.ApplicationState);
    }

    [Test]
    public void Windows()
    {
        var windows = UIApplication.SharedApplication.Windows;
        Assert.IsNotNull(windows);
        Assert.AreNotEqual(0, windows.Length);
    }

    [Test]
    public void CanOpenUrl()
    {
        Assert.IsTrue(UIApplication.SharedApplication.CanOpenUrl("http://google.com"));
    }

    [Test]
    public void StatusBarHidden()
    {
#if XAMARIN
        Assert.IsFalse(UIApplication.SharedApplication.StatusBarHidden);
#else
        Assert.IsTrue(UIApplication.SharedApplication.StatusBarHidden);
#endif
    }

    [Test]
    public void StatusBarStyle()
    {
        Assert.AreEqual(UIStatusBarStyle.Default, UIApplication.SharedApplication.StatusBarStyle);
    }

    [Test]
    public void NetworkActivityIndicatorVisible()
    {
        Assert.IsFalse(UIApplication.SharedApplication.NetworkActivityIndicatorVisible);
    }

    [Test]
    public void IdleTimerDisabled()
    {
        Assert.IsFalse(UIApplication.SharedApplication.IdleTimerDisabled);
    }

    [Test]
    public void RegisterUserNotificationSettings()
    {
        //Just make sure this doesn't crash
        var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound);
        UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
    }

    [Test]
    public void PresentLocationNotificationNow()
    {
        RegisterUserNotificationSettings(); //This requests permission

        var notification = new UILocalNotification
        {
            AlertBody = "WOOT!!",
            ApplicationIconBadgeNumber = 1,
        };
        UIApplication.SharedApplication.PresentLocationNotificationNow(notification);
    }

    [Test]
    public void ScheduleLocalNotification()
    {
        RegisterUserNotificationSettings(); //This requests permission

        var notification = new UILocalNotification
        {
            AlertBody = "WOOT!!",
            ApplicationIconBadgeNumber = 1,
            FireDate = DateTime.Now.AddMinutes(1),
        };
        UIApplication.SharedApplication.ScheduleLocalNotification(notification);
    }

    [Test]
    public void CancelLocalNotification()
    {
        RegisterUserNotificationSettings(); //This requests permission

        var notification = new UILocalNotification
        {
            AlertBody = "WOOT!!",
            ApplicationIconBadgeNumber = 1,
            FireDate = DateTime.Now.AddMinutes(1),
        };
        UIApplication.SharedApplication.CancelLocalNotification(notification);
    }

    [Test]
    public void CancelAllLocalNotifications()
    {
        UIApplication.SharedApplication.CancelAllLocalNotifications();
    }
}

#endif