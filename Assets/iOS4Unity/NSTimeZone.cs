using System;

namespace iOS4Unity
{
    public class NSTimeZone : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSTimeZone()
        {
            _classHandle = ObjC.GetClass("NSTimeZone");
        }

        public override IntPtr ClassHandle
        {
            get { return _classHandle; }
        }

        internal NSTimeZone(IntPtr handle)
            : base(handle)
        {
        }

        public string Abbreviation(DateTime date)
        {
            return ObjC.MessageSendString(Handle, "abbreviationForDate:", date);
        }

        public virtual string Abbreviation()
        {
            return ObjC.MessageSendString(Handle, "abbreviation");
        }

        public double DaylightSavingTimeOffset(DateTime date)
        {
            return ObjC.MessageSendDouble(Handle, "daylightSavingTimeOffsetForDate:", date);
        }

        public static NSTimeZone FromAbbreviation(string abbreviation)
        {
            return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "timeZoneWithAbbreviation:", abbreviation));
        }

        public static NSTimeZone FromName(string name, NSData data)
        {
            return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "timeZoneWithName:data:", name, data.Handle));
        }

        public static NSTimeZone FromName(string name)
        {
            return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "timeZoneWithName:", name));
        }

        public bool IsDaylightSavingsTime(DateTime date)
        {
            return ObjC.MessageSendBool(Handle, "isDaylightSavingTimeForDate:", date);
        }

        public DateTime NextDaylightSavingTimeTransitionAfter(DateTime date)
        {
            return (DateTime)ObjC.MessageSendDate(Handle, "nextDaylightSavingTimeTransitionAfterDate:", date);
        }

        public static void ResetSystemTimeZone()
        {
            ObjC.MessageSend(_classHandle, "resetSystemTimeZone");
        }

        public int SecondsFromGMT(DateTime date)
        {
            return ObjC.MessageSendInt(Handle, "secondsFromGMTForDate:", date);
        }

        public static NSDictionary Abbreviations
        {
            get { return Runtime.GetNSObject<NSDictionary>(ObjC.MessageSendIntPtr(_classHandle, "abbreviationDictionary")); }
        }

        public NSData Data
        {
            get { return Runtime.GetNSObject<NSData>(ObjC.MessageSendIntPtr(Handle, "data")); }
        }

        public static string DataVersion
        {
            get { return ObjC.MessageSendString(_classHandle, "timeZoneDataVersion"); }
        }

        public static NSTimeZone DefaultTimeZone
        {
            get { return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "defaultTimeZone")); }
            set { ObjC.MessageSend(_classHandle, "setDefaultTimeZone:", value); }
        }

        public int GetSecondsFromGMT
        {
            get { return ObjC.MessageSendInt(Handle, "secondsFromGMT"); }
        }

        public static NSTimeZone LocalTimeZone
        {
            get { return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "localTimeZone")); }
        }

        public string Name
        {
            get { return ObjC.MessageSendString(Handle, "name"); }
        }

        public static NSTimeZone SystemTimeZone
        {
            get { return Runtime.GetNSObject<NSTimeZone>(ObjC.MessageSendIntPtr(_classHandle, "systemTimeZone")); }
        }
    }
}