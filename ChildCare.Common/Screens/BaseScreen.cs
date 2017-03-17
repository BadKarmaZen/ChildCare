using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ChildCare.Common.Interfaces;

namespace ChildCare.Common.Screens
{
	public class BaseScreen : Screen, ICloseScreen
	{
		public virtual void CloseThisScreen()
		{
			
		}

		protected override void OnViewAttached(object view, object context)
		{
			//if (Menu != null)
			//{

			//	Menu.OnCreateMenu();
			//}

			base.OnViewAttached(view, context);
		}
	}
}
