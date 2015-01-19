using System;
using iOS4Unity;
using NUnit.Framework;
using System.Runtime.InteropServices;

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
    public void FromBytes()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4 };
        IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        var data = NSData.FromBytes(ptr, (uint)bytes.Length);
        Assert.AreEqual(bytes.Length, data.Length);

        Marshal.FreeHGlobal(ptr);
    }

    [Test]
    public void FromBytesNoCopy()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4 };
        IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        var data = NSData.FromBytesNoCopy(ptr, (uint)bytes.Length);
        Assert.AreEqual(bytes.Length, data.Length);
        Assert.AreEqual(ptr, data.Bytes);

        Marshal.FreeHGlobal(ptr);
    }

    [Test]
    public void FromBytesNoCopyFree()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4 };
        IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        var data = NSData.FromBytesNoCopy(ptr, (uint)bytes.Length, true);
        Assert.AreEqual(bytes.Length, data.Length);
        Assert.AreEqual(ptr, data.Bytes);
    }

    [Test]
    public void FromUrl()
    {
        var data = NSData.FromUrl("http://www.google.com");
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
    }

    [Test]
    public void Bytes()
    {
        var data = NSData.FromArray(new byte[] { 0 });
        Assert.AreNotEqual(IntPtr.Zero, data.Bytes);
    }

    [Test]
    public void Length()
    {
        var data = NSData.FromArray(new byte[] { 0 });
        Assert.AreEqual(1, data.Length);
    }

    [Test]
    public void Indexer()
    {
        byte value = 121;
        var data = NSData.FromArray(new byte[] { value });
        Assert.AreEqual(value, data[0]);
    }
}
