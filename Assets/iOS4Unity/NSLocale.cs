using System;

namespace iOS4Unity
{
    public class NSLocale : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSLocale()
        {
            _classHandle = ObjC.GetClass("NSLocale");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public NSLocale(IntPtr handle) : base(handle) { }

        public static string CountryCode
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCountryCode");}
        }

        public static string CurrencyCode
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCurrencyCode");}
        }

        public static string CurrencySymbol
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCurrencySymbol");}
        }

        public static string DecimalSeparator
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleDecimalSeparator");}
        }

        public static string ExemplarCharacterSet
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleExemplarCharacterSet");}
        }

        public static string GroupingSeparator
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleGroupingSeparator");}
        }

        public static string Identifier
        {
            get { return ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleIdentifier");}
        }

//        public static string[] ISOCountryCodes
//        {
//            get { return ObjC.ArrayFromHandle<string>(ObjC.MessageSendIntPtr(_classHandle, "ISOCountryCodes")); }
//        }
    }
}
