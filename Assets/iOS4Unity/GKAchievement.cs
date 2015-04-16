using System;

namespace iOS4Unity
{
    public class GKAchievement : NSObject
    {
        private static readonly IntPtr _classHandle;

        static GKAchievement()
        {
            _classHandle = ObjC.GetClass("GKAchievement");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public GKAchievement()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public GKAchievement(string identifier)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithIdentifier:", identifier);
        }

        public GKAchievement(string identifier, string playerId)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithIdentifier:forPlayer:", identifier, playerId);
        }

        //TODO: GKPlayer
//        public GKAchievement(string identifier, GKPlayer player)
//        {
//            ObjC.MessageSendIntPtr(Handle, "initWithIdentifier:Player:", identifier, player);
//        }

        public bool Completed
        {
            get { return ObjC.MessageSendBool(Handle, "isCompleted"); }
        }

        public bool Hidden
        {
            get { return ObjC.MessageSendBool(Handle, "isHidden"); }
        }

        public string Identifier
        {
            get { return ObjC.MessageSendString(Handle, "identifier"); }
            set { ObjC.MessageSend(Handle, "setIdentifier:", value); }
        }

        public DateTime LastReportedDate
        {
            get { return (DateTime)ObjC.MessageSendDate(Handle, "lastReportedDate"); }
        }

        public double PercentComplete
        {
            get { return ObjC.MessageSendDouble(Handle, "percentComplete"); }
            set { ObjC.MessageSend(Handle, "setPercentComplete:", value); }
        }

        //TODO: GKPLAYER
//        public GKPlayer Player
//        {
//            get
//            {
//                GKPlayer nSObject = Runtime.GetNSObject<GKPlayer>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("player")));
//                return nSObject;
//            }
//        }

        public string PlayerID
        {
            get { return ObjC.MessageSendString(Handle, "playerID"); }
        }

        public bool ShowsCompletionBanner
        {
            get { return ObjC.MessageSendBool(Handle, "showsCompletionBanner"); }
            set { ObjC.MessageSend(Handle, "setShowsCompletionBanner:", value); }
        }
    }
}
