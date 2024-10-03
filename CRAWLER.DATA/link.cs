using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CRAWLER.DATA
{
	#region link
	/// <summary>
	/// This object represents the properties and methods of a link.
	/// </summary>
	public class link
	{
		private int _id;
		private int _source_page_id;
		private string _destination_url = String.Empty;
		private string _link_type = String.Empty;
		private bool _available;

		public link()
		{
		}

		public link(int id)
		{
			// NOTE: If this reference doesn't exist then add SqlService.cs from the template directory to your solution.
			SqlService sql = new SqlService();
			sql.AddParameter("@link_id", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM links WHERE link_id = @link_id");

			if (reader.Read())
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("link does not exist.");
			}
		}

		public link(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}

		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _source_page_id = reader.GetInt32(1);
				if (!reader.IsDBNull(2)) _destination_url = reader.GetString(2);
				if (!reader.IsDBNull(3)) _link_type = reader.GetString(3);
				if (!reader.IsDBNull(4)) _available = reader.GetBoolean(4);
			}
		}

		public void Delete()
		{
			link.Delete(_id);
		}

		public void Update()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@link_id", SqlDbType.Int, Id);
			queryParameters.Append("link_id = @link_id");

			sql.AddParameter("@source_page_id", SqlDbType.Int, source_page_id);
			queryParameters.Append(", source_page_id = @source_page_id");
			sql.AddParameter("@destination_url", SqlDbType.VarChar, destination_url);
			queryParameters.Append(", destination_url = @destination_url");
			sql.AddParameter("@link_type", SqlDbType.VarChar, link_type);
			queryParameters.Append(", link_type = @link_type");
			sql.AddParameter("@available", SqlDbType.Bit, available);
			queryParameters.Append(", available = @available");

			string query = String.Format("Update links Set {0} Where link_id = @link_id", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public void Create()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@link_id", SqlDbType.Int, Id);
			queryParameters.Append("@link_id");

			sql.AddParameter("@source_page_id", SqlDbType.Int, source_page_id);
			queryParameters.Append(", @source_page_id");
			sql.AddParameter("@destination_url", SqlDbType.VarChar, destination_url);
			queryParameters.Append(", @destination_url");
			sql.AddParameter("@link_type", SqlDbType.VarChar, link_type);
			queryParameters.Append(", @link_type");
			sql.AddParameter("@available", SqlDbType.Bit, available);
			queryParameters.Append(", @available");

			string query = String.Format("Insert Into links ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public static link Newlink(int id)
		{
			link newEntity = new link();
			newEntity._id = id;

			return newEntity;
		}

		#region Public Properties
		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public int source_page_id
		{
			get { return _source_page_id; }
			set { _source_page_id = value; }
		}

		public string destination_url
		{
			get { return _destination_url; }
			set { _destination_url = value; }
		}

		public string link_type
		{
			get { return _link_type; }
			set { _link_type = value; }
		}

		public bool available
		{
			get { return _available; }
			set { _available = value; }
		}
		#endregion

		public static link Getlink(int id)
		{
			return new link(id);
		}

		public static void Delete(int id)
		{
			SqlService sql = new SqlService();
			sql.AddParameter("@link_id", SqlDbType.Int, id);

			SqlDataReader reader = sql.ExecuteSqlReader("Delete links Where link_id = @link_id");
		}

		
	}
#endregion
}

