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

namespace gtspace.AddOn.Default
{
	public class AddOn : IAddOn
	{

		#region IAddOn 成员

		void IAddOn.Application_Start(object sender, EventArgs e)
		{

		}

		void IAddOn.Session_Start(object sender, EventArgs e)
		{
			
		}

		void IAddOn.Application_BeginRequest(object sender, EventArgs e)
		{

		}

		void IAddOn.Application_AuthenticateRequest(object sender, EventArgs e)
		{
			
		}

		void IAddOn.Application_Error(object sender, EventArgs e)
		{
			
		}

		void IAddOn.Session_End(object sender, EventArgs e)
		{
			
		}

		void IAddOn.Application_End(object sender, EventArgs e)
		{
			
		}

		void IAddOn.AdminPage_OnPreLoad(EventArgs e)
		{
			
		}

		#endregion
	}
}
