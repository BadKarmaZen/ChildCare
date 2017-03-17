using System;
using System.Windows.Media;
using Caliburn.Micro;
using Action = System.Action;

namespace ChildCare.Common.Interfaces
{
	public interface IDashboard
	{
		void AddAction(string caption, int index, ImageSource image, Action action);
		void AddModule(string caption, int index, ImageSource image,  Func<Screen> action);
	}
}