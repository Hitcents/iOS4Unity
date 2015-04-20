using System;

namespace iOS4Unity
{
    public class GKMatchRequest : NSObject
    {
        private static readonly IntPtr _classHandle;

        static GKMatchRequest()
        {
            _classHandle = ObjC.GetClass("GKMatchRequest");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        public GKMatchRequest()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        internal GKMatchRequest(IntPtr handle)
            : base(handle)
        {
        }

        public static int GetMaxPlayersAllowed(GKMatchType matchType)
        {
            return ObjC.MessageSendInt(_classHandle, "maxPlayersAllowedForMatchOfType:", matchType);
        }

        //NOTE: Needs completion handler
        public void SetRecipientResponseHandler()
        {
            ObjC.MessageSend(_classHandle, "setRecipientResponseHandler:",  IntPtr.Zero);
        }

        public int DefaultNumberOfPlayers
        {
            get { return ObjC.MessageSendInt(Handle, "defaultNumberOfPlayers"); }
            set { ObjC.MessageSend(Handle, "setDefaultNumberOfPlayers:", value); }
        }

        public string InviteMessage
        {
            get { return ObjC.MessageSendString(Handle, "inviteMessage"); }
            set { ObjC.MessageSend(Handle, "setInviteMessage:", value); }
        }

        public int MaxPlayers
        {
            get { return ObjC.MessageSendInt(Handle, "maxPlayers"); }
            set { ObjC.MessageSend(Handle, "setMaxPlayers:", value); }
        }

        public int MinPlayers
        {
            get { return ObjC.MessageSendInt(Handle, "minPlayers"); }
            set { ObjC.MessageSend(Handle, "setMinPlayers:", value); }
        }

        public uint PlayerAttributes
        {
            get { return ObjC.MessageSendUInt(Handle, "minPlayers"); }
            set { ObjC.MessageSend(Handle, "setMinPlayers:", value); }
        }

        public int PlayerGroup
        {
            get { return ObjC.MessageSendInt(Handle, "playerGroup"); }
            set { ObjC.MessageSend(Handle, "setPlayerGroup:", value); }
        }

        public string[] PlayersToInvite
        {
            get
            {
                var array = Runtime.GetNSObject<NSObject>(ObjC.MessageSendIntPtr(Handle, "playersToInvite"));
                return ObjC.FromNSArray(array.Handle);
            }
            set 
            { 
                IntPtr array = ObjC.ToNSArray(value);
                ObjC.MessageSend(Handle, "setPlayersToInvite:", array); 
            }
        }

        //NOTE: iOS 8 only
        public GKPlayer[] Recipients
        {
            get { return ObjC.FromNSArray<GKPlayer>(ObjC.MessageSendIntPtr(Handle, "recipients")); }
            set
            {
                IntPtr array = ObjC.ToNSArray(value);
                ObjC.MessageSend(Handle, "setRecipients:", array);
            }
        }
    }

    public enum GKMatchType
    {
        PeerToPeer,
        Hosted,
        TurnBased
    }
}
