/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

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
		/// 从一个插件配置文件里读取配置信息, 如果不能成功读取则抛出异常
		/// </summary>
		/// <param name="path">插件文件夹的物理绝对路径 (后面不加 / 或 \ )</param>
		/// <returns>插件配置信息</returns>
		/// <exception cref="LogicException"/>
		public static AddOnInfo Load(string path)
		{
			// 构造配置文件路径
			path += "\\" + _configfile;
			if (!File.Exists(path))
			{
				throw new LogicException("插件配置文件不存在");
			}

			AddOnInfo info = new AddOnInfo();

			// 目录名称
			info.Directory = Path.GetFileName(Path.GetDirectoryName(path));

			XmlElement root = Utilitys.Xml.Load(path);
			if (root == null || root.Name != "addon")
			{
				throw new LogicException("不是一个有效的插件配置文件");
			}

			// 读取基本信息
			info.Name = Utilitys.Xml.ReadChild(root, "name");
			info.Version = Utilitys.Xml.ReadChild(root, "version");
			info.Author = Utilitys.Xml.ReadChild(root, "author");
			info.CopyRight = Utilitys.Xml.ReadChild(root, "copyright");
			info.Description = Utilitys.Xml.ReadChild(root, "description");
			info.DLLFile = Utilitys.Xml.ReadChild(root, "dllfile");

			// 读取导航栏
			info.Navigation = new Navigation();
			info.Navigation.Childs = new List<Navigation>();
			XmlNodeList navigation = root.GetElementsByTagName("navigation");
			if (navigation.Count <= 0)
			{
				throw new LogicException("插件必须要有导航栏");
			}
			info.Navigation.Name = Utilitys.Xml.ReadAttribute(navigation[0], "name");
			info.Navigation.Target = Settings.RootUrl + "Admin/AddOns/" + info.Directory + "/" + Utilitys.Xml.ReadAttribute(navigation[0], "target");

			// 组
			XmlNodeList groups = navigation[0].SelectNodes("group");
			foreach (XmlNode group in groups)
			{
				Navigation groupNav = new Navigation();
				groupNav.Childs = new List<Navigation>();
				groupNav.Name = Utilitys.Xml.ReadAttribute(group, "name");

				// 页面链接
				XmlNodeList pages = group.SelectNodes("page");
				foreach (XmlNode page in pages)
				{
					Navigation pageNav = new Navigation();
					pageNav.Name = Utilitys.Xml.ReadAttribute(page, "name");
					pageNav.Target = Settings.RootUrl + "Admin/AddOns/" + info.Directory + "/" + Utilitys.Xml.ReadAttribute(page, "target");

					groupNav.Childs.Add(pageNav);
				}

				info.Navigation.Childs.Add(groupNav);
			}

			return info;
		}

		/// <summary>
		/// 读取所有插件信息
		/// </summary>
		/// <param name="path">放置许多插件的文件夹路径</param>
		/// <returns>插件列表</returns>
		public static List<AddOnInfo> LoadAll(string path)
		{
			List<AddOnInfo> addons = new List<AddOnInfo>();

			// 列出子文件夹
			string[] subPaths = System.IO.Directory.GetDirectories(path);

			// 读取配置信息
			foreach (string subPath in subPaths)
			{
				try
				{
					addons.Add(Load(subPath));
				}
				catch (LogicException ex)
				{
					// 做日志, 并忽视一切错误
					Utilitys.Log.WriteLog("读取" + subPath + "时发生错误, 错误信息为 : " + ex.Message);
				}
			}

			return addons;
		}

		#endregion 公有方法

		#region 私有字段

		/// <summary>
		/// 配置文件的文件名
		/// </summary>
		static string _configfile = "addon.config";

		#endregion
	}
}
