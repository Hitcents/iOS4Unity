using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;

[InitializeOnLoad]
public static class UnsafeProjectProcessor
{
	static UnsafeProjectProcessor()
	{
		foreach (var project in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csproj")) 
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(project);
			
			XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
			ns.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");
			
			var node = xml.SelectSingleNode("/x:Project/x:PropertyGroup", ns);
			if (node != null)
			{
				var unsafeNode = node.SelectSingleNode("x:AllowUnsafeBlocks", ns);
				if (unsafeNode == null)
				{
					var element = xml.CreateNode (XmlNodeType.Element, "AllowUnsafeBlocks", "http://schemas.microsoft.com/developer/msbuild/2003");
					element.InnerText = "True";
					node.AppendChild(element);
					
					xml.Save(project); 
				}
			}
		}
	}
}
