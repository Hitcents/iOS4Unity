using iOS4Unity;
using NUnit.Framework;
using System;

#if !UNITY_EDITOR

[TestFixture]
public class UIViewTests
{
    [Test]
    public void NewObject()
    {
        var obj = new UIView();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new UIView();
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new UIView();
        var b = Runtime.GetNSObject<UIView>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void NewObjectWithFrame()
    {
        var frame = new CGRect(1, 2, 3, 4);
        var obj = new UIView(frame);
        Assert.AreEqual(frame, obj.Frame);
    }

    [Test]
    public void Frame()
    {
        var frame = new CGRect(1, 2, 3, 4);
        var obj = new UIView
        {
            Frame = frame,
        };
        Assert.AreEqual(frame, obj.Frame);
    }

    [Test]
    public void Bounds()
    {
        var bounds = new CGRect(1, 2, 3, 4);
        var obj = new UIView
        {
            Bounds = bounds,
        };
        Assert.AreEqual(bounds, obj.Bounds);
    }

    [Test]
    public void Center()
    {
        var point = new CGPoint(12, 3);
        var obj = new UIView
        {
            Center = point,
        };
        Assert.AreEqual(point, obj.Center);
    }

    [Test]
    public void AddSubview()
    {
        var view = new UIView();
        view.AddSubview(new UIView());
        Assert.AreEqual(1, view.Subviews.Length);
    }

    [Test]
    public void Superview()
    {
        var view = new UIView();
        var subview = new UIView();
        view.AddSubview(subview);
        Assert.AreEqual(view.Handle, subview.Superview.Handle);
    }

    [Test]
    public void BringSubviewToFront()
    {
        var view = new UIView();
        view.AddSubview(new UIView());
        var subview = new UIView();
        view.AddSubview(subview);
        view.AddSubview(new UIView());
        view.BringSubviewToFront(subview);

        var subviews = view.Subviews;
        Assert.AreEqual(subview.Handle, subviews[subviews.Length - 1].Handle);
    }

    [Test]
    public void SendSubviewToBack()
    {
        var view = new UIView();
        view.AddSubview(new UIView());
        var subview = new UIView();
        view.AddSubview(subview);
        view.AddSubview(new UIView());
        view.SendSubviewToBack(subview);

        var subviews = view.Subviews;
        Assert.AreEqual(subview.Handle, subviews[0].Handle);
    }

    [Test]
    public void Hidden()
    {
        var view = new UIView
        {
            Hidden = false,
        };
        Assert.IsFalse(view.Hidden);
        view.Hidden = true;
        Assert.IsTrue(view.Hidden);
    }

    [Test]
    public void Alpha()
    {
        float value = 0.85f;
        var view = new UIView
        {
            Alpha = value,
        };
        Assert.AreEqual(value, view.Alpha);
    }
}

#endif