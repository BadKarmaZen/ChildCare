using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildCare.Common.Interfaces;
using ChildCare.Common.Model;
using LiteDB;

namespace ChildCare.Common.Data
{
	public class Connection : IDataBase, IDisposable
	{
		#region Member

		private DataBase _database;

		#endregion

		#region Constructor

		public Connection(DataBase database)
		{
			_database = database;
		}

		public void Dispose()
		{
			_database?.Dispose();
		}

		#endregion

		public LiteCollection<Account> Accounts
		{
			get { return _database?.Accounts; }
		}

		public LiteCollection<Member> Members
		{
			get { return _database.Members; }
		}
	}
}
