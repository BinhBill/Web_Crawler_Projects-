using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CRAWLER.DATA
{
	#region conference
	/// <summary>
	/// This object represents the properties and methods of a conference.
	/// </summary>
	public class conference
	{
		private int _id;
		private string _name = String.Empty;
		private string _country = String.Empty;
		private string _city = String.Empty;
		private DateTime _start_date;
		private DateTime _end_date;
		private string _submit_format = String.Empty;
		private string _description = String.Empty;
		private string _url = String.Empty;
		private long _created_at;

		public conference()
		{
		}

		public conference(int id)
		{
			// NOTE: If this reference doesn't exist then add SqlService.cs from the template directory to your solution.
			SqlService sql = new SqlService();
			sql.AddParameter("@conference_id", SqlDbType.Int, id);
			SqlDataReader reader = sql.ExecuteSqlReader("SELECT * FROM conference WHERE conference_id = @conference_id");

			if (reader.Read())
			{
				this.LoadFromReader(reader);
				reader.Close();
			}
			else
			{
				if (!reader.IsClosed) reader.Close();
				throw new ApplicationException("conference does not exist.");
			}
		}

		public conference(SqlDataReader reader)
		{
			this.LoadFromReader(reader);
		}

		protected void LoadFromReader(SqlDataReader reader)
		{
			if (reader != null && !reader.IsClosed)
			{
				_id = reader.GetInt32(0);
				if (!reader.IsDBNull(1)) _name = reader.GetString(1);
				if (!reader.IsDBNull(2)) _country = reader.GetString(2);
				if (!reader.IsDBNull(3)) _city = reader.GetString(3);
				if (!reader.IsDBNull(4)) _start_date = reader.GetDateTime(4);
				if (!reader.IsDBNull(5)) _end_date = reader.GetDateTime(5);
				if (!reader.IsDBNull(6)) _submit_format = reader.GetString(6);
				if (!reader.IsDBNull(7)) _description = reader.GetString(7);
				if (!reader.IsDBNull(8)) _url = reader.GetString(8);
				if (!reader.IsDBNull(9)) _created_at = reader.GetInt64(9);
			}
		}

		public void Delete()
		{
			conference.Delete(_id);
		}

		public void Update()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@conference_id", SqlDbType.Int, Id);
			queryParameters.Append("conference_id = @conference_id");

			sql.AddParameter("@name", SqlDbType.VarChar, name);
			queryParameters.Append(", name = @name");
			sql.AddParameter("@country", SqlDbType.VarChar, country);
			queryParameters.Append(", country = @country");
			sql.AddParameter("@city", SqlDbType.VarChar, city);
			queryParameters.Append(", city = @city");
			sql.AddParameter("@start_date", SqlDbType.DateTime, start_date);
			queryParameters.Append(", start_date = @start_date");
			sql.AddParameter("@end_date", SqlDbType.DateTime, end_date);
			queryParameters.Append(", end_date = @end_date");
			sql.AddParameter("@submit_format", SqlDbType.VarChar, submit_format);
			queryParameters.Append(", submit_format = @submit_format");
			sql.AddParameter("@description", SqlDbType.VarChar, description);
			queryParameters.Append(", description = @description");
			sql.AddParameter("@url", SqlDbType.VarChar, url);
			queryParameters.Append(", url = @url");
			sql.AddParameter("@created_at", SqlDbType.BigInt, created_at);
			queryParameters.Append(", created_at = @created_at");

			string query = String.Format("Update conference Set {0} Where conference_id = @conference_id", queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public void Create()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@conference_id", SqlDbType.Int, Id);
			queryParameters.Append("@conference_id");

			sql.AddParameter("@name", SqlDbType.VarChar, name);
			queryParameters.Append(", @name");
			sql.AddParameter("@country", SqlDbType.VarChar, country);
			queryParameters.Append(", @country");
			sql.AddParameter("@city", SqlDbType.VarChar, city);
			queryParameters.Append(", @city");
			sql.AddParameter("@start_date", SqlDbType.DateTime, start_date);
			queryParameters.Append(", @start_date");
			sql.AddParameter("@end_date", SqlDbType.DateTime, end_date);
			queryParameters.Append(", @end_date");
			sql.AddParameter("@submit_format", SqlDbType.VarChar, submit_format);
			queryParameters.Append(", @submit_format");
			sql.AddParameter("@description", SqlDbType.VarChar, description);
			queryParameters.Append(", @description");
			sql.AddParameter("@url", SqlDbType.VarChar, url);
			queryParameters.Append(", @url");
			sql.AddParameter("@created_at", SqlDbType.BigInt, created_at);
			queryParameters.Append(", @created_at");

			string query = String.Format("Insert Into conference ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}

		public static conference Newconference(int id)
		{
			conference newEntity = new conference();
			newEntity._id = id;

			return newEntity;
		}

		#region Public Properties
		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string country
		{
			get { return _country; }
			set { _country = value; }
		}

		public string city
		{
			get { return _city; }
			set { _city = value; }
		}

		public DateTime start_date
		{
			get { return _start_date; }
			set { _start_date = value; }
		}

		public DateTime end_date
		{
			get { return _end_date; }
			set { _end_date = value; }
		}

		public string submit_format
		{
			get { return _submit_format; }
			set { _submit_format = value; }
		}

		public string description
		{
			get { return _description; }
			set { _description = value; }
		}

		public string url
		{
			get { return _url; }
			set { _url = value; }
		}

		public long created_at
		{
			get { return _created_at; }
			set { _created_at = value; }
		}
		#endregion

		public static conference Getconference(int id)
		{
			return new conference(id);
		}

		public static void Delete(int id)
		{
			SqlService sql = new SqlService();
			sql.AddParameter("@conference_id", SqlDbType.Int, id);

			SqlDataReader reader = sql.ExecuteSqlReader("Delete conference Where conference_id = @conference_id");
		}

		#region
		public void AddConference()
		{
			SqlService sql = new SqlService();
			StringBuilder queryParameters = new StringBuilder();

			sql.AddParameter("@name", SqlDbType.VarChar, name);
			queryParameters.Append("@name");
			sql.AddParameter("@country", SqlDbType.VarChar, country);
			queryParameters.Append(", @country");
			sql.AddParameter("@city", SqlDbType.VarChar, city);
			queryParameters.Append(", @city");
			sql.AddParameter("@start_date", SqlDbType.DateTime, start_date);
			queryParameters.Append(", @start_date");
			sql.AddParameter("@end_date", SqlDbType.DateTime, end_date);
			queryParameters.Append(", @end_date");
			sql.AddParameter("@submit_format", SqlDbType.VarChar, submit_format);
			queryParameters.Append(", @submit_format");
			sql.AddParameter("@description", SqlDbType.VarChar, description);
			queryParameters.Append(", @description");
			sql.AddParameter("@url", SqlDbType.VarChar, url);
			queryParameters.Append(", @url");
			sql.AddParameter("@created_at", SqlDbType.BigInt, created_at);
			queryParameters.Append(", @created_at");

			string query = String.Format("Insert Into conference ({0}) Values ({1})", queryParameters.ToString().Replace("@", ""), queryParameters.ToString());
			SqlDataReader reader = sql.ExecuteSqlReader(query);
		}
		#endregion
	}
    #endregion
}

