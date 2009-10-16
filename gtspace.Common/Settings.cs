/// Modified by zwc at 2009年10月16日,	去掉了一些多余的属性和成员
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Common
{
    /// <summary>
    /// 网站公共设置
    /// </summary>
    public static class Settings
    {
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
        /// 获取数据库连接字符串
        /// </summary>
        static string _connectionString = string.Empty;

        /// <summary>
        /// 系统错误页面的路径, 如 : ~/Error.html
        /// </summary>
        static string _errorPage = "~/Error.html";

        #endregion


        #region 属性
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
                 //根据是否为调试模式调用连接字符串；
                 return string.Empty;
             }
             set
             {
                 _connectionString = value;
             }
         }

        #endregion
    }
}
