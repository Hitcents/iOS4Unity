using System;

namespace iOS4Unity
{
    public class UILocalNotification : NSObject
    {
        private static readonly IntPtr _classHandle;

        static UILocalNotification()
        {
            _classHandle = ObjC.GetClass("UILocalNotification");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public UILocalNotification()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        internal UILocalNotification(IntPtr handle)
            : base(handle)
        {
        }

        public string AlertAction
        {
            get { return ObjC.MessageSendString(Handle, "alertAction"); }
            set { ObjC.MessageSend(Handle, "setAlertAction:", value); }
        }

        public string AlertBody
        {
            get { return ObjC.MessageSendString(Handle, "alertBody"); }
            set { ObjC.MessageSend(Handle, "setAlertBody:", value); }
        }

        public string AlertLaunchImage
        {
            get { return ObjC.MessageSendString(Handle, "alertLaunchImage"); }
            set { ObjC.MessageSend(Handle, "setAlertLaunchImage:", value); }
        }

        /// <summary>
        /// Introduced in iOS 8.2
        /// </summary>
        public string AlertTitle
        {
            get { return ObjC.MessageSendString(Handle, "alertTitle"); }
            set { ObjC.MessageSend(Handle, "setAlertTitle:", value); }
        }

        public int ApplicationIconBadgeNumber
        {
            get { return ObjC.MessageSendInt(Handle, "applicationIconBadgeNumber"); }
            set { ObjC.MessageSend(Handle, "setApplicationIconBadgeNumber:", value); }
        }

        /// <summary>
        /// Introduced in iOS 8.0
        /// </summary>
        public string Category
        {
            get { return ObjC.MessageSendString(Handle, "category"); }
            set { ObjC.MessageSend(Handle, "setCategory:", value); }
        }

        public DateTime FireDate
        {
            get { return (DateTime)ObjC.MessageSendDate(Handle, "fireDate"); }
            set { ObjC.MessageSend(Handle, "setFireDate:", value); }
        }

        public bool HasAction
        {
            get { return ObjC.MessageSendBool(Handle, "hasAction"); }
            set { ObjC.MessageSend(Handle, "setHasAction:", value); }
        }

        public string SoundName
        {
            get { return ObjC.MessageSendString(Handle, "soundName"); }
            set { ObjC.MessageSend(Handle, "setSoundName:", value); }
        }

        public NSTimeZone TimeZone 
        {
            get { return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(Handle, "timeZone")); }
            set { ObjC.MessageSend(Handle, "setTimeZone:", value); }
        }

        public NSDictionary UserInfo
        {
            get { return Runtime.GetNSObject<NSDictionary>(ObjC.MessageSendIntPtr(Handle, "userInfo")); }
            set { ObjC.MessageSend(Handle, "setUserInfo:", value == null ? IntPtr.Zero : value.Handle); }
        }
    }
}