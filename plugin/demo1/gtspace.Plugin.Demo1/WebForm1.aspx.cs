﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gtspace.Plugin.Demo1
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void LinkButton1_Click(object sender, EventArgs e)
		{
			Label1.Text = (int.Parse(TextBox1.Text.Trim()) - int.Parse(TextBox2.Text.Trim())).ToString();
		}
	}
}
