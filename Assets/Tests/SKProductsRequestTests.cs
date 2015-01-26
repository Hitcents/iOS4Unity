using System;
using System.Text;
using iOS4Unity;
using NUnit.Framework;

[TestFixture]
public class SKProductsRequestTests 
{
    [Test]
    public void NewObject()
    {
        var obj = new SKProductsRequest("woot");

        Assert.AreNotEqual(IntPtr.Zero, obj.ClassHandle);
        Assert.AreNotEqual(IntPtr.Zero, obj.Handle);
    }

    [Test]
    public void NewObjectDispose()
    {
        var obj = new SKProductsRequest("woot");
        obj.Dispose();
    }

    [Test]
    public void ObjectSame()
    {
        var a = new SKProductsRequest("woot");
        var b = Runtime.GetNSObject<SKProductsRequest>(a.Handle);
        Assert.AreSame(a, b);
    }

    [Test]
    public void Start()
    {
        string productId = "woot";
        var request = new SKProductsRequest(productId);
        request.ReceivedResponse += (sender, e) => 
        {
            Assert.AreEqual(productId, e.Response.InvalidProducts[0]);
            Console.WriteLine("Received Response!");
        };
        request.Failed += (sender, e) => 
        {
            Console.WriteLine("Failed: " + e.Error.LocalizedDescription);
        };
        request.Finished += (sender, e) => 
        {
            Console.WriteLine("Finished!");
        };
        request.Start();
    }
}
