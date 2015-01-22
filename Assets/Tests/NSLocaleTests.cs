using System;
using NUnit.Framework;
using iOS4Unity;

[TestFixture]
public class NSLocaleTests
{
    [Test]
    public void NSLocaleTest()
    {
        var locale = NSLocale.CurrentLocale;
        Assert.AreNotEqual(IntPtr.Zero, locale);
    }

    [Test]
    public void NSLocaleDispose()
    {
        var locale = NSLocale.CurrentLocale;
        locale.Dispose();
    }

    [Test]
    public void AutoUpdatingCurrentLocale()
    {
        var locale = NSLocale.AutoUpdatingCurrentLocale;
        Assert.AreNotEqual(IntPtr.Zero, locale);
    }

    [Test]
    public void AvailableLocaleIdentifiers()
    {
        var availableLocaleId = NSLocale.AvailableLocaleIdentifiers;
        Assert.AreNotEqual(0, availableLocaleId.Length);
    }

    [Test]
    public void CollationIdentifier()
    {
        var collationId = NSLocale.CurrentLocale.CollationIdentifier;
        Assert.AreNotSame(string.Empty, collationId);
    }

    [Test]
    public void CollatorIdentifier()
    {
        var collatorId = NSLocale.CurrentLocale.CollatorIdentifier;
        Assert.AreNotSame(string.Empty, collatorId);
    }

    [Test]
    public void CommonISOCurrencyCodes()
    {
        var commonISOCurrencyCodes = NSLocale.CommonISOCurrencyCodes;
        Assert.AreNotEqual(0, commonISOCurrencyCodes.Length);
    }

    [Test]
    public void CountryCode()
    {
        var countryCode = NSLocale.CurrentLocale.CountryCode;
        Assert.AreNotSame(string.Empty, countryCode);
    }

    [Test]
    public void CurrencyCode()
    {
        var currencyCode = NSLocale.CurrentLocale.CurrencyCode;
        Assert.AreNotSame(string.Empty, currencyCode);
    }

    [Test]
    public void CurrencySymbol()
    {
        var currencySymbol = NSLocale.CurrentLocale.CurrencySymbol;
        Assert.AreNotSame(string.Empty, currencySymbol);
    }

    [Test]
    public void DecimalSeparator()
    {
        var decimalSeparator = NSLocale.CurrentLocale.DecimalSeparator;
        Assert.AreNotSame(string.Empty, decimalSeparator);
    }

    [Test]
    public void GroupingSeparator()
    {
        var groupingSeparator = NSLocale.CurrentLocale.GroupingSeparator;
        Assert.AreNotSame(string.Empty, groupingSeparator);
    }

    [Test]
    public void Identifier()
    {
        var id = NSLocale.CurrentLocale.Identifier;
        Assert.AreNotSame(string.Empty, id);
    }

    [Test]
    public void ISOCountryCodes()
    {
        var countryCodes = NSLocale.ISOCountryCodes;
        Assert.AreNotEqual(0, countryCodes.Length);
    }

    [Test]
    public void ISOCurrencyCodes()
    {
        var currencyCodes = NSLocale.ISOCurrencyCodes;
        Assert.AreNotEqual(0, currencyCodes.Length);
    }

    [Test]
    public void ISOLanguageCodes()
    {
        var languageCodes = NSLocale.ISOLanguageCodes;
        Assert.AreNotEqual(0, languageCodes.Length);
    }

    [Test]
    public void LanguageCode()
    {
        var languageCode = NSLocale.CurrentLocale.LanguageCode;
        Assert.AreNotSame(string.Empty, languageCode);
    }

    public void LocaleIdentifier()
    {
        var localId = NSLocale.CurrentLocale.LocaleIdentifier;
        Assert.AreNotSame(string.Empty, localId);
    }

    [Test]
    public void MeasurementSystem()
    {
        var measurementSystem = NSLocale.CurrentLocale.MeasurementSystem;
        Assert.AreNotSame(string.Empty, measurementSystem);
    }

    public void PreferredLanguages()
    {
        var preferredLanguages = NSLocale.PreferredLanguages;
        Assert.AreNotEqual(0, preferredLanguages.Length);
    }

    [Test]
    public void ScriptCode()
    {
        var scriptCode = NSLocale.CurrentLocale.ScriptCode;
        Assert.AreNotSame(string.Empty, scriptCode);
    }

    [Test]
    public void SystemLocale()
    {
        var systemLocale = NSLocale.SystemLocale;
        Assert.AreNotEqual(IntPtr.Zero, systemLocale);
    }

    [Test]
    public void UsesMetricSystem()
    {
        //Make sure it doesn't crash
        NSLocale.CurrentLocale.UsesMetricSystem.ToString();
    }
}
