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
using System.Web.Configuration;
using gtspace.Common.Entity;
using System.Collections.Generic;
using gtspace.Common;
using System.Reflection;
using gtspace.Common.Contract;

namespace gtspace.Web.TestCase
{
	public partial class zwc_test2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			foreach (IPlugin plugins in Settings.Plugins)
			{
				plugins.Application_BeginRequest(sender, e);
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
