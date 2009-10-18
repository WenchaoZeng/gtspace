/// Created by zwc at 2009年10月17日
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
using gtspace.Common.Entity;

namespace gtspace.Web.Codes
{
	/// <summary>
	/// 会话状态
	/// </summary>
	public static class SessionState
	{
		/// <summary>
		/// 当前导航栏
		/// </summary>
		public static Navigation CurrentNavigation
		{
			get
			{
				return HttpContext.Current.Session["CurrentNavigation"] as Navigation;
			}
			set
			{
				HttpContext.Current.Session["CurrentNavigation"] = value;
			}
		}
	}
}
