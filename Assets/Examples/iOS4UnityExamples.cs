using UnityEngine;
using System.Collections;
using iOS4Unity;

public class iOS4UnityExamples : MonoBehaviour 
{
	private UIViewController GetUnityController()
	{
		return UIApplication.SharedApplication.KeyWindow.RootViewController;
	}

    public void UIAlertViewExample()
    {
        var alertView = new UIAlertView();
        alertView.AddButton("Option 1");
        alertView.AddButton("Option 2");
        alertView.Title = "Title";
        alertView.Message = "This is the UIAlertView message";

        alertView.Clicked += (sender, e) => 
        {
			int option = e.Index + 1;
			Debug.Log(string.Format ("Option {0} clicked!", option));
        };
        alertView.Dismissed += (sender, e) => 
        {
            Debug.Log("Dismissed");
        };

        alertView.Show();
    }

    public void UIActionSheetExample()
    {
        var actionSheet = new UIActionSheet();
        actionSheet.AddButton("Option 1");
        actionSheet.AddButton("Option 2");
        actionSheet.Title = "Title";

		actionSheet.Clicked += (sender, e) => 
		{
			int option = e.Index + 1;
			Debug.Log(string.Format ("Option {0} clicked!", option));
		};
		actionSheet.Dismissed += (sender, e) => 
		{
			Debug.Log("Dismissed");
		};

        actionSheet.Hidden = false;
    }

    public void AdBannerViewExample()
    {
        var bannerView = new AdBannerView();
        bannerView.AdLoaded += (sender, e) => 
        {
            Debug.Log("Ad Loaded!");
        };
		bannerView.FailedToReceiveAd += (sender, e) => 
        {
            Debug.Log("AdFailed: " + e.Error.LocalizedDescription);
        };

		var controller = GetUnityController();
        controller.View.AddSubview(bannerView);
    }

    public void OpenUrl()
    {
		UIApplication.SharedApplication.OpenUrl("http://www.google.com");
    }
}
