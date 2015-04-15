using iOS4Unity;
using NUnit.Framework;
using System;

#if !UNITY_EDITOR

[TestFixture]
public class UIPopoverControllerTests
{
    private UIUserInterfaceIdiom _device = UIDevice.CurrentDevice.UserInterfaceIdiom;
    private UIViewController _controller = new UIViewController();

    [Test]
    public void NewObject()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var obj = new UIPopoverController(_controller);

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var obj = new UIPopoverController(_controller);
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var a = new UIPopoverController(_controller);
        var b = Runtime.GetNSObject<UIPopoverController>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void PresentFromRect()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popOver = new UIPopoverController(_controller);
        popOver.PresentFromRect(new CGRect(), new UIView(), UIPopoverArrowDirection.Any, true);
    }

    [Test]
    public void SetContentViewController()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popover = new UIPopoverController(new UIViewController());
        popover.SetContentViewController(_controller, false);
        Assert.IsNotNull(popover.ContentViewController);
    }

    [Test]
    public void SetPopoverContentSize()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popover = new UIPopoverController(_controller);
        popover.SetPopoverContentSize(new CGSize(100, 120), true);
        Assert.AreEqual(100, popover.PopoverContentSize.Width);
        Assert.AreEqual(120, popover.PopoverContentSize.Height);
    }

    [Test]
    public void Dismiss()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popover = new UIPopoverController(_controller);
        popover.Dismiss(true);
    }

    [Test]
    public void PopoverArrowDirection()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popover = new UIPopoverController(_controller);
        Assert.AreEqual(UIPopoverArrowDirection.Unknown, popover.PopoverArrowDirection);
    }

    [Test]
    public void PopoverVisible()
    {
        if (_device != UIUserInterfaceIdiom.Pad)
        {
            Assert.Inconclusive("Not running on iPad!");
            return;
        }

        var popover = new UIPopoverController(_controller);
        Assert.IsFalse(popover.PopoverVisible);
    }
}

#endif