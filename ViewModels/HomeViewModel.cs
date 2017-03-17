using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ChildCare.Common.Events;
using ChildCare.Common.Interfaces;
using ChildCare.Core;
using Action = System.Action;

namespace ChildCare.ViewModels
{
	public class HomeViewModel : Screen
	{
		#region Member

		private DashBoard _dashBoard;

		#endregion

		#region Properties

		public List<DashBoardItem> Items
		{
			get
			{
				var items = from i in _dashBoard.Items
										orderby i.Index
										select i;

				return items.ToList();
			}
		}

		#endregion

		#region Constructor

		public HomeViewModel(DashBoard dashBoard)
		{
			_dashBoard = dashBoard;
		}

		#endregion

		#region Action

		public void LoadModule(DashBoardItem item)
		{
			if(item != null)
				item.ExecuteAction();
		}

		#endregion
	}
}
