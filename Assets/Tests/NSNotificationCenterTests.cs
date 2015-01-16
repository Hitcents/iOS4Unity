using System;
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
}

#endif