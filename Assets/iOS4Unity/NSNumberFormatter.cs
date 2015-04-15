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

        public NSNumberFormatter()
        {
        }

        internal NSNumberFormatter(IntPtr handle)
            : base(handle)
        {
        }

        public NSNumberFormatterBehavior FormatterBehavior
        {
            get { return (NSNumberFormatterBehavior)(ObjC.MessageSendInt(Handle, "formatterBehavior")); }
            set { ObjC.MessageSend(Handle, "setFormatterBehavior:", (int)value); }
        }

        public bool AllowsFloats
        {
            get { return ObjC.MessageSendBool(Handle, "allowsFloats"); }
            set { ObjC.MessageSend(Handle, "setAllowsFloats:", value); }
        }

        public string CurrencyCode
        {
            get { return ObjC.MessageSendString(Handle, "currencyCode"); }
            set { ObjC.MessageSend(Handle, "setCurrencyCode:", value); }
        }

        public string CurrencyDecimalSeparator
        {
            get { return ObjC.MessageSendString(Handle, "currencyDecimalSeparator"); }
            set { ObjC.MessageSend(Handle, "setCurrencyDecimalSeparator:", value); }
        }

        public string CurrencyGroupingSeparator
        {
            get { return ObjC.MessageSendString(Handle, "currencyGroupingSeparator"); }
            set { ObjC.MessageSend(Handle, "setCurrencyGroupingSeparator:", value); }
        }

        public string CurrencySymbol
        {
            get { return ObjC.MessageSendString(Handle, "currencySymbol"); }
            set { ObjC.MessageSend(Handle, "setCurrencySymbol:", value); }
        }

        public string DecimalSeparator
        {
            get { return ObjC.MessageSendString(Handle, "decimalSeparator"); }
            set { ObjC.MessageSend(Handle, "setDecimalSeparator:", value); }
        }

        public static NSNumberFormatterBehavior DefaultFormatterBehavior
        {
            get { return (NSNumberFormatterBehavior)(ObjC.MessageSendInt(_classHandle, "defaultFormatterBehavior")); }
            set { ObjC.MessageSend(_classHandle, "setDefaultFormatterBehavior:", (int)value); }
        }

        public string ExponentSymbol
        {
            get { return ObjC.MessageSendString(Handle, "exponentSymbol"); }
            set { ObjC.MessageSend(Handle, "setExponentSymbol:", value); }
        }

        public uint FormatWidth
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "formatWidth"); }
            set { ObjC.MessageSend(Handle, "setFormatWidth:", value); }
        }

        public bool GeneratesDecimalNumbers
        {
            get { return ObjC.MessageSendBool(Handle, "generatesDecimalNumbers"); }
            set { ObjC.MessageSend(Handle, "setGeneratesDecimalNumbers:", value); }
        }

        public string GroupingSeparator
        {
            get { return ObjC.MessageSendString(Handle, "groupingSeparator"); }
            set { ObjC.MessageSend(Handle, "setGroupingSeparator:", value); }
        }

        public uint GroupingSize
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "groupingSize"); }
            set { ObjC.MessageSend(Handle, "setGroupingSize:", value); }
        }

        public string InternationalCurrencySymbol
        {
            get { return ObjC.MessageSendString(Handle, "internationalCurrencySymbol"); }
            set { ObjC.MessageSend(Handle, "setInternationalCurrencySymbol:", value); }
        }

        public bool Lenient
        {
            get { return ObjC.MessageSendBool(Handle, "isLenient"); }
            set { ObjC.MessageSend(Handle, "setLenient:", value); }
        }

        public NSLocale Locale
        {
            get { return Runtime.GetNSObject<NSLocale>(ObjC.MessageSendIntPtr(Handle, "locale")); }
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
            set { ObjC.MessageSend(Handle, "setMinusSign:", value); }
        }

        public string NegativeFormat
        {
            get { return ObjC.MessageSendString(Handle, "negativeFormat"); }
            set { ObjC.MessageSend(Handle, "setNegativeFormat:", value); }
        }

        public string NegativeInfinitySymbol
        {
            get { return ObjC.MessageSendString(Handle, "negativeInfinitySymbol"); }
            set { ObjC.MessageSend(Handle, "setNegativeInfinitySymbol:", value); }
        }

        public string NegativePrefix
        {
            get { return ObjC.MessageSendString(Handle, "negativePrefix"); }
            set { ObjC.MessageSend(Handle, "setNegativePrefix:", value); }
        }

        public string NegativeSuffix
        {
            get { return ObjC.MessageSendString(Handle, "negativeSuffix"); }
            set { ObjC.MessageSend(Handle, "setNegativeSuffix:", value); }
        }

        public string NilSymbol
        {
            get { return ObjC.MessageSendString(Handle, "nilSymbol"); }
            set { ObjC.MessageSend(Handle, "setNilSymbol:", value); }
        }

        public string NotANumberSymbol
        {
            get { return ObjC.MessageSendString(Handle, "notANumberSymbol"); }
            set { ObjC.MessageSend(Handle, "setNotANumberSymbol:", value); }
        }

        public NSNumberFormatterStyle NumberStyle
        {
            get { return (NSNumberFormatterStyle)(ObjC.MessageSendInt(Handle, "numberStyle")); }
            set { ObjC.MessageSend(Handle, "setNumberStyle:", (int)value); }
        }

        public string PaddingCharacter
        {
            get { return ObjC.MessageSendString(Handle, "paddingCharacter"); }
            set { ObjC.MessageSend(Handle, "setPaddingCharacter:", value); }
        }

        public NSNumberFormatterPadPosition PaddingPosition
        {
            get { return (NSNumberFormatterPadPosition)ObjC.MessageSendInt(Handle, "paddingPosition"); }
            set { ObjC.MessageSend(Handle, "setPaddingPosition:", (int)value); }
        }

        public bool PartialStringValidationEnabled
        {
            get { return ObjC.MessageSendBool(Handle, "isPartialStringValidationEnabled"); }
            set { ObjC.MessageSend(Handle, "setPartialStringValidationEnabled:", value); }
        }

        public string PercentSymbol
        {
            get { return ObjC.MessageSendString(Handle, "percentSymbol"); }
            set { ObjC.MessageSend(Handle, "setPercentSymbol:", value); }
        }

        public string PerMillSymbol
        {
            get { return ObjC.MessageSendString(Handle, "perMillSymbol"); }
            set { ObjC.MessageSend(Handle, "setPerMillSymbol:", value); }
        }

        public string PlusSign
        {
            get { return ObjC.MessageSendString(Handle, "plusSign"); }
            set { ObjC.MessageSend(Handle, "setPlusSign:", value); }
        }

        public string PositiveFormat
        {
            get { return ObjC.MessageSendString(Handle, "positiveFormat"); }
            set { ObjC.MessageSend(Handle, "setPositiveFormat:", value); }
        }

        public string PositiveInfinitySymbol
        {
            get { return ObjC.MessageSendString(Handle, "positiveInfinitySymbol"); }
            set { ObjC.MessageSend(Handle, "setPositiveInfinitySymbol:", value); }
        }

        public string PositivePrefix
        {
            get { return ObjC.MessageSendString(Handle, "positivePrefix"); }
            set { ObjC.MessageSend(Handle, "setPositivePrefix:", value); }
        }

        public string PositiveSuffix
        {
            get { return ObjC.MessageSendString(Handle, "positiveSuffix"); }
            set { ObjC.MessageSend(Handle, "setPositiveSuffix:", value); }
        }

        public NSNumberFormatterRoundingMode RoundingMode
        {
            get { return (NSNumberFormatterRoundingMode)ObjC.MessageSendInt(Handle, "roundingMode"); }
            set { ObjC.MessageSend(Handle, "setRoundingMode:", (int)value); }
        }

        public uint SecondaryGroupingSize
        {
            get { return (uint)ObjC.MessageSendUInt(Handle, "secondaryGroupingSize"); }
            set { ObjC.MessageSend(Handle, "setSecondaryGroupingSize:", value); }
        }

        public bool UsesGroupingSeparator
        {
            get { return ObjC.MessageSendBool(Handle, "usesGroupingSeparator"); }
            set { ObjC.MessageSend(Handle, "setUsesGroupingSeparator:", value); }
        }

        public bool UsesSignificantDigits
        {
            get { return ObjC.MessageSendBool(Handle, "usesSignificantDigits"); }
            set { ObjC.MessageSend(Handle, "setUsesSignificantDigits:", value); }
        }

        public string ZeroSymbol
        {
            get { return ObjC.MessageSendString(Handle, "zeroSymbol"); }
            set { ObjC.MessageSend(Handle, "setZeroSymbol:", value); }
        }

        public double NumberFromString(string text)
        {
            return ObjC.FromNSNumber(ObjC.MessageSendIntPtr(Handle, "numberFromString:", text));
        }

        public string StringFromNumber(double number)
        {
            IntPtr handle = ObjC.ToNSNumber(number);
            string text = ObjC.MessageSendString(Handle, "stringFromNumber:", handle);
            ObjC.MessageSend(handle, "release");
            return text;
        }

        public static string LocalizedStringFromNumber(double number, NSNumberFormatterStyle style)
        {
            IntPtr handle = ObjC.ToNSNumber(number);
            string text = ObjC.MessageSendString(_classHandle, "localizedStringFromNumber:numberStyle:", handle, (int)style);
            ObjC.MessageSend(handle, "release");
            return text;
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