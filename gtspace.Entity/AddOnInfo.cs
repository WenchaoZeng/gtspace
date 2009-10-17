/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Entity
{
	/// <summary>
	/// 插件信息
	/// </summary>
	public class AddOnInfo
	{
		/// <summary>
		/// 插件所在的目录名
		/// </summary>
		public string Directory = string.Empty;

		/// <summary>
		/// 插件的名字
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
		/// 描述
		/// </summary>
		public string Description = string.Empty;

		/// <summary>
		/// DLL文件名称
		/// </summary>
		public string DLLFile = string.Empty;

		/// <summary>
		/// 动态页面名称列表
		/// </summary>
		public List<string> AspxFiles = null;
	}
}
