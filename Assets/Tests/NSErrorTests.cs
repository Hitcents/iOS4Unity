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

    [Test]
    public void Code()
    {
        int code = 122;
        var error = new NSError("com.hitcents.ios4unity", code);
        Assert.AreEqual(code, error.Code);
    }

    [Test]
    public void Domain()
    {
        string domain = "com.hitcents.ios4unity";
        var error = new NSError(domain, 122);
        Assert.AreEqual(domain, error.Domain);
    }

    [Test]
    public void LocalizedDescription()
    {
        var error = new NSError("UNKNOWN", -1);
        Assert.AreEqual("The operation couldn’t be completed. (UNKNOWN error -1.)", error.LocalizedDescription);
    }
}
