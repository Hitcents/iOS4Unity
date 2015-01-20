using System;

namespace iOS4Unity
{
    public class AdBannerView : UIView
    {
        private static readonly IntPtr _classHandle;

        static AdBannerView()
        {
            _classHandle = ObjC.GetClass("ADBannerView");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public AdBannerView()
        {
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public AdBannerView(CGRect frame) : base(frame)
        {
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public AdType AdType
        {
            get { return (AdType)ObjC.MessageSendInt(Handle, "adType"); }
        }

        public bool BannerLoaded
        {
            get { return ObjC.MessageSendBool(Handle, "isBannerLoaded"); }
        }

        public event EventHandler AdLoaded
        {
            add { Callbacks.Subscribe(this, "bannerViewDidLoadAd:", value); }
            remove { Callbacks.Unsubscribe(this, "bannerViewDidLoadAd:", value); }
        }

        public event EventHandler ActionFinished
        {
            add { Callbacks.Subscribe(this, "bannerViewActionDidFinish:", value); }
            remove { Callbacks.Unsubscribe(this, "bannerViewActionDidFinish:", value); }
        }

        public event EventHandler<EventArgs<NSError>> FailedToReceiveAd
        {
            add { Callbacks.Subscribe(this, "bannerView:didFailToReceiveAdWithError:", value); }
            remove { Callbacks.Unsubscribe(this, "bannerView:didFailToReceiveAdWithError:", value); }
        }

        public event EventHandler WillLoad
        {
            add { Callbacks.Subscribe(this, "bannerViewWillLoadAd:", value); }
            remove { Callbacks.Unsubscribe(this, "bannerViewWillLoadAd:", value); }
        }
    }

    public enum AdType
    {
        Banner,
        MediumRectangle
    }
}
