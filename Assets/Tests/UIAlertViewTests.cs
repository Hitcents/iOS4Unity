using System;
using NUnit.Framework;
using iOS4Unity;

[TestFixture]
public class UIAlertViewTests 
{
	[Test]
	public void NewObject()
	{
		var obj = new UIAlertView();
		
		Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
		Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
	}
	
	[Test]
	public void NewObjectDispose()
	{
		var obj = new UIAlertView();
		obj.Dispose();
	}

	[Test]
	public void AddButton()
	{
		var alertView = new UIAlertView();
		alertView.AddButton ("TEST");
		Assert.AreEqual(1, alertView.ButtonCount);
	}
}
