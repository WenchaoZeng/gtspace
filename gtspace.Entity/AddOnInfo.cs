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
		public string Directory { get; set; }

		/// <summary>
		/// 插件的名字
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
		/// 描述
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// DLL文件名称
		/// </summary>
		public string DLLFile { get; set; }

		/// <summary>
		/// 导航栏
		/// </summary>
		public Navigation Navigation { get; set; }
	}
}
