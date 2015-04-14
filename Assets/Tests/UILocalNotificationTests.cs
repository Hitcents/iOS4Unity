using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class UILocalNotificationTests 
{
	[Test]
	public void NewObject()
	{
		var obj = new UILocalNotification();

		Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
		Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
	}

	[Test]
	public void NewObjectDispose()
	{
		var obj = new UILocalNotification();
		obj.Dispose();
	}

	[Test]
	public void ObjectSame()
	{
		var a = new UILocalNotification();
		var b = Runtime.GetNSObject<UILocalNotification>(a.Handle);
		Assert.AreSame(a, b);
	}

    [Test]
    public void FireDateLocal()
    {
        var date = DateTime.Now.AddDays(7);
        var notification = new UILocalNotification();
        notification.FireDate = date;
        Assert.IsTrue(date - notification.FireDate < TimeSpan.FromSeconds(1), "Date does not match!");
    }

    [Test]
    public void FireDateUtc()
    {
        var date = DateTime.UtcNow.AddDays(7);
        var notification = new UILocalNotification();
        notification.FireDate = date;
        Assert.IsTrue(date - notification.FireDate < TimeSpan.FromSeconds(1), "Date does not match!");
    }
}

#endif