using System.Windows;
using ReactiveUI;
using SampleContentControl.Models;
using SampleContentControl.ViewModels;
using Splat;

namespace SampleContentControl
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private AppBootstrapper _bootStrapper;

		public App()
		{
			_bootStrapper = new AppBootstrapper();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = (MainWindow)Locator.Current.GetService<IViewFor<MainViewModel>>();
			Current.MainWindow = mainWindow;
			Current.MainWindow.Show();
		}
	}
}
