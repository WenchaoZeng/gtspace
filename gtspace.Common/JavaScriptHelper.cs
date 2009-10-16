/// Author : 曾文超
/// Create Date : 2009年7月14
/// Modified by zwc at 2009年10月16日, 精简了方法名称
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common
{
    /// <summary>
    /// 前台JavaScript帮助器, 提供JavaScript格式化输出
    /// </summary>
    public class JavaScriptHelper
    {
        /// <summary>
        /// 描述 : 创建一个JavaScript表示的提示框代码, 将这些代码放到Html流里去就可以实现在客户端里弹出一个提示框的了
		///          比如 : Label1.Text = Alert("Hello");
        /// 创建人 : 曾文超
        /// 时间 : 2009年4月30日
        /// </summary>
        /// <param name="message">提示消息</param>
        /// <returns>JavaScript代码</returns>
        public string Alert(string message)
        {
			return Code("alert(\"" + message + "\");");
        }

        /// <summary>
        /// 构件一个客户端的重定向脚本
        /// </summary>
        /// <param name="url">绝对或相对地址</param>
        /// <returns></returns>
        public string Redirect(string url)
        {
			return Code("window.location=\"" + url + "\"");
        }

        /// <summary>
        /// 构件一段JavaScritp代码, 用<scritp></scritp>打包
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public string Code(string code)
        {
            return "<script language=\"javascript\">" + code +"</script>";
        }
    }
}
