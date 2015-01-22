using System;

namespace iOS4Unity
{
    public class NSNumberFormatter : NSObject
    {
        private static readonly IntPtr _classHandle;

        static NSNumberFormatter()
        {
            _classHandle = ObjC.GetClass("NSNumberFormatter");
        }

        public override IntPtr ClassHandle 
        {
            get { return _classHandle; }
        }

        public NSNumberFormatter() : base() { }

        public NSNumberFormatterBehavior FormatterBehavior
        {
            get { return (NSNumberFormatterBehavior)(ObjC.MessageSendIntPtr(Handle, "formatterBehavior")); }
            set { ObjC.MessageSendIntPtr(Handle, "setFormatterBehavior:", (int)value); }
        }

        public bool AllowsFloats
        {
            get { return ObjC.MessageSendBool(Handle, "allowsFloats"); }
            set { ObjC.MessageSendBool(Handle, "setAllowsFloats:", value); }
        }

        public string CurrencyCode
        {
            get { return ObjC.MessageSendString(Handle, "currencyCode"); }
            set { ObjC.MessageSendString(Handle, "setCurrencyCode:", value); }
        }

        public string CurrencyDecimalSeparator
        {
            get { return ObjC.MessageSendString(Handle, "currencyDecimalSeparator"); }
            set { ObjC.MessageSendString(Handle, "setCurrencyDecimalSeparator:", value); }
        }

        public string CurrencyGroupingSeparator
        {
            get { return ObjC.MessageSendString(Handle, "currencyGroupingSeparator"); }
            set { ObjC.MessageSendString(Handle, "setCurrencyGroupingSeparator:", value); }
        }

        public string CurrencySymbol
        {
            get { return ObjC.MessageSendString(Handle, "currencySymbol"); }
            set { ObjC.MessageSendString(Handle, "setCurrencySymbol:", value); }
        }

        public string DecimalSeparator
        {
            get { return ObjC.MessageSendString(Handle, "decimalSeparator"); }
            set { ObjC.MessageSendString(Handle, "setDecimalSeparator:", value); }
        }

        public static NSNumberFormatterBehavior DefaultFormatterBehavior
        {
            get { return (NSNumberFormatterBehavior)(ObjC.MessageSendIntPtr(_classHandle, "defaultFormatterBehavior")); }
            set { ObjC.MessageSendIntPtr(_classHandle, "setDefaultFormatterBehavior:", (int)value); }
        }

        public string ExponentSymbol
        {
            get { return ObjC.MessageSendString(Handle, "exponentSymbol"); }
            set { ObjC.MessageSendString(Handle, "setExponentSymbol:", value); }
        }

