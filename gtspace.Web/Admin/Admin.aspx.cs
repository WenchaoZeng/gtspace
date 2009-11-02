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
using gtspace.Common;
using gtspace.Common.Entity;

namespace gtspace.Web.Admin
{
	public partial class Admin : AdminPage
	{
		/// <summary>
		/// 当前加载的页面
		/// </summary>
		protected string _load;

		/// <summary>
		/// 主导航栏
		/// </summary>
		protected string _main_nav;

		/// <summary>
		/// 二级导航
		/// </summary>
		protected string _sub_nav;


		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
           
			// 加载页面
			_load = Server.UrlDecode(Request.QueryString["target"]);
			if (string.IsNullOrEmpty(_load))
			{
				_load = Settings.RootNavigation.Target;
			}

			// 二级导航
			Navigation subNav = Settings.RootNavigation.Find(_load);
			if (subNav != null && subNav.Childs != null && subNav.GetHashCode() != Settings.RootNavigation.GetHashCode())
			{
				foreach (Navigation nav in subNav.Childs)
				{
					_sub_nav += "<fieldset>";
					_sub_nav += "<legend>" + nav.Name + "</legend>";
					_sub_nav += "<ul>";
					if (nav.Childs != null)
					{
						foreach (Navigation linkNav in nav.Childs)
						{
							_sub_nav += "<li><a" + (linkNav.Target == _load ? " class=\"current\"" : "") + " href=\"?target=" + Server.UrlEncode(linkNav.Target) + "\">" + linkNav.Name + "</a></li>";
						}
					}
					_sub_nav += "</ul>";
					_sub_nav += "</fieldset>";

				}
			}

			// 主导航栏
			foreach (Navigation nav in Settings.RootNavigation.Childs)
			{
				_main_nav += "<li><a" + (nav.Target == subNav.Target ? " class=\"current\"" : "") + " href=\"?target=" + Server.UrlEncode(nav.Target) + "\">" + nav.Name + "</a></li>";
			}
		}
	}
}
