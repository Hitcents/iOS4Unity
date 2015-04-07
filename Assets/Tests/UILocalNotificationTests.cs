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
}

#endif