using System;
using System.Collections.Generic;

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

        private readonly Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>> _failedToReceiveAd = new Dictionary<EventHandler<EventArgs<NSError>>, Action<IntPtr, IntPtr>>();

        public AdBannerView()
        {
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public AdBannerView(CGRect frame) : base(frame)
        {
            ObjC.MessageSend(Handle, "setDelegate:", Handle);
        }

        public AdBannerView(AdType type)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithAdType:", (int)type);
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
            add 
            { 
                Action<IntPtr, IntPtr> callback = (_, i) => value(this, new EventArgs<NSError> { Value = new NSError(i) });
                _failedToReceiveAd[value] = callback;
                Callbacks.Subscribe(this, "bannerView:didFailToReceiveAdWithError:", callback); 
            } 
            remove 
            { 
                Action<IntPtr, IntPtr> callback;
                if (_failedToReceiveAd.TryGetValue(value, out callback))
                {
                    _failedToReceiveAd.Remove(value);
                    Callbacks.Unsubscribe(this, "bannerView:didFailToReceiveAdWithError:", callback); 
                }
            }
        }

        public event EventHandler WillLoad
        {
            add { Callbacks.Subscribe(this, "bannerViewWillLoadAd:", value); }
            remove { Callbacks.Unsubscribe(this, "bannerViewWillLoadAd:", value); }
        }

        public void CancelBannerViewAction()
        {
            ObjC.MessageSend(Handle, "cancelBannerViewAction");
        }

        public override void Dispose()
        {
            base.Dispose();

            _failedToReceiveAd.Clear();
        }
    }

    public enum AdType
    {
        Banner,
        MediumRectangle
    }
}
