using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ChildCare.Common.Events;
using Action = System.Action;

namespace ChildCare.ViewModels
{
	public class MenuItem
	{
		public string Caption { get; set; }
		public Action Action { get; set; }
	}

	public class MenuViewModel : Screen, IHandle<AddMenuEvent>
	{
		#region Members

		private ObservableCollection<MenuItem> _Items;
		private Action _homeAction;

		#endregion

		#region Properties
		public ObservableCollection<MenuItem> Items
		{
			get { return _Items; }
			set { _Items = value; NotifyOfPropertyChange(() => Items); }
		}

		#endregion

		public MenuViewModel(Action home)
		{
			_homeAction = home;
			Items = new ObservableCollection<MenuItem>();

			IoC.Get<IEventAggregator>().Subscribe(this);
		}

		public void AddMenu(MenuItem item)
		{
			if (Items.Count == 0)
			{
				AddHome();
			}
			Items.Add(item);
		}

		private void AddHome()
		{
			Items.Add(new MenuItem()
			{
				Caption = "Home",
				Action = _homeAction
			});
		}

		public void RemoveMenu(MenuItem item)
		{
			var index = Items.IndexOf(item);

			while (Items.Count > index)
			{
				Items.RemoveAt(index);
			}
		}

		public void Handle(AddMenuEvent message)
		{
			AddMenu(new MenuItem()
			{
				Caption = message.Caption,
				Action = message.Action
			});
		}

		public void ExecuteAction(MenuItem item)
		{
			RemoveMenu(item);
			ExecuteMenu(item);
		}

		private void ExecuteMenu(MenuItem item)
		{
			if (item != null && item.Action != null)
			{
				item.Action();
			}
		}
	}
}
