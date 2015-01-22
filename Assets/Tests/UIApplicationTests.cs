using System;
using iOS4Unity;
using NUnit.Framework;

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
    public void SharedApplicationDispose()
    {
        var app = UIApplication.SharedApplication;
        app.Dispose();
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
}

#endif