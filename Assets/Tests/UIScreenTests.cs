using iOS4Unity;
using NUnit.Framework;
using System;

#if !UNITY_EDITOR

[TestFixture]
public class UIScreenTests
{
    [Test]
    public void MainScreen()
    {
        var screen = UIScreen.MainScreen;

        Assert.AreNotEqual(IntPtr.Zero, screen.Handle);
    }

    [Test]
    public void MainScreenDispose()
    {
        var screen = UIScreen.MainScreen;
        screen.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = UIScreen.MainScreen;
        var b = UIScreen.MainScreen;
        Assert.AreSame(a, b);
    }

    [Test]
    public void ApplicationFrame()
    {
        var applicationFrame = UIScreen.MainScreen.ApplicationFrame;
        Assert.AreNotEqual(CGRect.Empty, applicationFrame);
    }

    [Test]
    public void AvailableModes()
    {
        var modes = UIScreen.MainScreen.AvailableModes;
        Assert.AreNotEqual(0, modes.Length);
        foreach (var mode in modes)
        {
            Assert.AreNotEqual(0, mode.PixelAspectRatio);
            Assert.AreNotEqual(CGSize.Empty, mode.Size);
        }
    }

    [Test]
    public void Bounds()
    {
        var bounds = UIScreen.MainScreen.Bounds;
        Assert.AreNotEqual(CGRect.Empty, bounds);
    }

    [Test]
    public void Brightness()
    {
        var screen = UIScreen.MainScreen;
        Assert.AreNotEqual(0, screen.Brightness);
    }

    [Test]
    public void MirroredScreen()
    {
        Assert.IsNull(UIScreen.MainScreen.MirroredScreen);
    }

    [Test]
    public void NativeBounds()
    {
        //iOS 8 only
        if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
        {
            var nativeBounds = UIScreen.MainScreen.NativeBounds;
            Assert.AreNotEqual(CGRect.Empty, nativeBounds);
        }
        else
        {
            Assert.Inconclusive("Not iOS 8");
        }
    }

    [Test]
    public void NativeScale()
    {
        //iOS 8 only
        if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
        {
            var nativeScale = UIScreen.MainScreen.NativeScale;
            Assert.AreNotEqual(0, nativeScale);
        }
        else
        {
            Assert.Inconclusive("Not iOS 8");
        }
    }

    [Test]
    public void Notifications()
    {
        Assert.IsNotNull(UIScreen.BrightnessDidChangeNotification);
        Assert.IsNotNull(UIScreen.DidConnectNotification);
        Assert.IsNotNull(UIScreen.DidDisconnectNotification);
        Assert.IsNotNull(UIScreen.ModeDidChangeNotification);
    }

    [Test]
    public void Scale()
    {
        var scale = UIScreen.MainScreen.NativeScale;
        Assert.AreNotEqual(0, scale);
    }

    [Test]
    public void Screens()
    {
        var screens = UIScreen.Screens;
        Assert.AreNotEqual(0, screens.Length);
        foreach (var screen in screens)
        {
            Assert.AreNotEqual(0, screen.Scale);
            Assert.AreNotEqual(CGSize.Empty, screen.Bounds);
        }
    }

    [Test]
    public void WantsSoftwareDimming()
    {
        //Just to make sure this doesn't crash
        UIScreen.MainScreen.WantsSoftwareDimming.ToString();
    }

    [Test]
    public void ScreenModeObjectSame()
    {
        var a = UIScreen.MainScreen.CurrentMode;
        var b = UIScreen.MainScreen.CurrentMode;
        Assert.AreSame(a, b);
    }
}

#endif