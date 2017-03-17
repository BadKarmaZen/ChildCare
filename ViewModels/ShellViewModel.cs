using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using ChildCare.Common.Events;
using ChildCare.Common.Interfaces;
using ChildCare.Common.Utilities;
using ChildCare.Core;
using Screen = Caliburn.Micro.Screen;

namespace ChildCare.ViewModels
{
	internal class ShellViewModel : Screen, IHandle<LoadModuleEvent>
	{
		#region Members

		private MenuViewModel _menu;
		private Screen _currentScreen;

		#endregion

		#region Properties

		public string ApplicationInfo
		{
			get
			{
				var version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
				return string.Format("DayCare V{0} - © 2017, Kurt Pattyn", version);
			}
		}

		public MenuViewModel Menu
		{
			get { return _menu; }
			set
			{
				_menu = value;
				NotifyOfPropertyChange(() => Menu);
			}
		}

		public Screen CurrentScreen
		{
			get { return _currentScreen; }
			set
			{
				_currentScreen = value;
				NotifyOfPropertyChange(() => CurrentScreen);
			}
		}

		#endregion

		#region Constructor

		public ShellViewModel()
		{
			var dashboard = IoC.Get<IDashboard>();

			dashboard.AddAction("Slaapstand", 1000, ResourceManager.GetImageSource("sleep"), () => GotoSleep());
			dashboard.AddAction("Sluiten", 1001, ResourceManager.GetImageSource("close"), () => TryClose());

			Menu = new MenuViewModel(() => LoadHomeScreen());
			LoadHomeScreen();

			IoC.Get<IEventAggregator>().Subscribe(this);
		}

		private void GotoSleep()
		{
			Application.SetSuspendState(PowerState.Suspend, true, true);
		}

		#endregion

		#region Actions

		public void LoadHomeScreen()
		{
			CurrentScreen = new HomeViewModel(IoC.Get<IDashboard>() as DashBoard);
		}

		#endregion

		public void Handle(LoadModuleEvent message)
		{
			if (message.Screen != null)
				CurrentScreen = message.Screen;
		}
	}
}
