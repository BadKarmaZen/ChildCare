using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCare.Common.Model
{
	public class LiteObject
	{
		public int Id { get; set; }
		public DateTime Updated { get; set; }
		public bool Deleted { get; set; }
	}
}
