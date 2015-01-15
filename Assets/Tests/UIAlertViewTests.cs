using System;
using NUnit.Framework;
using iOS4Unity;

#if !UNITY_EDITOR

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
		alertView.AddButton("TEST");
		Assert.AreEqual(1, alertView.ButtonCount);
	}

	[Test]
	public void ButtonTitle()
	{
		string text = Guid.NewGuid().ToString("N");
		var alertView = new UIAlertView();
		alertView.AddButton(text);
		Assert.AreEqual(text, alertView.ButtonTitle(0));
	}

	[Test]
	public void Message()
	{
		string text = Guid.NewGuid().ToString("N");
		var alertView = new UIAlertView();
		alertView.Message = text;
		Assert.AreEqual(text, alertView.Message);
	}

	[Test]
	public void IsVisible()
	{
		var alertView = new UIAlertView();
		Assert.IsFalse(alertView.Visible);
	}

	[Test]
	public void FirstOtherButtonIndex()
	{
		var alertView = new UIAlertView();
		Assert.AreEqual(-1, alertView.FirstOtherButtonIndex);
	}

	[Test]
	public void CancelButtonIndex()
	{
		var alertView = new UIAlertView();
		Assert.AreEqual(-1, alertView.CancelButtonIndex);
	}

	[Test]
	public void AlertViewStyle()
	{
		var alertView = new UIAlertView();
		foreach (UIAlertViewStyle style in Enum.GetValues (typeof(UIAlertViewStyle))) 
		{
			alertView.AlertViewStyle = style;

			Assert.AreEqual (style, alertView.AlertViewStyle);
		}
	}

	[Test]
	public void Show()
	{
		var alertView = new UIAlertView();
		alertView.Message = "This is a test, n00bs!";
		alertView.AddButton ("OK");
		alertView.AddButton ("Cancel");
		alertView.Dismissed += (sender, e) => 
		{
			Console.WriteLine ("Button Clicked: " + e.Value);
		};
		alertView.Show();
	}

	[Test]
	public void Dismiss()
	{
		var alertView = new UIAlertView();
		alertView.Message = "This is a test, n00bs!";
		alertView.AddButton ("OK");
		alertView.AddButton ("Cancel");
		alertView.Show ();
		alertView.Dismiss(0, false);
	}
}

#endif
