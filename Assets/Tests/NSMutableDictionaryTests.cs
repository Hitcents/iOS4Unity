using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSMutableDictionaryTests
{
    [Test]
    public void FromObjectAndKey()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = NSMutableDictionary.FromObjectAndKey(value, key);
        var actual = dictionary.ObjectForKey(key);
        Assert.AreEqual(value.Handle, actual.Handle);
        Assert.AreSame(value, actual);
    }

    [Test]
    public void Indexer()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = NSMutableDictionary.FromObjectAndKey(value, key);
        var actual = dictionary[key];
        Assert.AreEqual(value.Handle, actual.Handle);
        Assert.AreSame(value, actual);
    }

    [Test]
    public void AddToDictionary()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = new NSMutableDictionary();
        dictionary.SetObjectForKey(value, key);
        var actual = dictionary[key];
        Assert.AreEqual(value.Handle, actual.Handle);
        Assert.AreSame(value, actual);
    }
}