using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class UIViewControllerTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new UIViewController();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new UIViewController();
        obj.Dispose();
    }
}
