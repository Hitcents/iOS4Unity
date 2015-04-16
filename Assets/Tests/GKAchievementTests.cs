using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class GKAchievementTests
{
    [Test]
    public void NewObject()
    {
        var achievement = new GKAchievement();

        Assert.AreNotEqual(IntPtr.Zero, achievement.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, achievement.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var achievement = new GKAchievement();
        achievement.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new GKAchievement();
        var b = Runtime.GetNSObject<GKAchievement>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void GKAchievementWithId()
    {
        var achievement = new GKAchievement("TestIdentifier");
        var id = achievement.Identifier;

        Assert.AreEqual(achievement.Identifier, id);
    }

    [Test]
    public void GKAchievementWithPlayerId()
    {
        var achievement = new GKAchievement("TestIdentifier", "PlayerId");
        var id = achievement.Identifier;
        var playerId = achievement.PlayerID;
            
        Assert.AreEqual(achievement.Identifier, id);
        Assert.AreEqual(achievement.PlayerID, playerId);
    }

    [Test]
    public void GKAchievementWithPlayer()
    {
        var player = new GKPlayer();
        var achievement = new GKAchievement("TestIdentifier", player);
        var id = achievement.Identifier;

        Assert.AreEqual(achievement.Identifier, id);
        Assert.IsNotNull(achievement.Player);
    }
}
