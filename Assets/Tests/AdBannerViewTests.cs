using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class AdBannerViewTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new AdBannerView();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new AdBannerView();
        obj.Dispose();
    }   
}

#endif