using System;
using NUnit.Framework;
using iOS4Unity;

[TestFixture]
public class NSBundleTests 
{
    [Test]
    public void MainBundle()
    {
        var bundle = NSBundle.MainBundle;

        Assert.AreNotEqual(IntPtr.Zero, bundle);
    }

    [Test]
    public void MainBundleDispose()
    {
        var bundle = NSBundle.MainBundle;
        bundle.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = NSBundle.MainBundle;
        var b = NSBundle.MainBundle;
        Assert.AreSame(a, b);
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
