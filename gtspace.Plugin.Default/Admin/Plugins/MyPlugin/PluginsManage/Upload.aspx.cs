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
using gtspace.Common.Entity;

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

			string zipPath = Settings.RootPath + "Temp\\" + directory + ".zip"; // 压缩包路径
			string PluginPath = Settings.RootPath + "Admin\\Plugins\\" + directory; // 插件存放路径

			try
			{
				// 上传文件到临时目录, 并解压到插件目录中
				Directory.CreateDirectory(Path.GetDirectoryName(zipPath));
				PluginFileUpload.SaveAs(zipPath);
				Utilitys.Zip.UnZip(zipPath, PluginPath);

				// 将DLL剪切到bin目录中
				PluginInfo info = PluginInfo.Load(PluginPath);
				File.Copy(PluginPath + "\\" + info.DLLFile, Settings.RootPath + "bin\\" + info.DLLFile);
				File.Delete(PluginPath + "\\" + info.DLLFile);

				// 插件安装完毕
				JavascriptLabel.Text = Utilitys.JS.Alert("成功安装插件 : " + info.Name);
			}
			catch (LogicException ex)
			{
				// 通知用户
				JavascriptLabel.Text = Utilitys.JS.Alert("上传插件出错, 原因 : " + ex.Message);
			}
			catch (IOException ex)
			{
				if (ex.Message.Contains("已经存在"))
				{
					JavascriptLabel.Text = Utilitys.JS.Alert("上传插件出错, 原因 : 已经存在相同的插件");
					Directory.Delete(PluginPath, true);
				}
				else
				{
					throw;
				}
			}
			finally
			{
				// 删除临时的压缩包
				File.Delete(zipPath);
			}
		}
	}
}
