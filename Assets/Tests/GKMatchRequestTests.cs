using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class GKMatchRequests 
{
    [Test]
    public void NewObject()
    {
        var matchRequest = new GKMatchRequest();

        Assert.AreNotEqual(IntPtr.Zero, matchRequest.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, matchRequest.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new GKMatchRequest();
        var b = Runtime.GetNSObject<GKMatchRequest>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void DefaultNumberOfPlayers()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.DefaultNumberOfPlayers = 4;

        Assert.AreEqual(4, matchRequest.DefaultNumberOfPlayers);
    }

    [Test]
    public void InviteMessage()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.InviteMessage = "TestMessage";

        Assert.AreEqual("TestMessage", matchRequest.InviteMessage);
    }

    [Test]
    public void MaxPlayers()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.MaxPlayers = 4;

        Assert.AreEqual(4, matchRequest.MaxPlayers);
    }

    [Test]
    public void MinPlayers()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.MinPlayers = 4;

        Assert.AreEqual(4, matchRequest.MinPlayers);
    }

    [Test]
    public void PlayerGroup()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.PlayerGroup = 4;

        Assert.AreEqual(4, matchRequest.PlayerGroup);
    }

    [Test]
    public void PlayersToInvite()
    {
        var matchRequest = new GKMatchRequest();
        matchRequest.PlayersToInvite = new string[]{"Player1", "Player2"};

        Assert.AreEqual("Player1", matchRequest.PlayersToInvite[0]);
    }

    [Test]
    public void Recipients()
    {
        var matchRequest = new GKMatchRequest();
        var recipients = new GKPlayer[]{ new GKPlayer() };
        matchRequest.Recipients = recipients;

        Assert.IsNotNull(matchRequest.Recipients);
    }
}
