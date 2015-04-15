using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class NSObjectTests
{
    [Test]
    public void NewObject()
    {
        var obj = new NSObject();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new NSObject();
        obj.Dispose();
    }

    [Test]
    public void Description()
    {
        var obj = new NSObject();
        Assert.AreEqual(string.Format("<NSObject: 0x{0:x}>", (int)obj.Handle), obj.Description);
    }

    [Test]
    public void DescriptionToString()
    {
        var obj = new NSObject();
        Assert.AreEqual(obj.Description, obj.ToString());
    }
}