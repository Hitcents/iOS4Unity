using System;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class NSDictionaryTests
{
    [Test]
    public void FromObjectAndKey()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = NSDictionary.FromObjectAndKey(value, key);
        var actual = dictionary.ObjectForKey(key);
        Assert.AreEqual(value.Handle, actual.Handle);
        Assert.AreSame(value, actual);
    }

    [Test]
    public void FromObjectsAndKeys()
    {
        string[] keys = {"WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf"};
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        Assert.AreEqual(3, dictionary.Count);
    }

    [Test]
    public void DictionaryCount()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = NSDictionary.FromObjectAndKey(value, key);

        Assert.AreEqual(1, dictionary.Count);
    }

    [Test]
    public void Indexer()
    {
        string key = "WOOOTSDLKFJSDLKFDS:";
        var value = new NSObject();
        var dictionary = NSDictionary.FromObjectAndKey(value, key);
        var actual = dictionary[key];
        Assert.AreEqual(value.Handle, actual.Handle);
        Assert.AreSame(value, actual);
    }
}
