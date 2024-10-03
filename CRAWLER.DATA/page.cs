using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CRAWLER.DATA
{
	#region page
	/// <summary>
	/// This object represents the properties and methods of a page.
	/// </summary>
	public class page
	{
		private int _id;
		private string _url = String.Empty;
		private string _title = String.Empty;
		private string _content = String.Empty;
		private int _crawled_at_hour;
		private int _crawled_at_minute;
		private int _crawled_at_second;
		private bool _available;

		public page()
		{
		}

		public page(int id)
		{
			// NOTE: If this reference doesn't exist then add SqlService.cs from the template directory to your solution.
			SqlService sql = new SqlService();
			sql.AddParameter("@page_id", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM pages WHERE page_id = @page_id");

			if (reader.Read())
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("page does not exist.");
			}
		}

		public page(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}

		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _url = reader.GetString(1);
				if (!reader.IsDBNull(2)) _title = reader.GetString(2);
				if (!reader.IsDBNull(3)) _content = reader.GetString(3);
				if (!reader.IsDBNull(4)) _crawled_at_hour = reader.GetInt32(4);
				if (!reader.IsDBNull(5)) _crawled_at_minute = reader.GetInt32(5);
				if (!reader.IsDBNull(6)) _crawled_at_second = reader.GetInt32(6);
				if (!reader.IsDBNull(7)) _available = reader.GetBoolean(7);
			}
		}

		public void Delete()
		{
			page.Delete(_id);
		}

		public void Update()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@page_id", SqlDbType.Int, Id);
			queryParameters.Append("page_id = @page_id");

			sql.AddParameter("@url", SqlDbType.VarChar, url);
			queryParameters.Append(", url = @url");
			sql.AddParameter("@title", SqlDbType.VarChar, title);
			queryParameters.Append(", title = @title");
			sql.AddParameter("@content", SqlDbType.Text, content);
			queryParameters.Append(", content = @content");
			sql.AddParameter("@crawled_at_hour", SqlDbType.Int, crawled_at_hour);
			queryParameters.Append(", crawled_at_hour = @crawled_at_hour");
			sql.AddParameter("@crawled_at_minute", SqlDbType.Int, crawled_at_minute);
			queryParameters.Append(", crawled_at_minute = @crawled_at_minute");
			sql.AddParameter("@crawled_at_second", SqlDbType.Int, crawled_at_second);
			queryParameters.Append(", crawled_at_second = @crawled_at_second");
			sql.AddParameter("@available", SqlDbType.Bit, available);
			queryParameters.Append(", available = @available");

			string query = String.Format("Update pages Set {0} Where page_id = @page_id", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public void Create()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@page_id", SqlDbType.Int, Id);
			queryParameters.Append("@page_id");

			sql.AddParameter("@url", SqlDbType.VarChar, url);
			queryParameters.Append(", @url");
			sql.AddParameter("@title", SqlDbType.VarChar, title);
			queryParameters.Append(", @title");
			sql.AddParameter("@content", SqlDbType.Text, content);
			queryParameters.Append(", @content");
			sql.AddParameter("@crawled_at_hour", SqlDbType.Int, crawled_at_hour);
			queryParameters.Append(", @crawled_at_hour");
			sql.AddParameter("@crawled_at_minute", SqlDbType.Int, crawled_at_minute);
			queryParameters.Append(", @crawled_at_minute");
			sql.AddParameter("@crawled_at_second", SqlDbType.Int, crawled_at_second);
			queryParameters.Append(", @crawled_at_second");
			sql.AddParameter("@available", SqlDbType.Bit, available);
			queryParameters.Append(", @available");

			string query = String.Format("Insert Into pages ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public static page Newpage(int id)
		{
			page newEntity = new page();
			newEntity._id = id;

			return newEntity;
		}

		#region Public Properties
		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string url
		{
			get { return _url; }
			set { _url = value; }
		}

		public string title
		{
			get { return _title; }
			set { _title = value; }
		}

		public string content
		{
			get { return _content; }
			set { _content = value; }
		}

		public int crawled_at_hour
		{
			get { return _crawled_at_hour; }
			set { _crawled_at_hour = value; }
		}

		public int crawled_at_minute
		{
			get { return _crawled_at_minute; }
			set { _crawled_at_minute = value; }
		}

		public int crawled_at_second
		{
			get { return _crawled_at_second; }
			set { _crawled_at_second = value; }
		}

		public bool available
		{
			get { return _available; }
			set { _available = value; }
		}
		#endregion

		public static page Getpage(int id)
		{
			return new page(id);
		}

		public static void Delete(int id)
		{
			SqlService sql = new SqlService();
			sql.AddParameter("@page_id", SqlDbType.Int, id);

			SqlDataReader reader = sql.ExecuteSqlReader("Delete pages Where page_id = @page_id");
		}

		#region
		public static DataTable GetUrl(string available)
		{
			SqlService cs = new SqlService();
			string query = "select top 1 * from pages where available ='" + available + "'";
			SqlDataAdapter adap = new SqlDataAdapter(query, cs.ConnectionString);
			DataTable dt = new DataTable();
			adap.Fill(dt);
			return dt;
		}

		public void UpdateTimestamp(int pageID)
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@crawled_at_minute", SqlDbType.Int, crawled_at_minute);
			queryParameters.Append("crawled_at_minute = @crawled_at_minute");
			sql.AddParameter("@crawled_at_second", SqlDbType.Int, crawled_at_second);
			queryParameters.Append(", crawled_at_second = @crawled_at_second");

			string query = String.Format("Update pages Set {0} Where page_id = " + pageID, queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		#endregion
	}
	#endregion
}

