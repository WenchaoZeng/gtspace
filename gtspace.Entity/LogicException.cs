/// Author : 曾文超
/// Create Date : 2009年7月7日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glassesol.Entity
{
    /// <summary>
    /// 逻辑错误, 由于用户的操作不当而发生的, 不影响系统正常
    /// </summary>
    public class LogicException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">错误消息</param>
        public LogicException(string message) : base(message) { }
    }
}
