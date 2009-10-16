using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common
{
    /// <summary>
    /// 工具访问类
    /// </summary>
    public class Utilitys
    {
		/// <summary>
		/// 日志帮助器
		/// </summary>
		public static LogHelper Log = null;

		/// <summary>
		/// JavaScript帮助器
		/// </summary>
		public static JavaScriptHelper JS = new JavaScriptHelper();

		/// <summary>
		/// 数据检验器
		/// </summary>
		public static ValidateHelper Validater = new ValidateHelper();

		/// <summary>
		/// 网页Url地址重写器
		/// </summary>
		public static UrlRewriter UrlRewriter = new UrlRewriter();
    }
}
