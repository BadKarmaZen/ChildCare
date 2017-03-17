using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using ChildCare.Common.Data;
using ChildCare.Common.Interfaces;
using ChildCare.Common.Utilities;
using ChildCare.ViewModels;

namespace ChildCare.Core
{
	public class Bootstrapper : BootstrapperBase
	{
		#region Consts

		private List<Assembly> _assemblies;

		#endregion

		#region Member

		private SimpleContainer _container;

		#endregion

		#region Construction

		public Bootstrapper()
		{
			InitApplication();
		}



		#endregion

		#region Overrides

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<ShellViewModel>();
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			return GetAssemblies();
		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}

		protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			base.OnUnhandledException(sender, e);
		}

		#endregion

		#region Helper Functions

		private void InitApplication()
		{
			try
			{
				_assemblies = base.SelectAssemblies().ToList();
				_container = new SimpleContainer();

				//	setup the default window manager
				//
				_container.RegisterInstance(typeof(IWindowManager), "WindowManager", new WindowManager());

				//	setup the event aggregator
				//
				_container.Singleton<IEventAggregator, EventAggregator>();

				//	setup dashboard
				//
				_container.RegisterInstance(typeof(IDashboard), "Dashboard", new DashBoard());

				//	setup Database
				//
				_container.RegisterInstance(typeof(IDataBaseConnection), "DatabaseConnectionFactory", new DatabaseConnectionFactory());

				//	Self register
				//
				_container.RegisterInstance(typeof(SimpleContainer), "SimpleContainer", _container);

				// register other for IoC
				//
				_container.PerRequest<ShellViewModel>();
				Initialize();
				LoadModules();
			}
			catch (Exception err)
			{
			}
		}

		protected void LoadModules()
		{
			var filenames = Directory.EnumerateFiles(Environment.CurrentDirectory, "ChildCare.*.dll");

			foreach (var filename in filenames)
			{
				var assembly = Assembly.LoadFile(filename);
				var modules = from t in assembly.GetTypes()
											where t.GetInterfaces().Contains(typeof(IModule))
											select t;

				foreach (var module in modules)
				{
					IModule foo = Activator.CreateInstance(module) as IModule;
					if (foo != null)
					{
						foo.Load();
					}
				}
			}
		}

		private IEnumerable<Assembly> GetAssemblies()
		{
			var filenames = Directory.EnumerateFiles(Environment.CurrentDirectory, "ChildCare.*.dll");

			foreach (var filename in filenames)
			{
				var assembly = Assembly.LoadFile(filename);

				_assemblies.Add(assembly);
			}
			return _assemblies;
		}

		#endregion
	}
}
