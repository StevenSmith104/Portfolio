using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLPlayerFileReader 
{

	public static void SavePositionToXMLFile(int[,,] playerTransform, int[,,] playerRotation, string fileName)
	{
		XmlWriterSettings writerSettings = new XmlWriterSettings ();
		writerSettings.Indent = true;

		XmlWriter xmlWriter = XmlWriter.Create (fileName + ".xml", writerSettings);
		xmlWriter.WriteStartDocument ();
		xmlWriter.WriteStartElement ("Transform");


	}
}
