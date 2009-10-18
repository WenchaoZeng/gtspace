/// Created by zwc at 2009年10月16日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace gtspace.Common.Entity
{
	/// <summary>
	/// 模板信息
	/// </summary>
	public class TemplateInfo
	{
		#region 公有属性

		/// <summary>
		/// 模板所在的目录名
		/// </summary>
		public string Directory { get; set; }

		/// <summary>
		/// 模板的名字
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 版本号
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// 版权信息
		/// </summary>
		public string CopyRight { get; set; }

		/// <summary>
		/// 略缩图
		/// </summary>
		public string ScreenShot { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Url地址重写列表
		/// </summary>
		public List<RewriteRule> RewriteRules { get; set; }

		#endregion 公有属性

		#region 公有方法

		/// <summary>
		/// 从一个模板配置文件里读取配置信息, 如果配置文件不存在则返回null
		/// </summary>
		/// <param name="path">配置文件的物理绝对路径</param>
		/// <returns>模板配置信息</returns>
		public static TemplateInfo Load(string path)
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
		public static List<TemplateInfo> LoadAll()
		{
			throw new NotImplementedException("没有写这个函数");
		}

		#endregion
	}
}
