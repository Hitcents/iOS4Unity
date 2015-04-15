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
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        Assert.AreEqual(3, dictionary.Count);
    }

    [Test]
    public void ObjectsForKeys()
    {
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        var value = dictionary.ObjectsForKeys(new string[] { keys[0], keys[1] });
        Assert.AreSame(dictionary.ObjectForKey(keys[0]), value[0]);
        Assert.AreSame(dictionary.ObjectForKey(keys[1]), value[1]);
        Assert.AreEqual(2, value.Length);
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
    public void Keys()
    {
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        Assert.AreEqual(3, dictionary.Keys.Length);
    }

    [Test]
    public void Values()
    {
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        Assert.AreEqual(3, dictionary.Values.Length);
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

    [Test]
    public void ContainsKey()
    {
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        bool contains = dictionary.ContainsKey(keys[0]);
        bool doesntContain = dictionary.ContainsKey("test");
        Assert.IsTrue(contains);
        Assert.IsFalse(doesntContain);
    }

    [Test]
    public void CreateDictionary()
    {
        string[] keys = { "WOOOTSDLKFJSDLKFDS:", "alsudhflka", "lknadlnladnf" };
        NSObject[] objects = { new NSObject(), new NSObject(), new NSObject() };
        var dictionary = NSDictionary.FromObjectsAndKeys(objects, keys);
        var newDictionary = NSDictionary.FromDictionary(dictionary);
        Assert.AreEqual(3, newDictionary.Values.Length);
        Assert.AreEqual(3, newDictionary.Keys.Length);
    }
}