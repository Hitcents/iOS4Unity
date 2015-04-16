using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class GKPlayerTests
{
    [Test]
    public void NewObject()
    {
        var player = new GKPlayer();

        Assert.AreNotEqual(IntPtr.Zero, player.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, player.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var player = new GKPlayer();
        player.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new GKPlayer();
        var b = Runtime.GetNSObject<GKPlayer>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void IsFriend()
    {
        var player = new GKPlayer();
        var isFriend = player.IsFriend;

        Assert.IsFalse(isFriend);
    }
}
