using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UIImageTests
{
    [Test]
    public void AsJPEG()
    {
        var jpgImage = UIImage.FromFile("chuck.jpg").AsJPEG();
        Assert.AreNotEqual(0, jpgImage.Length);
    }

    [Test]
    public void AsJPEGWithQuality()
    {
        var jpgImage = UIImage.FromFile("chuck.jpg").AsJPEG(0.8f);
        Assert.AreNotEqual(0, jpgImage.Length);
    }

    [Test]
    public void AsPNG()
    {
        var pngImage = UIImage.FromFile("chuck.jpg").AsPNG();
        Assert.AreNotEqual(0, pngImage.Length);
    }

    [Test]
    public void CurrentScale()
    {
        var image = UIImage.FromFile("chuck.jpg");
        float scale = image.CurrentScale;
        Assert.AreNotEqual(0, scale);
    }

    [Test]
    public void FromBundle()
    {
        var image = UIImage.FromBundle("chuck.jpg");
        Assert.IsNotNull(image);
        Assert.AreNotEqual(IntPtr.Zero, image.Handle);
    }

    [Test]
    public void FromFile()
    {
        var image = UIImage.FromFile("chuck.jpg");
        Assert.IsNotNull(image);
        Assert.AreNotEqual(IntPtr.Zero, image.Handle);
    }

    [Test]
    public void Size()
    {
        var size = UIImage.FromFile("chuck.jpg").Size;
        Assert.AreNotEqual(0, size.Height);
        Assert.AreNotEqual(0, size.Width);
    }

    [Test]
    public void LoadFromData()
    {
        var data = NSData.FromFile("chuck.jpg");
        var image = UIImage.LoadFromData(data);
        Assert.IsNotNull(image);
        Assert.AreNotEqual(IntPtr.Zero, image.Handle);
    }

    [Test]
    public void LoadFromDataWithScale()
    {
        var data = NSData.FromFile("chuck.jpg");
        var image = UIImage.LoadFromData(data, 2);
        Assert.IsNotNull(image);
        Assert.AreNotEqual(IntPtr.Zero, image.Handle);
    }
}

#endif