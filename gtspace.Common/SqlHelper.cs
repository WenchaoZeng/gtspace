/// Created by zwc at 2009年10月18日
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace gtspace.Common
{
	/// <summary>
	/// 数据库帮助器
	/// </summary>
	public class SqlHelper : IDisposable
	{
		/// <summary>
		/// 一个打开中的数据库连接
		/// </summary>
		protected OleDbConnection _connection = null;

		#region 公有方法

		/// <summary>
		/// 构造一个数据库连接
		/// </summary>
		public SqlHelper()
		{
			_connection = new OleDbConnection(Settings.ConnectionString);
			_connection.Open();
		}

		/// <summary>
		/// 执行没有返回值的Sql语句
		/// </summary>
		/// <param name="sql">单条Sql语句</param>
		/// <returns>命令影响的行数</returns>
		public int ExecuteNonQuery(string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql, _connection);
			return cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// 执行Sql查询语句
		/// </summary>
		/// <param name="sql">单条Sql语句</param>
		/// <returns>查询结果</returns>
		public DataTable ExecuteDataTable(string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql, _connection);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			DataSet data = new DataSet();
			adapter.Fill(data);
			return data.Tables.Count > 0 ? data.Tables[0] : new DataTable();
		}

		#endregion 公有方法

		#region IDisposable 成员

		void  IDisposable.Dispose()
		{
			if (_connection != null)
			{
				_connection.Dispose();
			}
		}

		#endregion IDisposable 成员
	}
}
