using System;
using iOS4Unity;
using NUnit.Framework;
using System.Runtime.InteropServices;
using System.IO;

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
    }

    [Test]
    public void FromBytesNoCopyFree()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4 };
        IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        var data = NSData.FromBytesNoCopy(ptr, (uint)bytes.Length, false);
        Assert.AreEqual(bytes.Length, data.Length);
        Assert.AreEqual(ptr, data.Bytes);
    }

    [Test]
    public void FromFile()
    {
        var data = NSData.FromFile("Info.plist");
        Assert.AreNotEqual(0, data.Length);
    }

    [Test]
    public void FromFileWithError()
    {
        NSError error;
        var data = NSData.FromFile("Info.plist", NSDataReadingOptions.Coordinated, out error);
        Assert.AreNotEqual(0, data.Length);
        Assert.IsNull(error);
    }

    [Test]
    public void FromUrl()
    {
        var data = NSData.FromUrl("http://www.google.com");
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
    }

    [Test]
    public void FromUrlWithError()
    {
        NSError error;
        var data = NSData.FromUrl("http://www.google.com", NSDataReadingOptions.Coordinated, out error);
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
        Assert.IsNull(error);
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

    [Test]
    public void ToArray()
    {
        byte value = 121;
        var data = NSData.FromArray(new byte[] { value });
        var result = data.ToArray();
        Assert.AreEqual(value, result[0]);
    }

    [Test]
    public void AsStream()
    {
        byte value = 121;
        var data = NSData.FromArray(new byte[] { value });
        using (var stream = data.AsStream())
        {
            Assert.AreEqual(value, stream.ReadByte());
        }
    }

    [Test]
    public void Save()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString("N") + ".txt");
        byte value = 121;
        var data = NSData.FromArray(new byte[] { value });
        data.Save(path);
        var result = File.ReadAllBytes(path);
        Assert.AreEqual(value, result[0]);
    }
}
