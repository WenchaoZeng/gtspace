/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace gtspace.Common
{
	/// <summary>
	/// Xml帮助器
	/// </summary>
	public class XmlHelper
	{
		/// <summary>
		/// 加载Xml文件并读取根节点
		/// </summary>
		/// <param name="path">Xml文件路径</param>
		/// <returns>Xml的根节点</returns>
		public XmlElement Load(string path)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(path);
				return doc.DocumentElement;
			}
			catch (Exception)
			{
				// 忽视错误
				return null;
			}
		}

		/// <summary>
		/// 读取一个节点的子节点的内容
		/// </summary>
		/// <param name="node">当前节点</param>
		/// <param name="childName">子节点名称</param>
		/// <returns>节点内容</returns>
		public string ReadChild(XmlElement node, string childName)
		{
			XmlNodeList childs = node.GetElementsByTagName(childName);
			if (childs.Count > 0)
			{
				return childs[0].InnerText;
			}
			return string.Empty;
		}

		/// <summary>
		/// 读取节点的属性
		/// </summary>
		/// <param name="node">当前节点</param>
		/// <param name="name">属性名</param>
		/// <returns>属性值</returns>
		public string ReadAttribute(XmlNode node, string name)
		{
			return node.Attributes[name] != null ? node.Attributes[name].Value : string.Empty;
		}
	}
}
