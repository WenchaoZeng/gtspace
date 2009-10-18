/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common.Entity
{
	/// <summary>
	/// 插件信息
	/// </summary>
	public class AddOnInfo
	{
		#region 公有属性

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

		#endregion 公有属性

		#region 公有方法

		/// <summary>
		/// 从一个模板配置文件里读取配置信息, 如果配置文件不存在则返回null
		/// </summary>
		/// <param name="path">配置文件的物理绝对路径</param>
		/// <returns>插件配置信息</returns>
		public static AddOnInfo Load(string path)
		{
			//
			// TODO : 读取的代码留给后面搞
			//

			AddOnInfo info = new AddOnInfo();
			info.Directory = "Default";
			info.Name = "默认的插件";
			info.Version = "0.1";
			info.Author = "GTeam";
			info.CopyRight = "Copyright 2009 gtspace Development Team";
			info.Description = "这是gtspace默认的插件";
			info.DLLFile = "gtspace.AddOn.Default.dll";
			// 需要添加导航栏信息

			throw new NotImplementedException("需要添加导航栏信息");

			return info;
		}

		/// <summary>
		/// 读取所有插件信息
		/// </summary>
		/// <returns>插件列表</returns>
		public static List<AddOnInfo> LoadAll()
		{
			throw new NotImplementedException("没有写这个函数");
		}

		#endregion 公有方法
	}
}
