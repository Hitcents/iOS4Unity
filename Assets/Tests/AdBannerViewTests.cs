using iOS4Unity;
using NUnit.Framework;
using System;

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

    [Test]
    public void NewObjectWithFrame()
    {
        var frame = new CGRect(0, 1, 2, 3);
        var obj = new AdBannerView(frame);
        Assert.AreNotEqual(CGRect.Empty, obj.Frame);
    }

    [Test]
    public void NewObjectWithType()
    {
        var type = AdType.MediumRectangle;
        var obj = new AdBannerView(type);
        Assert.AreEqual(type, obj.AdType);
    }

    [Test]
    public void ObjectSame()
    {
        var a = new AdBannerView(AdType.MediumRectangle);
        var b = Runtime.GetNSObject<AdBannerView>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void LoadAd()
    {
        var bannerView = new AdBannerView();
        bannerView.AdLoaded += (sender, e) =>
        {
            Console.WriteLine("AdLoaded!");

            bannerView.RemoveFromSuperview();
        };
        bannerView.FailedToReceiveAd += (sender, e) =>
        {
            Console.WriteLine("AdFailed: " + e.Error.LocalizedDescription);

            bannerView.RemoveFromSuperview();
        };

        UIApplication.SharedApplication.KeyWindow.RootViewController.View.AddSubview(bannerView);
    }
}

#endif