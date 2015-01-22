using System;
using NUnit.Framework;
using iOS4Unity;

#if !UNITY_EDITOR

[TestFixture]
public class UIActionSheetTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new UIActionSheet();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new UIActionSheet();
        obj.Dispose();
    }

    [Test]
    public void AddButton()
    {
        var actionSheet = new UIActionSheet();
        actionSheet.AddButton("TEST");
        Assert.AreEqual(1, actionSheet.ButtonCount);
    }

    [Test]
    public void ButtonTitle()
    {
        string text = Guid.NewGuid().ToString("N");
        var actionSheet = new UIActionSheet();
        actionSheet.AddButton(text);
        Assert.AreEqual(text, actionSheet.ButtonTitle(0));
    }

    [Test]
    public void IsVisible()
    {
        var actionSheet = new UIActionSheet();
        Assert.IsFalse(actionSheet.Visible);
    }

    [Test]
    public void FirstOtherButtonIndex()
    {
        var actionSheet = new UIActionSheet();
        Assert.AreEqual(-1, actionSheet.FirstOtherButtonIndex);
    }

    [Test]
    public void CancelButtonIndex()
    {
        var actionSheet = new UIActionSheet();
        Assert.AreEqual(-1, actionSheet.CancelButtonIndex);
    }

    /// <summary>
    /// Ignored because it pops up all crazy
    /// </summary>
    [Test, Ignore]
    public void ShowInView()
    {
        var actionSheet = new UIActionSheet();
        actionSheet.AddButton ("OK");
        actionSheet.AddButton ("Cancel");
        actionSheet.Dismissed += (sender, e) => 
        {
            Console.WriteLine("Dismissed: " + e.Index);
        };
        actionSheet.Clicked += (sender, e) => 
        {
            Console.WriteLine("Clicked: " + e.Index);
        };
        actionSheet.Canceled += (sender, e) => 
        {
            Console.WriteLine("Canceled!");
        };
        actionSheet.Presented += (sender, e) => 
        {
            Console.WriteLine("Presented!");
        };
        actionSheet.WillDismiss += (sender, e) => 
        {
            Console.WriteLine("WillDismiss: " + e.Index);
        };
        actionSheet.WillPresent += (sender, e) => 
        {
            Console.WriteLine("WillPresent!");
        };

        actionSheet.ShowInView(UIApplication.SharedApplication.KeyWindow.RootViewController.View);
    }

    [Test]
    public void Dismiss()
    {
        var actionSheet = new UIActionSheet();
        actionSheet.AddButton ("OK");
        actionSheet.AddButton ("Cancel");
        actionSheet.DismissWithClickedButtonIndex(-1, false);
    }

    [Test]
    public void DoubleSubscribe()
    {
        int count = 0;
        EventHandler callback = (sender, e) => 
        {
            count++;
        };

        var actionSheet = new UIActionSheet();
        actionSheet.AddButton("OK");
        actionSheet.WillPresent += callback;
        actionSheet.WillPresent += callback;
        actionSheet.ShowInView(UIApplication.SharedApplication.KeyWindow.RootViewController.View);
        actionSheet.DismissWithClickedButtonIndex(-1, false);
        System.Threading.Thread.Sleep(500);

        Assert.AreEqual(2, count);
    }

    [Test]
    public void Unsubscribe()
    {
        int count = 0;
        EventHandler callback = (sender, e) => 
        {
            count++;
        };

        var actionSheet = new UIActionSheet();
        actionSheet.AddButton("OK");
        actionSheet.WillPresent += callback;
        actionSheet.WillPresent += callback;
        actionSheet.WillPresent -= callback;
        actionSheet.ShowInView(UIApplication.SharedApplication.KeyWindow.RootViewController.View);
        actionSheet.DismissWithClickedButtonIndex(-1, false);
        System.Threading.Thread.Sleep(500);

        Assert.AreEqual(1, count);
    }
}

#endif
