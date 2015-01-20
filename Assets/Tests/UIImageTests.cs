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
    }

    [Test]
    public void AsPNG()
    {
    }

    [Test]
    public void FromBundle()
    {
        var image = UIImage.FromBundle("chuck.jpg");
        Assert.IsNotNull(image);
        Assert.AreNotEqual(0, image.Size.Height);
        Assert.AreNotEqual(0, image.Size.Width);
    }

    [Test]
    public void FromFile()
    {
        var image = UIImage.FromFile("chuck.jpg");
        Assert.IsNotNull(image);
        Assert.AreNotEqual(0, image.Size.Height);
        Assert.AreNotEqual(0, image.Size.Width);
    }

    [Test]
    public void Size()
    {
        var size = UIImage.FromFile("chuck.jpg").Size;
        Assert.AreNotEqual(0, size.Height);
        Assert.AreNotEqual(0, size.Width);
    }
}

#endif