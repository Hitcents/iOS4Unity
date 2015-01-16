﻿using System;
using iOS4Unity;
using NUnit.Framework;

#if !UNITY_EDITOR

[TestFixture]
public class NSNotificationCenterTests 
{
	[Test]
	public void DefaultCenter()
	{
		var center = NSNotificationCenter.DefaultCenter;
		
		Assert.AreNotEqual(IntPtr.Zero, center.Handle);
	}
	
	[Test]
	public void DefaultCenterDispose()
	{
		var center = NSNotificationCenter.DefaultCenter;
		center.Dispose();
	}

	[Test]
	public void AddObserverAndPost()
	{
		string notification = "WOOT_OMG";
		var center = NSNotificationCenter.DefaultCenter;

		bool fired = false;
		center.AddObserver(notification, n =>
		{
			Assert.AreEqual(notification, n.Name);

			fired = true;
		});

		center.PostNotificationName(notification);

		Assert.IsTrue(fired);
	}

	[Test]
	public void AddRemoveObserver()
	{
		string notification = "WOOT_OMG";
		var center = NSNotificationCenter.DefaultCenter;
		
		bool fired = false;
		var observer = center.AddObserver(notification, n => fired = true);
		center.RemoveObserver(observer);
		center.PostNotificationName(notification);
		
		Assert.IsFalse(fired);
	}
}

#endif