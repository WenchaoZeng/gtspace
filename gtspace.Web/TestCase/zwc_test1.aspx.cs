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
using System.IO;

namespace gtspace.Web.TestCase
{
	public partial class zwc_test1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			// 加载插件
			
			try
			{
				Directory.CreateDirectory(Settings.RootPath + @"bin\addon");
				File.Copy(@"D:\Temp\AddOn\WebApplication1.dll", Settings.RootPath + @"bin\addon\WebApplication1.dll");
				File.Copy(@"D:\Temp\AddOn\WebApplication1.pdb", Settings.RootPath + @"bin\addon\WebApplication1.pdb");
				File.Copy(@"D:\Temp\AddOn\WebApplication2.dll", Settings.RootPath + @"bin\addon\WebApplication2.dll");
				File.Copy(@"D:\Temp\AddOn\WebApplication2.pdb", Settings.RootPath + @"bin\addon\WebApplication2.pdb");

				File.Copy(@"D:\Temp\AddOn\Default.aspx", Settings.RootPath + @"TestCase\Default.aspx");
			}
			catch (Exception ex)
			{
				Label1.Text = "加载失败 : " + ex.Message;
				return;
			}
			Label1.Text = "加载成功";
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			// 卸载插件

			try
			{
				Directory.Delete(Settings.RootPath + @"bin\addon", true);
				File.Delete(Settings.RootPath + @"TestCase\Default.aspx");
			}
			catch (Exception ex)
			{
				Label1.Text = "卸载失败 : " + ex.Message;
				return;
			}
			Label1.Text = "卸载成功";
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			// 设置Session
			Session["Demo"] = "this data is from session.";
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			Label2.Text = Session["Demo"] as string;
		}
	}
}
