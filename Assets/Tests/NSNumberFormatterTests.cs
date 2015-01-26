using System;
using NUnit.Framework;
using iOS4Unity;

[TestFixture]
public class NSNumberFormatterTests
{
    [Test]
    public void NewObject()
    {
        var obj = new NSNumberFormatter();

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new NSNumberFormatter();
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new NSNumberFormatter();
        var b = Runtime.GetNSObject<NSNumberFormatter>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void FormatterBehavior()
    {
        var formatterBehavior = new NSNumberFormatter();
        Assert.AreEqual(NSNumberFormatterBehavior.Version_10_4, formatterBehavior.FormatterBehavior);
    }

    [Test]
    public void AllowsFloats()
    {
        var allowsFloats = new NSNumberFormatter();
        Assert.AreEqual(false, allowsFloats.AllowsFloats);
    }

    [Test]
    public void CurrencyCode()
    {
        var currencyCode = new NSNumberFormatter().CurrencyCode;
        Assert.AreNotEqual(string.Empty, currencyCode);
    }

    [Test]
    public void CurrencyDecimalSeparator()
    {
        var separator = new NSNumberFormatter().CurrencyDecimalSeparator;
        Assert.AreNotEqual(string.Empty, separator);
    }

    [Test]
    public void CurrencyGroupingSeparator()
    {
        var separator = new NSNumberFormatter().CurrencyGroupingSeparator;
        Assert.AreNotEqual(string.Empty, separator);
    }

    [Test]
    public void CurrencySymbol()
    {
        var symbol = new NSNumberFormatter().CurrencySymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void DecimalSeparator()
    {
        var separator = new NSNumberFormatter().DecimalSeparator;
        Assert.AreNotEqual(string.Empty, separator);
    }

    [Test]
    public void DefaultFormatterBehavior()
    {
        var formatterBehavior = NSNumberFormatter.DefaultFormatterBehavior;
        Assert.AreNotEqual(IntPtr.Zero, formatterBehavior);
    }

    [Test]
    public void ExponentSymbol()
    {
        var symbol = new NSNumberFormatter().ExponentSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void FormatWidth()
    {
        var formatterWidth = new NSNumberFormatter().FormatWidth;
        Assert.AreEqual(0, formatterWidth);
    }

    [Test]
    public void GeneratesDecimalNumbers()
    {
        //Test to make sure it doesn't crash
        new NSNumberFormatter().GeneratesDecimalNumbers.ToString();
    }

    [Test]
    public void GroupingSeparator()
    {
        var separator = new NSNumberFormatter().GroupingSeparator;
        Assert.AreNotEqual(string.Empty, separator);
    }

    [Test]
    public void GroupingSize()
    {
        var size = new NSNumberFormatter().GroupingSize;
        Assert.AreNotEqual(0, size);
    }

    [Test]
    public void InternationalCurrencySymbol()
    {
        var symbol = new NSNumberFormatter().InternationalCurrencySymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void Lenient()
    {
        //Test to make sure it doesn't crash
		new NSNumberFormatter().Lenient.ToString();
    }

    [Test]
    public void Locale()
    {
        var locale = new NSNumberFormatter().Locale;
        Assert.IsNotNull(locale);
    }

    [Test]
    public void MaximumFractionDigits()
    {
        var digits = new NSNumberFormatter().MaximumFractionDigits;
        Assert.AreNotEqual(-1, digits);
    }

    [Test]
    public void MaximumIntegerDigits()
    {
        var digits = new NSNumberFormatter().MaximumIntegerDigits;
        Assert.AreNotEqual(0, digits);
    }

    [Test]
    public void MaximumSignificantDigits()
    {
        var digits = new NSNumberFormatter().MaximumSignificantDigits;
        Assert.AreNotEqual(0, digits);
    }

    [Test]
    public void MinimumFractionDigits()
    {
        var digits = new NSNumberFormatter().MinimumFractionDigits;
        Assert.AreNotSame(-1, digits);
    }

    [Test]
    public void MinimumIntegerDigits()
    {
        var digits = new NSNumberFormatter().MinimumIntegerDigits;
        Assert.AreNotSame(-1, digits);
    }

    [Test]
    public void MinimumSignificantDigits()
    {
        var digits = new NSNumberFormatter().MinimumSignificantDigits;
        Assert.AreNotSame(-1, digits);
    }

    [Test]
    public void MinusSign()
    {
        var symbol = new NSNumberFormatter().MinusSign;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void NegativeFormat()
    {
        var format = new NSNumberFormatter().NegativeFormat;
        Assert.AreNotEqual(string.Empty, format);
    }

    [Test]
    public void NegativeInfinitySymbol()
    {
        var symbol = new NSNumberFormatter().NegativeInfinitySymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void NegativePrefix()
    {
        var prefix = new NSNumberFormatter().NegativePrefix;
        Assert.AreNotEqual(string.Empty, prefix);
    }

    [Test]
    public void NegativeSuffix()
    {
        var suffix = new NSNumberFormatter().NegativeSuffix;
        Assert.AreEqual(string.Empty, suffix);
    }

    [Test]
    public void NilSymbol()
    {
        var symbol = new NSNumberFormatter().NilSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void NotANumberSymbol()
    {
        var symbol = new NSNumberFormatter().NotANumberSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void NumberStyle()
    {
        var numberStyle = new NSNumberFormatter().NumberStyle;
        numberStyle = NSNumberFormatterStyle.Currency;
        Assert.AreEqual(NSNumberFormatterStyle.Currency, numberStyle);
    }

    [Test]
    public void PaddingCharacter()
    {
        var symbol = new NSNumberFormatter().PaddingCharacter;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PaddingPosition()
    {
        var paddingPosition = new NSNumberFormatter().PaddingPosition;
        paddingPosition = NSNumberFormatterPadPosition.BeforePrefix;
        Assert.AreEqual(NSNumberFormatterPadPosition.BeforePrefix, paddingPosition);
    }

    [Test]
    public void PartialStringValidationEnabled()
    {
        //Test to make sure it doesn't crash
		new NSNumberFormatter().PartialStringValidationEnabled.ToString();
    }

    [Test]
    public void PercentSymbol()
    {
        var symbol = new NSNumberFormatter().PercentSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PerMillSymbol()
    {
        var symbol = new NSNumberFormatter().PerMillSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PlusSign()
    {
        var symbol = new NSNumberFormatter().PlusSign;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PositiveFormat()
    {
        var symbol = new NSNumberFormatter().PositiveFormat;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PositiveInfinitySymbol()
    {
        var symbol = new NSNumberFormatter().PositiveInfinitySymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void PositivePrefix()
    {
        var prefix = new NSNumberFormatter().PositivePrefix;
        Assert.AreEqual(string.Empty, prefix);
    }

    [Test]
    public void PositiveSuffix()
    {
        var suffix = new NSNumberFormatter().PositivePrefix;
        Assert.AreEqual(string.Empty, suffix);
    }

    [Test]
    public void RoundingMode()
    {
        var roundingMode = new NSNumberFormatter().RoundingMode;
        roundingMode = NSNumberFormatterRoundingMode.Down;
        Assert.AreEqual(NSNumberFormatterRoundingMode.Down, roundingMode);
    }

    [Test]
    public void SecondaryGroupingSize()
    {
        var digits = new NSNumberFormatter().MinimumSignificantDigits;
        Assert.AreNotSame(0, digits);
    }

    [Test]
    public void UsesGroupingSeparator()
    {
        //Test to make sure it doesn't crash
		new NSNumberFormatter().UsesGroupingSeparator.ToString();
    }

    [Test]
    public void UsesSignificantDigits()
    {
        //Test to make sure it doesn't crash
		new NSNumberFormatter().UsesSignificantDigits.ToString();
    }

    [Test]
    public void ZeroSymbol()
    {
        var symbol = new NSNumberFormatter().ZeroSymbol;
        Assert.AreNotEqual(string.Empty, symbol);
    }

    [Test]
    public void NumberFromString()
    {
        var numberFromString = new NSNumberFormatter().NumberFromString("1");
        Assert.AreEqual(1, numberFromString);
    }

    [Test]
    public void StringFromNumber()
    {
        var stringFromNumber = new NSNumberFormatter().StringFromNumber(1);
        Assert.AreEqual("1", stringFromNumber);
    }

    [Test]
    public void LocalizedStringFromNumber()
    {
        var stringFromNumber = NSNumberFormatter.LocalizedStringFromNumber(1, NSNumberFormatterStyle.Decimal);
        Assert.AreEqual("1", stringFromNumber);
    }
}
