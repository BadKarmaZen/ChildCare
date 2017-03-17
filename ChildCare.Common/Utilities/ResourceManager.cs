using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChildCare.Common.Utilities
{
	public class ResourceManager
	{
		public static ImageSource GetImageSource(string resourceName)
		{
			//	/ChildCare.Administration;component/Resources/Images/family.png
			//	pack://application:,,,
			try
			{
				string assembly = Assembly.GetCallingAssembly().GetName().Name;
				string filename = $"pack://application:,,,/{assembly};component/Resources/Images/{resourceName}.png";
				var image = new BitmapImage(new Uri(filename, UriKind.Absolute));
				image.Freeze();
				return image;
			}
			catch (Exception ex)
			{
				throw;
			}

			return null;
		}
	}
}
