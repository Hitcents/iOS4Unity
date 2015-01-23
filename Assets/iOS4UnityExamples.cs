using UnityEngine;
using System.Collections;
using iOS4Unity;

public class iOS4UnityExamples : MonoBehaviour 
{
    public void UIAlertViewExample()
    {
        var alertView = new UIAlertView();
        alertView.AddButton("Option 1");
        alertView.AddButton("Option 2");
        alertView.Title = "Title";
        alertView.Message = "This is the UIAlertView message";

        alertView.Clicked += (sender, e) => 
        {
            Debug.Log("AlertView button clicked");
        };

        alertView.Dismissed += (sender, e) => 
        {
            Debug.Log("ActionSheet dismissed");
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
            Debug.Log("ActionSheet button clicked");
        };

        actionSheet.Dismissed += (sender, e) => 
        {
            Debug.Log("ActionSheet dismissed");
        };

        actionSheet.Hidden = false;
    }

    public void AdBannerViewExample()
    {
        var bannerView = new AdBannerView();
        bannerView.AdLoaded += (sender, e) => 
        {
            Debug.Log("Ad Loaded");
        };

        bannerView.WillLoad += (sender, e) => 
        {
            Debug.Log("Will load Ad");
        };

        bannerView.FailedToReceiveAd += (sender, e) => 
        {
            Debug.Log("AdFailed: " + e.Error.LocalizedDescription);
            
            bannerView.RemoveFromSuperview();
        };

        UIApplication.SharedApplication.KeyWindow.RootViewController.View.AddSubview(bannerView);
    }

    public void OpenUrl()
    {
        try
        {
            UIApplication.SharedApplication.OpenUrl("http://www.google.com");
        }
        catch(UnityException exc)
        {
            Debug.Log("OpenUrl failed:" + exc);
        }
    }
}
