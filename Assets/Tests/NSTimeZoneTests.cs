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

    [Test]
    public void TimeZoneFromName()
    {
        var obj = NSTimeZone.FromName(NSTimeZone.KnownTimeZoneNames[0]);
        var name = obj.Name;

        Assert.AreEqual(obj.Name, name);
    }

    [Test]
    public void TimeZoneAbbreviation()
    {
        var obj1 = NSTimeZone.FromName(NSTimeZone.KnownTimeZoneNames[0]);
        var abbr = obj1.Abbreviation();
        var obj2 = NSTimeZone.FromAbbreviation(abbr);

        Assert.AreEqual(obj1.Abbreviation(), obj2.Abbreviation());
    }

    [Test]
    public void DefaultTimeZone()
    {
        var defaultTimeZone = NSTimeZone.DefaultTimeZone;

        Assert.AreNotEqual(IntPtr.Zero, defaultTimeZone.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, defaultTimeZone.Handle);
    }

    [Test]
    public void SystemTimeZone()
    {
        var systemTimeZone = NSTimeZone.SystemTimeZone;

        Assert.AreNotEqual(IntPtr.Zero, systemTimeZone.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, systemTimeZone.Handle);
    }

    [Test]
    public void DataVersion()
    {
        var defaultTimeZone = NSTimeZone.DefaultTimeZone;
        var data = defaultTimeZone.Data;
        var dataVersion = NSTimeZone.DataVersion;

        Assert.IsNotNull(dataVersion);
        Assert.AreNotEqual(IntPtr.Zero, data.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, data.Handle);
    }

    [Test]
    public void GetSecondsFromGMT()
    {
        var defaultTimeZone = NSTimeZone.DefaultTimeZone;
        var seconds = defaultTimeZone.GetSecondsFromGMT;

        Assert.IsNotNull(seconds);
        Assert.AreNotEqual(IntPtr.Zero, defaultTimeZone.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, defaultTimeZone.Handle);
    }

//    [Test]
//    public void TimeZoneIsDaylightSavings()
//    {
//        var obj1 = NSTimeZone.FromName(NSTimeZone.KnownTimeZoneNames[0]);
//        var isdaylightSavings = obj1.IsDaylightSavingsTime(DateTime.UtcNow);
//
//        Assert.AreEqual(false, isdaylightSavings);
//    }
}
