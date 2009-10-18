/// Created by zwc at 2009年10月18日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common.Contract
{
	/// <summary>
	/// 插件通用的接口
	/// </summary>
	public interface IAddOn
	{
		#region Global 全局类的函数

		/// <summary>
		/// 应用程序启动时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Application_Start(object sender, EventArgs e);

		/// <summary>
		/// 一个新的会话开始时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Session_Start(object sender, EventArgs e);

		/// <summary>
		/// 一个请求的开始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Application_BeginRequest(object sender, EventArgs e);

		/// <summary>
		/// 验证请求
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Application_AuthenticateRequest(object sender, EventArgs e);

		/// <summary>
		/// 应用程序错误
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Application_Error(object sender, EventArgs e);

		/// <summary>
		/// 一个会话的结束
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Session_End(object sender, EventArgs e);

		/// <summary>
		/// 应用程序关闭时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Application_End(object sender, EventArgs e);

		#endregion

		/// <summary>
		/// 后台管理页面加载前
		/// </summary>
		/// <param name="e"></param>
		void AdminPage_OnPreLoad(EventArgs e);
	}
}
