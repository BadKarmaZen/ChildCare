using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using ChildCare.Common.Events;
using Action = System.Action;

namespace ChildCare.Core
{
	public class DashBoardItem
	{
		public string Caption { get; set; }
		public int Index { get; set; }
		public Action Action { get; set; }
		public Func<Screen> ScreenAction { get; set; }
		public ImageSource Image { get; set; }

		public void ExecuteAction()
		{
			if (Action != null)
			{
				Action();
			}
			else if (ScreenAction != null)
			{
				IoC.Get<IEventAggregator>().PublishOnUIThread(
				new LoadModuleEvent
				{
					Screen = ScreenAction()
				});
			}
		}
	}
}
