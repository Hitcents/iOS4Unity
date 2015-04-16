using System;

namespace iOS4Unity
{
    public class GKPlayer : NSObject 
    {
        private static readonly IntPtr _classHandle;

        static GKPlayer()
        {
            _classHandle = ObjC.GetClass("GKPlayer");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public GKPlayer()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public string Alias
        {
            get { return ObjC.MessageSendString(Handle, "alias"); }
        }

        public string DidChangeNotificationName
        {
            get { return ObjC.MessageSendString(Handle, "GKPlayerDidChangeNotificationName"); }
        }

        public static string DidChangeNotificationNameNotification
        {
            get { return ObjC.MessageSendString(_classHandle, "GKPlayerDidChangeNotificationName"); }
        }

        public string DisplayName
        {
            get { return ObjC.MessageSendString(Handle, "displayName"); }
        }

        public bool IsFriend
        {
            get { return ObjC.MessageSendBool(Handle, "isFriend"); }
        }

        public string PlayerID
        {
            get { return ObjC.MessageSendString(Handle, "playerID"); }
        }
    }
}
