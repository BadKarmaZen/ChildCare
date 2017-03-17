using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChildCare.Common.Events
{
	public class AddMenuEvent
	{
		public string Caption { get; set; }
		public Action Action { get; set; }
	}
}
