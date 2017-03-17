using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ChildCare.Administration.ViewModels;
using ChildCare.Common.Interfaces;

namespace ChildCare.Administration.Core
{
	public class Module : IModule
	{
		public void Load()
		{
			var dashboard = IoC.Get<IDashboard>();
			var image = Common.Utilities.ResourceManager.GetImageSource("family");
			dashboard.AddModule("Account", 1, image, () => new AccountMainViewModel());
		}
	}
}
