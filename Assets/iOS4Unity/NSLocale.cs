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

        public static string CanonicalLanguageIdentifierFromString(string str)
        {
            return ObjC.MessageSendString(_classHandle, "canonicalLanguageIdentifierFromString:", str);
        }

        public static string CanonicalLocaleIdentifierFromString(string str)
        {
            return ObjC.MessageSendString(_classHandle, "canonicalLocaleIdentifierFromString:", str);
        }

        public static string AlternateQuotationBeginDelimiterKey
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleAlternateQuotationBeginDelimiterKey")); }
        }

        public static string AlternateQuotationEndDelimiterKey
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleAlternateQuotationEndDelimiterKey")); }
        }

        public static string Calendar
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCalendar")); }
        }

        public static string CollationIdentifier
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCollationIdentifier")); }
        }

        public static string CollatorIdentifier
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCollatorIdentifier")); }
        }

        public static string CountryCode
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCountryCode")); }
        }

        public static string CurrencyCode
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCurrencyCode")); }
        }

        public static string CurrencySymbol
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleCurrencySymbol")); }
        }

        public static string DecimalSeparator
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleDecimalSeparator")); }
        }

        public static string ExemplarCharacterSet
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleExemplarCharacterSet")); }
        }

        public static string GroupingSeparator
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleGroupingSeparator")); }
        }

        public static string Identifier
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleIdentifier")); }
        }

        public static string[] ISOCountryCodes
        {
            get { return ObjC.FromNSArray(ObjC.MessageSendIntPtr(_classHandle, "ISOCountryCodes")); }
        }

        public static string[] ISOCurrencyCodes
        {
            get { return ObjC.FromNSArray(ObjC.MessageSendIntPtr(_classHandle, "ISOCurrencyCodes")); }
        }

        public static string[] ISOLanguageCodes
        {
            get { return ObjC.FromNSArray(ObjC.MessageSendIntPtr(_classHandle, "ISOLanguageCodes")); }
        }

        public static string LanguageCode
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleLanguageCode")); }
        }

        public static string MeasurementSystem
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleMeasurementSystem")); }
        }

        public static string QuotationBeginDelimiterKey
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleQuotationBeginDelimiterKey")); }
        }

        public static string QuotationEndDelimiterKey
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleQuotationEndDelimiterKey")); }
        }

        public static string ScriptCode
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleScriptCode")); }
        }

        public static string UsesMetricSystem
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleUsesMetricSystem")); }
        }

        public static string VariantCode
        {
            get { return ObjectForKey(ObjC.GetStringConstant(ObjC.Libraries.Foundation, "NSLocaleVariantCode")); }
        }

        private static string ObjectForKey(string key)
        {
            return ObjC.MessageSendString(_classHandle, "objectForKey:", key);
        }
    }
}
