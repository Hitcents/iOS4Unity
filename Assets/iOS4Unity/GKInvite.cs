using System;

namespace iOS4Unity
{
    public class GKInvite : NSObject
    {
        private static readonly IntPtr _classHandle;

        static GKInvite()
        {
            _classHandle = ObjC.GetClass("GKInvite");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        internal GKInvite(IntPtr handle)
            : base(handle)
        {
        }

        public GKInvite()
        {
            ObjC.MessageSendIntPtr(Handle, "init");
        }

        public bool Hosted
        {
            get { return ObjC.MessageSendBool(Handle, "isHosted"); }
        }

        public string Inviter
        {
            get { return ObjC.MessageSendString(Handle, "inviter"); }
        }

        public uint PlayerAttributes
        {
            get { return ObjC.MessageSendUInt(Handle, "playerAttributes"); }
        }

        public int PlayerGroup
        {
            get { return ObjC.MessageSendInt(Handle, "playerGroup"); }
        }

        public GKPlayer Sender
        {
            get { return Runtime.GetNSObject<GKPlayer>(ObjC.MessageSendIntPtr(Handle, "sender")); }
        }
    }
}
