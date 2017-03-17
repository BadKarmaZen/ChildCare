using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCare.Common.Screens
{
	public class FilteredListItemScreen<T> : ListItemScreen<T>
			where T : BaseItemUI
	{
		#region Member
		
		private string _filter;

		#endregion

		#region Properties

		public string Filter
		{
			get { return _filter; }
			set
			{
				_filter = value;
				NotifyOfPropertyChange(() => Filter);
				NotifyOfPropertyChange(() => FilteredItems);
			}
		}

		public List<T> FilteredItems
		{
			get
			{
				if (_items == null)
				{
					return _items;
				}

				return (from i in _items
								where i.IsValidFilter(_filter)
								//orderby i.OrderBy()
								select i).ToList();
			}
		}

		#endregion

		#region Overrides

		public override void ItemsUpdated()
		{
			base.ItemsUpdated();

			NotifyOfPropertyChange(() => FilteredItems);
		}

		#endregion
	}
}