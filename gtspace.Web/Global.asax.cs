using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using gtspace.Common;
using System.Text;

namespace gtspace.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			//
			// 初始化公共的设置
			//

			// 网站的根目录
			if (string.IsNullOrEmpty(Settings.RootPath))
			{
				Settings.RootPath = HttpContext.Current.Server.MapPath("~/");
			}

			// 日志目录
			if (string.IsNullOrEmpty(Settings.LogPath))
			{
				Settings.LogPath = Settings.RootPath + "Log";
			}

			// 数据库链接字符串 access2003数据库文件的路径
			if (string.IsNullOrEmpty(Settings.ConnectionString))
			{
				Settings.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + Settings.RootPath + "Database\\gtspace.mdb\"";
			}


			// 网站的根域名, 不支持虚拟路径
			if (string.IsNullOrEmpty(Settings.RootUrl))
			{
				int server_port = int.Parse(HttpContext.Current.Request.ServerVariables["SERVER_PORT"]);
				string server_name = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
				if (server_port == 80)
				{
					Settings.RootUrl = "http://" + server_name + "/";
				}
				else
				{
					Settings.RootUrl = "http://" + server_name + ":" + server_port + "/";
				}
			}
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
			Utilitys.UrlRewriter.RewriteUrl();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
			// 全局异常处理
			Exception httpUnhandler = Server.GetLastError();

			// 不处理404错误, 因为在这里只能捕获aspx的404错误, 却不能捕获html的
			// 交给Web.config里指定的页面去处理404错误, 实现静态生成
			if ((httpUnhandler as HttpException) != null && (httpUnhandler as HttpException).GetHttpCode() == 404)
			{
				Utilitys.Log.WriteLog(Request.Url.AbsoluteUri + " 发生404错误!");
				return;
			}

			if (httpUnhandler != null)
			{
				Exception ex = httpUnhandler.InnerException;
				if (ex != null)
				{
					// 写日志
					StringBuilder erroMessage = new StringBuilder();

					erroMessage.AppendFormat("当前访问页面Url : {0}\r\n", Request.Url.AbsoluteUri);
					erroMessage.AppendFormat("错误描述 : \r\n{0}\r\n", ex.ToString());

					Utilitys.Log.WriteLog(erroMessage.ToString());

					// 显示错误页面
					Response.Redirect(Settings.ErrorPage);
				}
			}
			Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}