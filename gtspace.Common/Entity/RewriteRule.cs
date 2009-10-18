/// Create by zwv at 2009年10月16日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common.Entity
{
	/// <summary>
	/// Url地址重写规则
	/// </summary>
	public class RewriteRule
	{
		/// <summary>
		/// 原始Url路径(相对路径)的正则表达式, 如 : (article/(\d*).aspx 代表 article/3221.aspx<br />
		/// </summary>
		public string From { get; set; }

		/// <summary>
		/// 重写的Url格式, 重写后的格式article.aspx?articleID=$1代表article.aspx?articleID=3221
		/// </summary>
		public string To { get; set; }
	}
}
