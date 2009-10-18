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

		void IPlugin.Application_Start(object sender, EventArgs e)
		{

		}

		void IPlugin.Session_Start(object sender, EventArgs e)
		{
			
		}

		void IPlugin.Application_BeginRequest(object sender, EventArgs e)
		{
			if (HttpContext.Current.Request.RawUrl == "/hello.html")
			{
				HttpContext.Current.Response.Write("The Plugin say : Hello.");
				HttpContext.Current.Response.End();
			}
		}

		void IPlugin.Application_AuthenticateRequest(object sender, EventArgs e)
		{
			
		}

		void IPlugin.Application_Error(object sender, EventArgs e)
		{
			
		}

		void IPlugin.Session_End(object sender, EventArgs e)
		{
			
		}

		void IPlugin.Application_End(object sender, EventArgs e)
		{
			
		}

		void IPlugin.AdminPage_OnPreLoad(EventArgs e)
		{
			
		}

		#endregion
	}
}
