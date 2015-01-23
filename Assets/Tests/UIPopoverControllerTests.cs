using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UIPopoverControllerTests 
{
    private UIViewController _controller = new UIViewController{Title = "Test" };

    [Test]
    public void PresentFromRect()
    {
        var popOver = new UIPopoverController(_controller);
        popOver.PresentFromRect(new CGRect(), new UIView(), UIPopoverArrowDirection.Any, true);
    }

    [Test]
    public void SetContentViewController()
    {
        var popOver = new UIPopoverController(new UIViewController());
        popOver.SetContentViewController ( _controller, true);
        Assert.AreEqual("Test", popOver.ContentViewController.Title);
    }

    [Test]
    public void SetPopoverContentSize()
    {
        var popOver = new UIPopoverController(_controller);
        popOver.SetPopoverContentSize(new CGSize(100, 120), true);
        Assert.AreEqual(100, popOver.PopoverContentSize.Width);
        Assert.AreEqual(120, popOver.PopoverContentSize.Height);
    }

    [Test]
    public void Dismiss()
    {
        var popOver = new UIPopoverController(_controller);
        popOver.Dismiss(true);
    }

    [Test]
    public void PopoverArrowDirection()
    {
        var popOver = new UIPopoverController(_controller);
        Assert.AreEqual(UIPopoverArrowDirection.Unknown, popOver.PopoverArrowDirection);
    }

    [Test]
    public void PopoverVisible()
    {
        var popOver = new UIPopoverController(_controller);
        Assert.IsFalse(popOver.PopoverVisible);
    }
}

#endif
