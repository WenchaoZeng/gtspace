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

namespace gtspace.Web.TestCase
{
	public partial class zwc_test2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			AddOnInfo addon = AddOnInfo.Load(@"E:\Now Working\Asp.net Projects\gtspace\gtspace.AddOn.Default\addon.config");

			Response.Write(addon.Name);
		}
	}
}
