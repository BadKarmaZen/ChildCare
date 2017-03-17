using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ChildCare.Common.Events;
using ChildCare.Common.Interfaces;
using ChildCare.Common.Model;
using ChildCare.Common.Screens;

namespace ChildCare.Administration.ViewModels
{
	public class AccountUI : TaggedItemUI<Account>
	{
	}

	public class AccountMainViewModel : FilteredListItemScreen<AccountUI>
	{
		#region Constructor
		public AccountMainViewModel()
		{
			//	register this screen to the menu
			var evnt = IoC.Get<IEventAggregator>();

			evnt.PublishOnUIThread(new AddMenuEvent()
			{
				Caption = "Accounts",
				Action = () => evnt.PublishOnUIThread(new LoadModuleEvent()
				{
					Screen = new AccountMainViewModel()
				})
			});
		}

		#endregion

		#region Overrides

		protected override void LoadItems()
		{
			using (var con = IoC.Get<IDataBaseConnection>().GetConnection())
			{
				var query = from a in con.Accounts.FindAll()
										select new AccountUI()
										{
											Name = a.Name,
											Tag = a
										};
				Items = query.ToList();
			}

			base.LoadItems();
		}

		#endregion

		#region Actions

		public void AddAction() { }

		public void EditAction() { }

		public void OpenAction(AccountUI account) { }

		public void DeleteAction() { }

		#endregion
	}
}
