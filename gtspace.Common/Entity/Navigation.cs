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
		#region 公有属性

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

		#endregion

		#region 公有方法

		/// <summary>
		/// 从直接子导航中需找一个导航
		/// </summary>
		/// <param name="target">导航里的一个链接地址</param>
		/// <returns>一个第二级导航栏</returns>
		public Navigation Find(string target)
		{
			// 自己本身
			if (Target == target)
			{
				return this;
			}

			// 在子导航中寻找, 但值判断有没有, 返回二级导航
			if (Childs != null)
			{
				foreach (Navigation nav in Childs)
				{
					if (nav.Find(target) != null)
					{
						return nav;
					}
				}
			}

			// 没有找到
			return null;
		}

		#endregion
	}
}
