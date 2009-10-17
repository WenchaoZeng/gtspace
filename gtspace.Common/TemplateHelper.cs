/// Created by zwc at 2009年10月16日
/// Modified by zwc at 2009年10月17日, 实现了Load方法
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

			XmlElement root = Utilitys.Xml.Load(path);

			if (root == null || root.Name != "template")
			{
				throw new LogicException("不是一个有效的模板配置文件");
			}

			// 读取基本信息
			info.Name = Utilitys.Xml.ReadChild(root, "name");
			info.Version = Utilitys.Xml.ReadChild(root, "version");
			info.Author = Utilitys.Xml.ReadChild(root, "author");
			info.CopyRight = Utilitys.Xml.ReadChild(root, "copyright");
			info.ScreenShot = Utilitys.Xml.ReadChild(root, "screenshot");
			info.Description = Utilitys.Xml.ReadChild(root, "description");

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
				rewriterule.From = Utilitys.Xml.ReadAttribute(rule, "from");
				rewriterule.To = "~/Templates/" + info.Directory + "/" + Utilitys.Xml.ReadAttribute(rule, "to");
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
	}
}
