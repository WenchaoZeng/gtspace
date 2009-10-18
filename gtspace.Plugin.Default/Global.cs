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

namespace gtspace.Plugin.Default
{
	public class Global : IPlugin
	{
		#region IPlugin 成员

		/// <summary>
		/// 应用程序启动时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Application_Start(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 一个新的会话开始时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Session_Start(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// 一个请求的开始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Application_BeginRequest(object sender, EventArgs e)
		{
			// 手工处理Web请求
			if (HttpContext.Current.Request.RawUrl == "/hello.html")
			{
				HttpContext.Current.Response.Write("The Plugin say : Hello.");
				HttpContext.Current.Response.End();
			}
		}

		/// <summary>
		/// 验证请求
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Application_AuthenticateRequest(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// 应用程序错误
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Application_Error(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// 一个会话的结束
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Session_End(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// 应用程序关闭时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IPlugin.Application_End(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// 后台管理页面加载前
		/// </summary>
		/// <param name="e"></param>
		void IPlugin.AdminPage_OnPreLoad(EventArgs e)
		{
			
		}

		#endregion
	}
}
