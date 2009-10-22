/// Created by zwc at 2009年10月17日
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib;

namespace gtspace.Common
{
	/// <summary>
	/// 压缩包帮助器
    /// 支持zip，但不支持rar格式
	/// </summary>
	public class ZipHelper
	{
		/// <summary>
		/// 压缩一个文件夹为zip
        /// 如果该压缩文件已存在，则覆盖掉 
		/// </summary>
		/// <param name="dir">需要压缩的文件夹路径</param>
		/// <param name="zipFile">目标zip文件的路径</param>
		public void Zip(string dir, string zipFile)
		{
            if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
                dir += Path.DirectorySeparatorChar;
            if (File.Exists(zipFile))
            {
                File.SetAttributes(zipFile, FileAttributes.Normal);
            }
            ZipOutputStream s = new ZipOutputStream(File.Create(zipFile));
            s.SetLevel(6);
            try
            {
                ZipFile(dir, s, dir);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("没有找到目录" + dir.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                s.Finish();
                s.Close();
            }

		}

        /// <summary>
        /// 文件压缩
        /// </summary>
        /// <param name="strFile">正要压缩的文件夹</param>
        /// <param name="s">文件流</param>
        /// <param name="staticFile">压缩文件夹的根目录</param>
        private void ZipFile(string strFile, ZipOutputStream s, string staticFile)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
                strFile += Path.DirectorySeparatorChar;
            Crc32 crc = new Crc32();
            string[] filenames = Directory.GetFileSystemEntries(strFile);
            if (filenames.Length == 0)
            {
                //空文件夹的压缩
                string tempfile = strFile.Substring(staticFile.LastIndexOf("\\") + 1);
                ZipEntry entry = new ZipEntry(tempfile);

                entry.DateTime = DateTime.Now;
                crc.Reset();
                entry.Crc = crc.Value;
                s.PutNextEntry(entry);
            }
            foreach (string file in filenames)
            {

                if (Directory.Exists(file))
                {
                    ZipFile(file, s, staticFile);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempfile);

                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);
                }
            }
        }

		/// <summary>
		/// 解压一个zip到一个文件夹
		/// </summary>
        /// <param name="TargetFile">zip文件的路径</param>
        /// <param name="fileDir">目标文件夹的路径</param>
        public void UnZip(string TargetFile, string fileDir)
		{
            string rootFile = " ";
            if (!File.Exists(TargetFile))
            {
                throw new FileNotFoundException(TargetFile.ToString() + "不是有效的路径");
            }
            if (!Directory.Exists(Path.GetPathRoot(fileDir)))
            {
                throw new DirectoryNotFoundException(fileDir + "引用了不可用的地址");
            }
            //读取压缩文件(zip文件)，准备解压缩
            ZipInputStream s = new ZipInputStream(File.OpenRead(TargetFile.Trim()));
            try
            {
                ZipEntry theEntry;
                string path = fileDir;
                //解压出来的文件保存的路径

                string rootDir = " ";
                //根目录下的第一个子文件夹的名称
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    rootDir = Path.GetDirectoryName(theEntry.Name);
                    //得到根目录下的第一级子文件夹的名称
                    if (rootDir.IndexOf("\\") >= 0)
                    {
                        rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                    }
                    string dir = Path.GetDirectoryName(theEntry.Name);
                    //根目录下的第一级子文件夹的下的文件夹的名称
                    string fileName = Path.GetFileName(theEntry.Name);
                    //根目录下的文件名称
                    if (dir != " ")
                    //创建根目录下的子文件夹,不限制级别
                    {
                        if (!Directory.Exists(fileDir + "\\" + dir))
                        {
                            path = fileDir + "\\" + dir;
                            //在指定的路径创建文件夹
                            Directory.CreateDirectory(path);
                        }
                    }
                    else if (dir == " " && fileName != "")
                    //根目录下的文件
                    {
                        path = fileDir;
                        rootFile = fileName;
                    }
                    else if (dir != " " && fileName != "")
                    //根目录下的第一级子文件夹下的文件
                    {
                        if (dir.IndexOf("\\") > 0)
                        //指定文件保存的路径
                        {
                            path = fileDir + "\\" + dir;
                        }
                    }

                    if (dir == rootDir)
                    //判断是不是需要保存在根目录下的文件
                    {
                        path = fileDir + "\\" + rootDir;
                    }

                    //以下为解压缩zip文件的基本步骤
                    //基本思路就是遍历压缩文件里的所有文件，创建一个相同的文件。
                    if (fileName != String.Empty)
                    {
                        FileStream streamWriter = File.Create(path + "\\" + fileName);

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }

                        streamWriter.Close();
                    }
                }
                //return rootFile;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (ZipException)
            {
                throw new ZipException("不支持文件"+Path.GetFileName(TargetFile) + "的格式.(支持标准的zip、gzip等格式。)");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return "1; " + ex.Message;
            }
            finally 
            {
                s.Close();
            }
        } 
	}
}
