using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCare.Common.Screens
{
	public class TaggedItemUI<T> : BaseItemUI
			where T : class
	{
		public T Tag { get; set; }
	}
}