using ChildCare.Common.Data;
using ChildCare.Common.Model;
using LiteDB;

namespace ChildCare.Common.Interfaces
{
	public interface IDataBase
	{
		LiteCollection<Account> Accounts { get; }
		LiteCollection<Member> Members { get; }
	}

	public interface IDataBaseConnection
	{
		Connection GetConnection();
	}
}