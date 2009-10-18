/// Created by zwc at 2009年10月18日
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using gtspace.Common.Contract;
using gtspace.Common;

namespace gtspace.Web.Codes
{
	/// <summary>
	/// 后台管理页面的基类, 所有需要权限控制的页面都需要继承这个类
	/// </summary>
	public class AdminPage : Page
	{
		/// <summary>
		/// PageLoad函数之前执行的函数
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreLoad(EventArgs e)
		{ 
			
			// 调用插件
			foreach (IPlugin plugin in Settings.Plugins)
			{
				plugin.AdminPage_OnPreLoad(e);
			}
		}
	}
}
