/// Created by zwc at 2009年10月16日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Entity
{
	/// <summary>
	/// 模板信息
	/// </summary>
	public class TemplateInfo
	{
		/// <summary>
		/// 模板所在的目录名
		/// </summary>
		public string Directory = string.Empty;

		/// <summary>
		/// 模板的名字
		/// </summary>
		public string Name = string.Empty;

		/// <summary>
		/// 版本号
		/// </summary>
		public string Version = string.Empty;

		/// <summary>
		/// 作者
		/// </summary>
		public string Author = string.Empty;

		/// <summary>
		/// 版权信息
		/// </summary>
		public string CopyRight = string.Empty;

		/// <summary>
		/// 略缩图
		/// </summary>
		public string ScreenShot = string.Empty;

		/// <summary>
		/// 描述
		/// </summary>
		public string Description = string.Empty;

		/// <summary>
		/// Url地址重写列表
		/// </summary>
		public List<RewriteRule> RewriteRules = null;
	}
}
