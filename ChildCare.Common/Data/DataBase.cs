using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChildCare.Common.Interfaces;
using ChildCare.Common.Model;
using LiteDB;

namespace ChildCare.Common.Data
{
	public class DataBase : LiteDatabase
	{
		#region const

		public const string FileName = "petoeter_lite.ldb";
		public const string TableAccount = "_account";
		public const string TableMember = "_member";

		#endregion

		#region Constructor

		public DataBase(string fileName) : base(fileName)
		{
		}

		#endregion

		#region Collections

		public LiteCollection<Account> Accounts
		{
			get { return GetCollection<Account>(DataBase.TableAccount); }
		}

		public LiteCollection<Member> Members
		{
			get { return GetCollection<Member>(DataBase.TableMember); }
		}

		#endregion
	}

	public class DatabaseConnectionFactory : IDataBaseConnection
	{
		public Connection GetConnection()
		{
			return new Connection(new DataBase(DataBase.FileName));
		}
	}
}
