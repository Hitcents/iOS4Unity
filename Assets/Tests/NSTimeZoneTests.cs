using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSTimeZoneTests
{
    [Test]
    public void NewTimeZone()
    {
        var obj = new NSTimeZone();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void TimeZoneDispose()
    {
        var obj = new NSTimeZone();
        obj.Dispose();
    }

    [Test]
    public void TimeZoneSame()
    {
        var a = new NSTimeZone();
        var b = Runtime.GetNSObject<NSTimeZone>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void TimeZoneName()
    {
        var obj = new NSTimeZone(NSTimeZone.KnownTimeZoneNames[0]);
        var name = obj.Name;

        Assert.AreEqual(obj.Name, name);
    }
}
