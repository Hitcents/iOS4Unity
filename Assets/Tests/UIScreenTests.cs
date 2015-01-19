using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UIScreenTests
{
    [Test]
    public void ApplicationFrame()
    {
        var applicationFrame = UIScreen.MainScreen.ApplicationFrame;
        Assert.AreNotEqual(CGRect.Empty, applicationFrame);
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
    public void MainScreen()
    {
        var screen = UIScreen.MainScreen;
        Assert.AreNotEqual(IntPtr.Zero, screen.Handle);
    }

    [Test]
    public void MirroredScreen()
    {
        //Just to make sure this doesn't crash
        var mirroredScreen = UIScreen.MainScreen.MirroredScreen;
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
    public void Scale()
    {
        var scale = UIScreen.MainScreen.NativeScale;
        Assert.AreNotEqual(0, scale);
    }

    [Test]
    public void WantsSoftwareDimming()
    {
        //Just to make sure this doesn't crash
        bool wantsSoftwareDimming = UIScreen.MainScreen.WantsSoftwareDimming;
    }
}

#endif