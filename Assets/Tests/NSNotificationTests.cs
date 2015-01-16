using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSNotificationTests 
{
	[Test]
	public void FromName()
	{
		string text = Guid.NewGuid().ToString("N");
		var notification = NSNotification.FromName(text);
		Assert.AreNotEqual(IntPtr.Zero, notification.Handle);
		Assert.AreEqual(text, notification.Name);
	}

	[Test]
	public void FromNameDispose()
	{
		var notification = NSNotification.FromName("WOOT");
		notification.Dispose();
	}

	[Test]
	public void Object()
	{
		var obj = new NSObject();
		var notification = NSNotification.FromName("WOOT", obj);
		Assert.AreEqual(obj.Handle, notification.Object.Handle);
	}
}
