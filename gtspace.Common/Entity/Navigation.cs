/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common.Entity
{
	/// <summary>
	/// 导航栏
	/// </summary>
	public class Navigation
	{
		/// <summary>
		/// 名称, 如 : 曾文超主页
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 目标, 如 : index.aspx
		/// </summary>
		public string Target { get; set; }

		/// <summary>
		/// 子导航栏
		/// </summary>
		public List<Navigation> Childs { get; set; }
	}
}
