using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using ChildCare.Common.Interfaces;
using Action = System.Action;

namespace ChildCare.Core
{
	public class DashBoard : IDashboard
	{
		#region Properties
		public ObservableCollection<DashBoardItem> Items { get; set; }

		#endregion

		public DashBoard()
		{
			Items = new ObservableCollection<DashBoardItem>();
		}

		public void AddAction(string caption, int index, ImageSource image, Action action)
		{
			Items.Add(new DashBoardItem
			{
				Caption = caption,
				Index = index,
				Image = image,
				Action = action
			});
		}

		public void AddModule(string caption, int index, ImageSource image, Func<Screen> action)
		{
			Items.Add(new DashBoardItem
			{
				Caption =  caption,
				Index = index,
				Image = image,
				ScreenAction = action
			});
		}
	}
}
