/// Modified by zwc at 2009年10月16日,	去掉了一些多余的属性和成员
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using gtspace.Entity;
using System.Web.Configuration;

namespace gtspace.Common
{
    /// <summary>
    /// 网站公共设置
    /// </summary>
    public static class Settings
	{
		#region 公有属性

		/// <summary>
		/// 网站的根域名, 如 : http://www.baidu.com/
		/// </summary>
		public static string RootUrl
		{
			 get
			 {
				 return _rootPath;
			 }
			 set
			 {
				 _rootPath = value;
			 }
		}

		/// <summary>
		///  网站的根目录, 如 : C:\wwwroot\
		/// </summary>
		public static string RootPath
		{
			 get
			 {
				 return _rootPath;
			 }
			 set
			 {
				 _rootPath = value;
			 }
		}

		/// <summary>
		/// 获取数据库连接字符串
		/// </summary>
		public static string ConnectionString
		{
			 get
			 {
				 return _connectionString;
			 }
			 set
			 {
				 _connectionString = value;
			 }
		}

		/// <summary>
		/// 获取系统错误页的路径
		/// </summary>
		public static string ErrorPage
		{
			get
			{
				return _errorPage;
			}
		}

		/// <summary>
		/// 设置或获取日志路径, 后面不包括 '\' 或 '/'
		/// </summary>
		public static string LogPath
		{
			 set
			 {
				 Utilitys.Log = new LogHelper(value);
			 }
			 get
			 {
				 return (Utilitys.Log == null) ? string.Empty : Utilitys.Log.LogPath;
			 }
		}

		/// <summary>
		/// 获取或设置Url地址重写规则列表
		/// </summary>
		public static List<RewriteRule> RewriteRules
		{
			 set
			 {
				 _rewriteRules = value;
			 }
			 get
			 {
				 if (_rewriteRules == null)
				 {
					 LoadRewriteRules();
				 }
				 return _rewriteRules;
			 }
		}

		/// <summary>
		/// 获取或设置当前正在使用的模板名称, 如 : Default
		/// </summary>
		public static string CurrentTemplate
		{
			set
			{
				_currentTemplate = value;
				SetAppSetting("CurrentTemplate", value);
			}
			get
			{
				return _currentTemplate;
			}
		}

		#endregion 公有属性

		#region 方法

		/// <summary>
		/// 加载Url重写规则列表
		/// </summary>
		public static void LoadRewriteRules()
		{
			TemplateInfo info = Utilitys.Template.Load(RootPath + "Templates\\" + CurrentTemplate + "\\template.config");
			if (info.RewriteRules != null)
			{
				_rewriteRules = info.RewriteRules;
			}
		}

		/// <summary>
		/// 设置Web.config里appSettings的值
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		static void SetAppSetting(string key, string value)
		{
			string configPath = "~";
			Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);
			AppSettingsSection appSettings = config.AppSettings;
			appSettings.Settings[key].Value = value;
			config.Save();
		}

		#endregion 公有方法

		#region 构造函数

		static Settings()
		{
			// 连接字符串
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ConnectionString"]))
			{
				_connectionString = ConfigurationManager.AppSettings["ConnectionString"];
			}

			// 日志目录
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogPath"]))
			{
				LogPath = ConfigurationManager.AppSettings["LogPath"];
			}

			// 当前模板
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CurrentTemplate"]))
			{
				_currentTemplate = ConfigurationManager.AppSettings["CurrentTemplate"];
			}
		}

		#endregion

		#region 私有变量

		/// <summary>
		/// 网站的根域名, 如 : http://www.baidu.com/
		/// </summary>
		static string _rootUrl = string.Empty;

		/// <summary>
		/// 网站的根目录, 如 : C:\wwwroot\
		/// </summary>
		static string _rootPath = string.Empty;

		/// <summary>
		/// 数据库连接字符串
		/// </summary>
		static string _connectionString = string.Empty;

		/// <summary>
		/// 系统错误页面的路径, 如 : ~/app_error.html
		/// </summary>
		static string _errorPage = "~/Error/app_error.html";

		/// <summary>
		/// Url地址重写规则列表
		/// </summary>
		static List<RewriteRule> _rewriteRules = null;

		/// <summary>
		/// 当前正在使用的模板名称, 如 : Default
		/// </summary>
		static string _currentTemplate = "Default";

		#endregion 私有变量
	}
}
