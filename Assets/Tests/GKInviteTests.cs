using iOS4Unity;
using NUnit.Framework;
using System;

[TestFixture]
public class GKInviteTests
{
    [Test]
    public void NewObject()
    {
        var invite = new GKInvite();

        Assert.AreNotEqual(IntPtr.Zero, invite.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, invite.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var invite = new GKInvite();
        invite.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new GKInvite();
        var b = Runtime.GetNSObject<GKInvite>(a.Handle);
        Assert.AreSame(a, b);
    }
}
