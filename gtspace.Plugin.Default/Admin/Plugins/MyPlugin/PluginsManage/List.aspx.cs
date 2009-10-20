using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using gtspace.Web.Codes;
using gtspace.Common.Entity;
using System.Collections.Generic;
using gtspace.Common;
using System.IO;

namespace gtspace.Plugin.Default.Admin.Plugins.MyPlugin.PluginsManage
{
	public partial class List : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			// 显示插件列表
			List<PluginInfo> infos = PluginInfo.LoadAll(Settings.RootPath + "Admin\\Plugins");
			PluginsGridView.DataKeyNames = new string[] { "Directory" };
			PluginsGridView.DataSource = infos;
			PluginsGridView.DataBind();
		}

		/// <summary>
		/// 点击 [删除]
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PluginsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			// 获取插件的目录名称
			string directory = PluginsGridView.DataKeys[e.RowIndex].Value.ToString();


			try
			{
				// 获取插件信息
				PluginInfo info = PluginInfo.Load(Settings.RootPath + "Admin\\Plugins\\" + directory);

				// 删除DLL
				File.Delete(Settings.RootPath + "bin\\" + info.DLLFile);

				// 删除插件文件夹
				Directory.Delete(Settings.RootPath + "Admin\\Plugins\\" + info.Directory);

				// 删除完毕
				JavaScriptLabel.Text = Utilitys.JS.Alert("成功删除插件 : " + info.Name);
			}
			catch (LogicException ex)
			{
				// 通知用户
				JavaScriptLabel.Text = Utilitys.JS.Alert("删除插件出错, 原因 : " + ex.Message);
			}
	 	}
	}
}
