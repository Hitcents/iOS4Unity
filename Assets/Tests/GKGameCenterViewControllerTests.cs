using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class GKGameCenterViewControllerTests
{
    [Test]
    public void NewObject()
    {
        var gameCenterViewController = new GKGameCenterViewController();

        Assert.AreNotEqual(IntPtr.Zero, gameCenterViewController.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, gameCenterViewController.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var gameCenterViewController = new GKGameCenterViewController();
        gameCenterViewController.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new GKGameCenterViewController();
        var b = Runtime.GetNSObject<GKGameCenterViewController>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void LeaderboardCategory()
    {
        var gameCenterViewController = new GKGameCenterViewController();
        gameCenterViewController.LeaderboardCategory = "TestCategory";

        Assert.AreEqual("TestCategory", gameCenterViewController.LeaderboardCategory);
    }

    [Test]
    public void LeaderboardIdentifier()
    {
        var gameCenterViewController = new GKGameCenterViewController();
        gameCenterViewController.LeaderboardIdentifier = "TestIdentifier";

        Assert.AreEqual("TestIdentifier", gameCenterViewController.LeaderboardIdentifier);
    }

    [Test]
    public void ViewState()
    {
        var gameCenterViewController = new GKGameCenterViewController();
        gameCenterViewController.ViewState = GKGameCenterViewControllerState.Challenges;

        Assert.AreEqual(GKGameCenterViewControllerState.Challenges, gameCenterViewController.ViewState);
    }
}
