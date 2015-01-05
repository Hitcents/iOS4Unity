using NUnit.Framework;

[TestFixture]
public class NSObjectTests 
{
	[Test]
	public void NewObject()
	{
		new NSObject();
	}

	[Test]
	public void NewObjectDispose()
	{
		var obj = new NSObject();
		obj.Dispose();
	}
}
