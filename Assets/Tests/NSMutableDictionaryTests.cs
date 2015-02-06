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
    public void FromObjectsAndKeys()
    {
        string[] keys = {"WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf"};
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject()};
        var dictionary = NSMutableDictionary.FromObjectsAndKeys(objects, keys);
        Assert.AreEqual(3, dictionary.Count);
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

    [Test]
    public void DictionaryCount()
    {
        string key1 = "WOOOTSDLKFJSDLKFDS:";
        var value1 = new NSObject();
        string key2 = "afahdfasdfasdf:";
        var value2 = new NSObject();
        var dictionary = new NSMutableDictionary();
        dictionary.SetObjectForKey(value1, key1);
        dictionary.SetObjectForKey(value2, key2);

        Assert.AreEqual(2, dictionary.Count);
    }

    [Test]
    public void RemoveFromDictionary()
    {
        string key1 = "WOOOTSDLKFJSDLKFDS:";
        var value1 = new NSObject();
        string key2 = "afahdfasdfasdf:";
        var value2 = new NSObject();
        var dictionary = new NSMutableDictionary();
        dictionary.SetObjectForKey(value1, key1);
        dictionary.SetObjectForKey(value2, key2);
        dictionary.RemoveObjectForKey(key1);

        Assert.AreEqual(1, dictionary.Count);
    }

    [Test]
    public void CreateMutableDictionary()
    {
        string[] keys = {"WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf"};
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        var mutableDictionary = NSMutableDictionary.CreateMutableDictionary(dictionary);
        Assert.AreEqual(3, mutableDictionary.Values.Length);
        Assert.AreEqual(3, mutableDictionary.Keys.Length);
    }

    [Test]
    public void ClearDictionary()
    {
        string key1 = "WOOOTSDLKFJSDLKFDS:";
        var value1 = new NSObject();
        string key2 = "afahdfasdfasdf:";
        var value2 = new NSObject();
        var dictionary = new NSMutableDictionary();
        dictionary.SetObjectForKey(value1, key1);
        dictionary.SetObjectForKey(value2, key2);
        dictionary.Clear();

        Assert.AreEqual(0,  dictionary.Count);
    }
}