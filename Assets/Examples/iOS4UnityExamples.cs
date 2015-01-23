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

        var controller = GetUnityController();
        actionSheet.ShowInView(controller.View);
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

	public void GetIAPPrices()
	{
		//NOTE: for this to work, your app's bundle ID should match what you have setup in iTunes Connect
		//	Each in-app purchase ID should be what you have setup in iTunes Connect also
		var request = new SKProductsRequest("com.yourcompany.iap1", "com.yourcompany.iap2");
		request.Failed += (sender, e) => 
		{
			Debug.Log("Error retrieviing prices: " + e.Error.LocalizedDescription);
		};
		request.ReceivedResponse += (sender, e) => 
		{
			//Invalid ones -- this will print out by default
			if (e.Response.InvalidProducts != null)
			{
				foreach (string invalidId in e.Response.InvalidProducts) 
				{
					Debug.Log ("Invalid ID: " + invalidId);
				}
			}

			//Successful ones

		};
		request.Start();
	}

	private void PrintProducts(SKProduct[] products)
	{
		if (products == null)
			return;

		using (var formatter = new NSNumberFormatter())
		{
			formatter.FormatterBehavior = NSNumberFormatterBehavior.Version_10_4;
			formatter.NumberStyle = NSNumberFormatterStyle.Currency;
			
			foreach (var product in products)
			{
				formatter.Locale = product.PriceLocale;

				Debug.Log ("Identifier: " + product.ProductIdentifier);
				//TODO: missing method!
				//Debug.Log ("Price: " + formatter.StringFromNumber(product.Price));
				Debug.Log ("Title: " + product.LocalizedTitle);
				Debug.Log ("Description: " + product.LocalizedDescription);
			}
		}
	}
}
