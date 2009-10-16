using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using gtspace.Entity;
using System.Text.RegularExpressions;

namespace gtspace.Common
{
    /// <summary>
    /// Url地址重写器
    /// </summary>
    public class UrlRewriter
    {
		/// <summary>
		/// 执行Url重写
		/// </summary>
		public void RewriteUrl()
		{
			// 尝试全部生成规则
			string url = HttpContext.Current.Request.RawUrl;
			url = url.Substring(1); // 去掉路径前面的 / 号
			foreach (RewriteRule rule in Settings.RewriteRules)
			{
				Regex reg = new Regex(rule.From);
				// 验证文件名的格式
				if (reg.IsMatch(url))
				{
					// 通过静态html路径计算aspx文件的路径
					string aspxPath = reg.Replace(url, rule.To);
					HttpContext.Current.RewritePath(aspxPath);
				}
			}
		}
    }
}
