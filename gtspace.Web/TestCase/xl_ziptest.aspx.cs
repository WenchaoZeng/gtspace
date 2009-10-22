using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using gtspace.Common;

namespace gtspace.Web.TestCase
{
    public partial class xl_ziptest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ////压缩test
                //string dir = @"E:\13", zipFile = @"E:\ourdream.zip";
                //ZipHelper zip = new ZipHelper();
                //zip.Zip(dir, zipFile);

                //解压test
                string targetFile = @"E:\1.zip";
                string fileDir = @"w:\3\2";
                ZipHelper zip = new ZipHelper();
                zip.UnZip(targetFile, fileDir);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}
