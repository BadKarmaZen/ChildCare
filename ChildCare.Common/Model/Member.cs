﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCare.Common.Model
{
	public class Member : LiteObject
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }

		public string GetFullName()
		{
			return string.Format("{0} {1}", FirstName, LastName);
		}

	}
}
