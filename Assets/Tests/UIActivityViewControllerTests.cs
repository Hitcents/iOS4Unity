using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class UIActivityViewControllerTests 
{
    [Test, Ignore]
    public void NewObjectWithString()
    {
        var obj = new UIActivityViewController("WOOT");

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

	[Test, Ignore]
	public void NewObjectDispose()
    {
        var obj = new UIActivityViewController("WOOT");
        obj.Dispose();
    }

	[Test, Ignore]
	public void NewObjectWithImage()
    {
        var obj = new UIActivityViewController(UIImage.FromFile("chuck.jpg"));

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

	[Test, Ignore]
	public void NewObjectWithTextAndImage()
    {
        var obj = new UIActivityViewController("WOOT", UIImage.FromFile("chuck.jpg"));

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

	[Test, Ignore]
	public void ShareChuck()
    {
        var image = UIImage.FromFile("chuck.jpg");
        var activityController = new UIActivityViewController(image);
        var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
        controller.PresentViewController(activityController);
    }
}
