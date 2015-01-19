using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSDataTests 
{
    [Test]
    public void FromArray()
    {
        var data = NSData.FromArray(new byte[] { 0 });
        Assert.AreNotEqual(IntPtr.Zero, data);
    }

    [Test] 
    public void FromArrayDispose()
    {
        var data = NSData.FromArray(new byte[] { 0 });
        data.Dispose();
    }

    [Test]
    public void FromData()
    {
        var source = NSData.FromArray(new byte[] { 0 });
        var data = NSData.FromData(source);
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
    }

    [Test]
    public void FromUrl()
    {
        var data = NSData.FromUrl("http://www.google.com");
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
    }
}
