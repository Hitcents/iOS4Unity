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

        internal GKAchievement(IntPtr handle)
            : base(handle)
        {
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
            
        public GKAchievement(string identifier, GKPlayer player)
        {
            ObjC.MessageSendIntPtr(Handle, "initWithIdentifier:player:", identifier, player.Handle);
        }

        //NOTE: Needs completion handler
        public static void LoadAchievements()
        {
            ObjC.MessageSend(_classHandle, "loadAchievementsWithCompletionHandler:", IntPtr.Zero);
        }

        //NOTE: Needs completion handler
        public void ReportAchievement()
        {
            ObjC.MessageSend(_classHandle, "reportAchievementWithCompletionHandler:", IntPtr.Zero);
        }

        //TODO: Need GKChallenge
//        public static void ReportAchievements(GKAchievement[] achievements, GKChallenge[] challenges)
//        {
//            Messaging.void_objc_msgSend_IntPtr_IntPtr_IntPtr(GKAchievement.class_ptr, Selector.GetHandle("reportAchievements:withEligibleChallenges:withCompletionHandler:"), nSArray.Handle, (nSArray2 != null) ? nSArray2.Handle : IntPtr.Zero, (IntPtr)((void*)(&blockLiteral)));
//        }

        //NOTE: Needs completion handler
        public static void ReportAchievements(GKAchievement[] achievements)
        {
            var achievementsHandle = ObjC.ToNSArray(achievements);
            ObjC.MessageSend(_classHandle, "reportAchievements:withCompletionHandler:", achievementsHandle,  IntPtr.Zero);
        }

        //NOTE: Needs completion handler
        public static void ResetAchivements()
        {
            ObjC.MessageSend(_classHandle, "resetAchievementsWithCompletionHandler:", IntPtr.Zero);
        }

        //NOTE: Needs completion handler
        public void SelectChallengeablePlayerIDs(string[] playerIDs)
        {
            var playerIdsHandle = ObjC.ToNSArray(playerIDs);
            ObjC.MessageSend(_classHandle, "reportAchievements:withCompletionHandler:", playerIdsHandle,  IntPtr.Zero);
        }

        //NOTE: Needs completion handler
        public unsafe virtual void SelectChallengeablePlayers(GKPlayer[] players)
        {
            var playersHandle = ObjC.ToNSArray(players);
            ObjC.MessageSend(_classHandle, "reportAchievements:withCompletionHandler:", playersHandle,  IntPtr.Zero);
        }

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
            
        public GKPlayer Player
        {
            get { return Runtime.GetNSObject<GKPlayer>(ObjC.MessageSendIntPtr(Handle, "player")); }
        }

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
