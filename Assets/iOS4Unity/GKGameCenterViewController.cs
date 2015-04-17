using System;

namespace iOS4Unity
{
    public class GKGameCenterViewController : UINavigationController
    {
        private static readonly IntPtr _classHandle;

        static GKGameCenterViewController()
        {
            _classHandle = ObjC.GetClass("GKGameCenterViewController");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public GKGameCenterViewController()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        internal GKGameCenterViewController(IntPtr handle)
            : base(handle)
        {
        }

        public string LeaderboardCategory
        {
            get { return ObjC.MessageSendString(Handle, "leaderboardCategory"); }
            set { ObjC.MessageSend(Handle, "setLeaderboardCategory:", value); }
        }

        public string LeaderboardIdentifier
        {
            get { return ObjC.MessageSendString(Handle, "leaderboardIdentifier"); }
            set { ObjC.MessageSend(Handle, "setLeaderboardIdentifier:", value); }

        }

        public GKGameCenterViewControllerState ViewState
        {
            get { return (GKGameCenterViewControllerState)ObjC.MessageSendInt(Handle, "viewState"); }
            set { ObjC.MessageSend(Handle, "setViewState:", (int)value); }
        }
    }

    public enum GKGameCenterViewControllerState
    {
        Default = -1,
        Leaderboards,
        Achievements,
        Challenges
    }
}
