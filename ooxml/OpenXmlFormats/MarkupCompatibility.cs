using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NPOI.OpenXmlFormats
{

	/// <summary>
	/// A adapter si besoin de modifier le contenu
	/// Visible dans le cas de groupement d'images
	/// </summary>
	public class CT_AlternateContent
	{
		public string innerXml { get; set; }
		public CT_AlternateContent()
		{
		}
		public static CT_AlternateContent Parse(XmlNode node, XmlNamespaceManager namespaceManager)
		{
			if (node == null)
				return null;

			var ac = new CT_AlternateContent();
			if (string.IsNullOrEmpty(node.InnerXml))
			{
				return ac;
			}
			ac.innerXml = node.InnerXml;
			return ac;
		}
		public void Write(StreamWriter sw, string nodeName)
		{
			sw.Write(string.Format("<mc:{0} xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"", nodeName));
			if (this.innerXml == null)
			{
				sw.Write(string.Format("/>", nodeName));
			}
			else
			{
				sw.Write(">");
				sw.Write(this.innerXml);
				sw.Write(string.Format("</mc:{0}>", nodeName));
			}

		}

	}
}
