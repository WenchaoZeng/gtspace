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

namespace gtspace.Web.TestCase
{
	public partial class zwc_test2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<AddOnInfo> templates = AddOnInfo.LoadAll(@"E:\Now Working\Asp.net Projects\gtspace");

			Response.Write("hello");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
