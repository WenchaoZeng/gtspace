/// Created by zwc at 2009年10月16日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gtspace.Entity;
using System.Xml;
using Glassesol.Entity;
using System.IO;

namespace gtspace.Common
{
	/// <summary>
	/// 模板帮助器
	/// </summary>
	public class TemplateHelper
	{
		/// <summary>
		/// 从一个模板配置文件里读取配置信息, 如果配置文件不存在则返回null
		/// </summary>
		/// <param name="path">配置文件的物理绝对路径</param>
		/// <returns>模板配置信息</returns>
		public TemplateInfo Load(string path)
		{
			if (!File.Exists(path))
			{
				throw new LogicException("配置文件不存在");
			}

			TemplateInfo info = new TemplateInfo();

			// 目录名称
			info.Directory = Path.GetFileName(Path.GetDirectoryName(path));

			XmlDocument doc = new XmlDocument();
			doc.Load(path);
			XmlElement root = doc.DocumentElement;

			if (root.Name != "template")
			{
				throw new LogicException("不是一个有效的模板配置文件");
			}

			// 读取基本信息
			info.Name = readChild(root, "name");
			info.Version = readChild(root, "version");
			info.Author = readChild(root, "author");
			info.CopyRight = readChild(root, "copyright");
			info.ScreenShot = readChild(root, "screenshot");
			info.Description = readChild(root, "description");

			// 读取Url重写规则
			info.RewriteRules = new List<RewriteRule>();
			XmlNodeList rewrites = root.GetElementsByTagName("rewrites");
			if (rewrites.Count <= 0)
			{
				throw new LogicException("模板配置文件必须要有Url重写规则");
			}
			XmlNodeList rules = rewrites[0].SelectNodes("rule");
			if (rules.Count <= 0)
			{
				throw new LogicException("模板配置文件必须要有Url重写规则");
			}
			foreach (XmlNode rule in rules)
			{
				RewriteRule rewriterule = new RewriteRule();
				rewriterule.From = readAttribute(rule, "from");
				rewriterule.To = readAttribute(rule, "to");
				info.RewriteRules.Add(rewriterule);
			}

			return info;
		}

		/// <summary>
		/// 读取所有模板信息
		/// </summary>
		/// <returns>模板列表</returns>
		public List<TemplateInfo> LoadAll()
		{
			throw new NotImplementedException("没有写这个函数");
		}

		/// <summary>
		/// 读取一个节点的子节点的内容
		/// </summary>
		/// <param name="node">当前节点</param>
		/// <param name="childName">子节点名称</param>
		/// <returns>节点内容</returns>
		string readChild(XmlElement node, string childName)
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
		string readAttribute(XmlNode node, string name)
		{
			return node.Attributes[name] != null ? node.Attributes[name].Value : string.Empty;
		}
	}
}
