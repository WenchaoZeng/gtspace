using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gtspace.Entity;

namespace gtspace.Common
{
    /// <summary>
    /// 网站公共设置
    /// </summary>
    public static class Settings
    {
        #region 私有变量
        /// <summary>
        /// 是否启用调试模式，
        /// true使用调试模式,
        /// false不使用调试模式
        /// </summary>
        static bool _isDebugMade = false;

        /// <summary>
        /// 生成静态页面的超时时间, 单位:毫秒
        /// </summary>
        static int _htmlTimeOut = 30000;

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

        /// <summary>
        /// 采用何种页面生成机制
        /// </summary>
        static PageBuildMode _pageBuildMode = PageBuildMode.Html;

        #endregion

        #region 方法
        /// <summary>
        /// 是否启用调试模式, 调试模式下每个层是不依赖的
        /// </summary>
        public static bool IsDebugMade
        {
            get
            {
                return _isDebugMade;
            }
            set
            {
                _isDebugMade = value;
            }
        }
        /// <summary>
        ///  生成静态页面的超时时间, 单位:毫秒
        /// </summary>
         public static int HtmlTimeOut
         {
             get
             {
                 return _htmlTimeOut;
             }
             set
             {
                 _htmlTimeOut = value;
             }
         }

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
                 return IsDebugMade ? "value1" : "value2";
             }
             set
             {
                 _connectionString = value;
             }
         }

        /// <summary>
        /// 采用何种页面生成机制
        /// </summary>
         public static PageBuildMode PageBuildMode
         {
             get
             {
                 return _pageBuildMode;
             }
             set
             {
                 _pageBuildMode = value;
             }
         }

        #endregion
    }
}
