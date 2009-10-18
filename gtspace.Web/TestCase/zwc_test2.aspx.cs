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
using System.Collections.Generic;
using System.Reflection;
using System.Data.OleDb;
using gtspace.Common.Entity;
using gtspace.Common.Contract;
using gtspace.Common;

namespace gtspace.Web.TestCase
{
	public partial class zwc_test2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//OleDbConnection conn = new OleDbConnection(Settings.ConnectionString);
			//OleDbCommand cmd = new OleDbCommand("select * from demo", conn);
			//conn.Open();
			//OleDbDataReader reader = cmd.ExecuteReader();
			//while (reader.Read())
			//{
			//    Response.Write("Name : " + reader["Name"] + "<br />");
			//}
			//conn.Close();

			// 查询数据库
			using (SqlHelper helper = new SqlHelper())
			{
				DataTable table = helper.ExecuteDataTable("select * from demo");
				foreach (DataRow row in table.Rows)
				{
					Response.Write("Name : " + row["Name"] + "<br />");
				}
				helper.ExecuteNonQuery("create table tmp");
			}

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
