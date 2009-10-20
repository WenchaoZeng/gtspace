/// Created by zwc at 2009年10月17日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace gtspace.Common
{
	/// <summary>
	/// 压缩包帮助器
	/// </summary>
	public class ZipHelper
	{
		/// <summary>
		/// 压缩一个文件夹为zip
		/// </summary>
		/// <param name="dir">需要压缩的文件夹路径</param>
		/// <param name="zipFile">目标zip文件的路径</param>
		public void Zip(string dir, string zipFile)
		{
			string shellArguments = string.Format("a -o+ \"{0}\" \"{1}\\\"", zipFile, dir);
			using (Process unrar = new Process())
			{
				unrar.StartInfo.FileName = "WinRar.exe";
				unrar.StartInfo.Arguments = shellArguments;
				unrar.Start();
				unrar.WaitForExit();
				unrar.Close();
			}
		}

		/// <summary>
		/// 解压一个zip到一个文件夹
		/// </summary>
		/// <param name="zipFile">zip文件的路径</param>
		/// <param name="dir">目标文件夹的路径</param>
		public void UnZip(string zipFile, string dir)
		{
			string shellArguments = string.Format("x -o+ \"{0}\" \"{1}\\\"", zipFile, dir);
			using (Process unrar = new Process())
			{
				unrar.StartInfo.FileName = "WinRar.exe";
				unrar.StartInfo.Arguments = shellArguments;
				unrar.Start();
				unrar.WaitForExit();
				unrar.Close();
			}
		}
	}
}