        public uint FormatWidth
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "formatWidth"); }
            set { ObjC.MessageSend(Handle, "setFormatWidth:", value); }
        }

        public bool GeneratesDecimalNumbers
        {
            get { return ObjC.MessageSendBool(Handle, "generatesDecimalNumbers"); }
            set { ObjC.MessageSendBool(Handle, "setGeneratesDecimalNumbers:", value); }
        }

        public string GroupingSeparator
        {
            get { return ObjC.MessageSendString(Handle, "groupingSeparator"); }
            set { ObjC.MessageSendString(Handle, "setGroupingSeparator:", value); }
        }

        public uint GroupingSize
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "groupingSize"); }
            set { ObjC.MessageSend(Handle, "setGroupingSize:", value); }
        }

        public string InternationalCurrencySymbol
        {
            get { return ObjC.MessageSendString(Handle, "internationalCurrencySymbol"); }
            set { ObjC.MessageSendString(Handle, "setInternationalCurrencySymbol:", value); }
        }

        public bool Lenient
        {
            get { return ObjC.MessageSendBool(Handle, "isLenient"); }
            set { ObjC.MessageSendBool(Handle, "setLenient:", value); }
        }

        public NSLocale Locale
        {
            get { return new NSLocale(ObjC.MessageSendIntPtr(Handle, "locale")); }
            set { ObjC.MessageSend(Handle, "setLocale:", value.Handle); }
        }

        public int MaximumFractionDigits
        {
            get { return ObjC.MessageSendInt(Handle, "maximumFractionDigits"); }
            set { ObjC.MessageSend(Handle, "setMaximumFractionDigits:", value); }
        }

        public int MaximumIntegerDigits
        {
            get { return ObjC.MessageSendInt(Handle, "maximumIntegerDigits"); }
            set { ObjC.MessageSend(Handle, "setMaximumIntegerDigits:", value); }
        }

        public uint MaximumSignificantDigits
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "maximumSignificantDigits"); }
            set { ObjC.MessageSend(Handle, "setMaximumSignificantDigits:", value); }
        }

        public int MinimumFractionDigits
        {
            get { return ObjC.MessageSendInt(Handle, "minimumFractionDigits"); }
            set { ObjC.MessageSend(Handle, "setMinimumFractionDigits:", value); }
        }

        public int MinimumIntegerDigits
        {
            get { return ObjC.MessageSendInt(Handle, "minimumIntegerDigits"); }
            set { ObjC.MessageSend(Handle, "setMinimumIntegerDigits:", value); }
        }

        public uint MinimumSignificantDigits
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "minimumSignificantDigits"); }
            set { ObjC.MessageSend(Handle, "setMinimumSignificantDigits:", value); }
        }

        public string MinusSign
        {
            get { return ObjC.MessageSendString(Handle, "minusSign"); }
            set { ObjC.MessageSendString(Handle, "setMinusSign:", value); }
        }

        public string NegativeFormat
        {
            get { return ObjC.MessageSendString(Handle, "negativeFormat"); }
            set { ObjC.MessageSendString(Handle, "setNegativeFormat:", value); }
        }

        public string NegativeInfinitySymbol
        {
            get { return ObjC.MessageSendString(Handle, "negativeInfinitySymbol"); }
            set { ObjC.MessageSendString(Handle, "setNegativeInfinitySymbol:", value); }
        }

        public string NegativePrefix
        {
            get { return ObjC.MessageSendString(Handle, "negativePrefix"); }
            set { ObjC.MessageSendString(Handle, "setNegativePrefix:", value); }
        }

        public string NegativeSuffix
        {
            get { return ObjC.MessageSendString(Handle, "negativeSuffix"); }
            set { ObjC.MessageSendString(Handle, "setNegativeSuffix:", value); }
        }

        public string NilSymbol
        {
            get { return ObjC.MessageSendString(Handle, "nilSymbol"); }
            set { ObjC.MessageSendString(Handle, "setNilSymbol:", value); }
        }

        public string NotANumberSymbol
        {
            get { return ObjC.MessageSendString(Handle, "notANumberSymbol"); }
            set { ObjC.MessageSendString(Handle, "setNotANumberSymbol:", value); }
        }

        public NSNumberFormatterStyle NumberStyle
        {
            get { return (NSNumberFormatterStyle)(ObjC.MessageSendIntPtr(Handle, "numberStyle")); }
            set { ObjC.MessageSendIntPtr(Handle, "setNumberStyle:", (int)value); }
        }

        public string PaddingCharacter
        {
            get { return ObjC.MessageSendString(Handle, "paddingCharacter"); }
            set { ObjC.MessageSendString(Handle, "setPaddingCharacter:", value); }
        }

        public NSNumberFormatterPadPosition PaddingPosition
        {
            get { return (NSNumberFormatterPadPosition)(ObjC.MessageSendIntPtr(Handle, "paddingPosition")); }
            set { ObjC.MessageSendIntPtr(Handle, "setPaddingPosition:", (int)value); }
        }

        public bool PartialStringValidationEnabled
        {
            get { return ObjC.MessageSendBool(Handle, "isPartialStringValidationEnabled"); }
            set { ObjC.MessageSendBool(Handle, "setPartialStringValidationEnabled:", value); }
        }

        public string PercentSymbol
        {
            get { return ObjC.MessageSendString(Handle, "percentSymbol"); }
            set { ObjC.MessageSendString(Handle, "setPercentSymbol:", value); }
        }

        public string PerMillSymbol
        {
            get { return ObjC.MessageSendString(Handle, "perMillSymbol"); }
            set { ObjC.MessageSendString(Handle, "setPerMillSymbol:", value); }
        }

        public string PlusSign
        {
            get { return ObjC.MessageSendString(Handle, "plusSign"); }
            set { ObjC.MessageSendString(Handle, "setPlusSign:", value); }
        }

        public string PositiveFormat
        {
            get { return ObjC.MessageSendString(Handle, "positiveFormat"); }
            set { ObjC.MessageSendString(Handle, "setPositiveFormat:", value); }
        }

        public string PositiveInfinitySymbol
        {
            get { return ObjC.MessageSendString(Handle, "positiveInfinitySymbol"); }
            set { ObjC.MessageSendString(Handle, "setPositiveInfinitySymbol:", value); }
        }

        public string PositivePrefix
        {
            get { return ObjC.MessageSendString(Handle, "positivePrefix"); }
            set { ObjC.MessageSendString(Handle, "setPositivePrefix:", value); }
        }

        public string PositiveSuffix
        {
            get { return ObjC.MessageSendString(Handle, "positiveSuffix"); }
            set { ObjC.MessageSendString(Handle, "setPositiveSuffix:", value); }
        }

        public NSNumberFormatterRoundingMode RoundingMode
        {
            get { return (NSNumberFormatterRoundingMode)(ObjC.MessageSendIntPtr(Handle, "roundingMode")); }
            set { ObjC.MessageSendIntPtr(Handle, "setRoundingMode:", (int)value); }
        }

        public uint SecondaryGroupingSize
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "secondaryGroupingSize"); }
            set { ObjC.MessageSend(Handle, "setSecondaryGroupingSize:", value); }
        }

        public bool UsesGroupingSeparator
        {
            get { return ObjC.MessageSendBool(Handle, "usesGroupingSeparator"); }
            set { ObjC.MessageSendBool(Handle, "setUsesGroupingSeparator:", value); }
        }

        public bool UsesSignificantDigits
        {
            get { return ObjC.MessageSendBool(Handle, "usesSignificantDigits"); }
            set { ObjC.MessageSendBool(Handle, "setUsesSignificantDigits:", value); }
        }

        public string ZeroSymbol
        {
            get { return ObjC.MessageSendString(Handle, "zeroSymbol"); }
            set { ObjC.MessageSendString(Handle, "setZeroSymbol:", value); }
        }
    }

    public enum NSNumberFormatterBehavior
    {
        Default,
        Version_10_0 = 1000,
        Version_10_4 = 1040
    }

    public enum NSNumberFormatterStyle
    {
        None,
        Decimal,
        Currency,
        Percent,
        Scientific,
        SpellOut
    }

    public enum NSNumberFormatterPadPosition
    {
        BeforePrefix,
        AfterPrefix,
        BeforeSuffix,
        AfterSuffix
    }

    public enum NSNumberFormatterRoundingMode
    {
        Ceiling,
        Floor,
        Down,
        Up,
        HalfEven,
        HalfDown,
        HalfUp
    }
}
