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
using gtspace.Web.Codes;
using System.IO;
using gtspace.Common;

namespace gtspace.Plugin.Default.Admin.Plugins.MyPlugin.PluginsManage
{
	public partial class Upload : AdminPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void UploadButton_Click(object sender, EventArgs e)
		{
			// 创建一个唯一的文件夹名称
			Random random = new Random();
			string directory = random.Next().ToString();
			while (Directory.Exists(directory))
			{
				directory = random.Next().ToString();
			}

			// 上传文件到临时目录, 并解压到插件目录中
			Directory.CreateDirectory(Settings.RootPath + "Temp");
			PluginFileUpload.SaveAs(Settings.RootPath + "Temp\\" + directory + ".zip");

			// 继续 . .. . .. .. . . 
		}
	}
}
