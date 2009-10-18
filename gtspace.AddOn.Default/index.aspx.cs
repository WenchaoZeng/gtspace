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
using gtspace.Common;
using gtspace.Web.Codes;

namespace gtspace.AddOn.Default
{
	public partial class index : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Label1.Text = Utilitys.JS.Alert("网站根目录的物理路径是 : " + Settings.RootPath);

		}
	}   
}
