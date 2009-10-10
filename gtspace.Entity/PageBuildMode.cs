using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gtspace.Entity
{
    public enum PageBuildMode
    {
        /// <summary>
        /// 静态页机制
        /// </summary>
        Html,

        /// <summary>
        /// 伪静态页机制
        /// </summary>
        FakeHtml,

        /// <summary>
        /// 动态页机制
        /// </summary>
        Aspx,
    }
}
