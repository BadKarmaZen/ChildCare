using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildCare.Common.Data;
using LiteDB;

namespace ChildCare.Common.Model
{
	public class Account : LiteObject
	{
		public string Name { get; set; }

		[BsonRef(DataBase.TableMember)]
		public List<Member> Members { get; set; }

		public Account()
		{
			Members = new List<Member>();
		}
	}
}
