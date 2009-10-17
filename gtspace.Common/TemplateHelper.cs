/// Created by zwc at 2009年10月16日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gtspace.Entity;

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
			//
			// TODO : 读取的代码留给后面搞
			//


			TemplateInfo info = new TemplateInfo();
			info.Directory = "Default";
			info.Name = "默认的模板";
			info.Version = "0.1";
			info.Author = "GTeam";
			info.CopyRight = "Copyright 2009 gtspace Development Team";
			info.ScreenShot = "screenshot.jpg";
			info.Description = "这是个gtspace默认的模板";
			info.RewriteRules = new List<RewriteRule>();

			info.RewriteRules.Add(new RewriteRule() { From = "^default.aspx[?]$", To = "~/Templates/Default/index.aspx" });

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
