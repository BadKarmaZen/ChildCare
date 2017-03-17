using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCare.Common.Screens
{
	public class ListItemScreen<T> : BaseScreen
					where T : BaseItemUI
	{
		#region Members
		protected List<T> _items;
		protected T _selectedItem;

		#endregion

		#region Propteries
		public T SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value; NotifyOfPropertyChange(() => SelectedItem);
				NotifyOfPropertyChange(() => IsItemSelected);
			}
		}

		public bool IsItemSelected
		{
			get
			{
				return _selectedItem != null;
			}
		}

		public List<T> Items
		{
			get { return _items; }
			set { _items = value; ItemsUpdated(); }
		}

		public virtual void ItemsUpdated()
		{
			NotifyOfPropertyChange(() => Items);
		}
		#endregion

		#region Construction
		public ListItemScreen()
		{
		}

		#endregion

		#region Overrides
		protected override void OnViewLoaded(object view)
		{
			LoadItems();

			base.OnViewLoaded(view);
		}

		#endregion

		#region Methods

		public void SelectItem(T item = null)
		{
			if (SelectedItem != null)
			{
				SelectedItem.Selected = false;
			}

			SelectedItem = item;

			if (SelectedItem != null)
			{
				SelectedItem.Selected = true;
			}
		}

		protected virtual void LoadItems()
		{ }

		protected virtual void DeleteItem()
		{
			SelectItem();
			LoadItems();
		}

		#endregion
	}
}
