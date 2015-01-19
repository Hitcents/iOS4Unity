using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSErrorTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new NSError("com.hitcents.ios4unity", 122);

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new NSError("com.hitcents.ios4unity", 122);
        obj.Dispose();
    }
}
