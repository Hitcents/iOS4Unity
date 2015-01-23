using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class ObjCTests 
{
    [Test]
    public void FromNSString()
    {
        string text = "WOOT";
        IntPtr handle = ObjC.ToNSString(text);
        string actual = ObjC.FromNSString(handle);
        Assert.AreEqual(text, actual);
    }

    [Test]
    public void FromNSStringNull()
    {
        string text = ObjC.FromNSString(IntPtr.Zero);
        Assert.IsNull(text);
    }

    [Test]
    public void FromNSDate()
    {
        //UTC now without the milliseconds
        var date = DateTime.UtcNow;
        date = date.AddMilliseconds(-date.Millisecond);

        IntPtr handle = ObjC.ToNSDate(date);
        var actual = ObjC.FromNSDate(handle);
        Assert.AreEqual(date.ToShortDateString(), actual.ToShortDateString());
        Assert.AreEqual(date.ToShortTimeString(), actual.ToShortTimeString());
    }

    [Test]
    public void FromNSDateNull()
    {
        var date = ObjC.FromNSDate(IntPtr.Zero);
        Assert.AreEqual(default(DateTime), date);
    }

    [Test]
    public void FromNSUrl()
    {
        string url = "http://google.com";
        IntPtr handle = ObjC.ToNSUrl(url);
        var actual = ObjC.FromNSUrl(handle);
        Assert.AreEqual(url, actual);
    }

    [Test]
    public void FromNSUrlNull()
    {
        string text = ObjC.FromNSUrl(IntPtr.Zero);
        Assert.IsNull(text);
    }

    [Test]
    public void FromNSNumber()
    {
        double number = 1.999;
        IntPtr handle = ObjC.ToNSNumber(number);
        var actual = ObjC.FromNSNumber(handle);
        Assert.AreEqual(Math.Round(number, 3), Math.Round(actual, 3));
    }

    [Test]
    public void FromNSNumberNull()
    {
        double number = ObjC.FromNSNumber(IntPtr.Zero);
        Assert.AreEqual(default(double), number);
    }
}
