using System;
using NUnit.Framework;
using iOS4Unity;

#if !UNITY_EDITOR

[TestFixture]
public class NSBundleTests 
{
    [Test]
    public void NSBundleTest()
    {
        var bundle = NSBundle.MainBundle;

        Assert.AreNotEqual(IntPtr.Zero, bundle);
    }

    [Test]
    public void MainScreenDispose()
    {
        var bundle = NSBundle.MainBundle;
        bundle.Dispose();
    }

    [Test]
    public void BundlePath()
    {
        var bundle = NSBundle.MainBundle;
        Assert.AreNotSame(string.Empty, bundle.BundlePath);

    }

    [Test]
    public void ResourcePath()
    {
        var bundle = NSBundle.MainBundle;
        Assert.AreNotSame(string.Empty, bundle.ResourcePath);
    }
}

#endif
