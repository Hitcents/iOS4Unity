using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UIScreenTests
{
    [Test]
    public void Brightness()
    {
        var screen = UIScreen.MainScreen;
        Assert.AreNotEqual(0, screen.Brightness);
    }

    [Test]
    public void MainScreen()
    {
        var screen = UIScreen.MainScreen;
        Assert.AreNotEqual(IntPtr.Zero, screen.Handle);
    }
}

#endif