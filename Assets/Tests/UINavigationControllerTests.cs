using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class UINavigationControllerTests
{
    [Test]
    public void NewObject()
    {
        var navController = new UINavigationController();

        Assert.AreNotEqual(IntPtr.Zero, navController.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, navController.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var achievement = new UINavigationController();
        achievement.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new UINavigationController();
        var b = Runtime.GetNSObject<UINavigationController>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void NavigationBarHidden()
    {
        var navController = new UINavigationController();
        navController.NavigationBarHidden = true;

        Assert.IsTrue(navController.NavigationBarHidden);
    }

    [Test]
    public void TopViewController()
    {
        var navController = new UINavigationController();
        navController.PushViewController(new UIViewController{ Title = "Test" }, true);

        Assert.IsNotNull(navController.TopViewController);
    }

    [Test]
    public void ViewControllers()
    {
        var navController = new UINavigationController();
        var viewControllers = new UIViewController[]{new UIViewController { Title="Test1" }, new UIViewController { Title="Test2"} };
        navController.SetViewControllers(viewControllers, true);

        Assert.IsNotNull(navController.ViewControllers);
    }

    [Test]
    public void VisibleViewController()
    {
        var navController = new UINavigationController();
        navController.PushViewController(new UIViewController{ Title = "Test" }, true);

        Assert.IsNotNull(navController.VisibleViewController);
    }
}
