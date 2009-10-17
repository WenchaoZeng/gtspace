///  Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gtspace.Entity;

namespace gtspace.Common
{
	/// <summary>
	/// 插件帮助器
	/// </summary>
	public class AddOnHelper
	{
		/// <summary>
		/// 从一个模板配置文件里读取配置信息, 如果配置文件不存在则返回null
		/// </summary>
		/// <param name="path">配置文件的物理绝对路径</param>
		/// <returns>插件配置信息</returns>
		public AddOnInfo Load(string path)
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
		public List<AddOnInfo> LoadAll()
		{
			throw new NotImplementedException("没有写这个函数");
		}

	}
}
