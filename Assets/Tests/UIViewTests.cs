using System;
using iOS4Unity;
using NUnit.Framework;

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
}

#endif
