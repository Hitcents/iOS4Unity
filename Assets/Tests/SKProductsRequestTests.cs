using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class SKProductsRequestTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new SKProductsRequest("woot");

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new SKProductsRequest("woot");
        obj.Dispose();
    }
}
