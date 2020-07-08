using ReactiveUI;
using SampleContentControl.Services;
using SampleContentControl.ViewModels;
using SampleContentControl.Views;
using Splat;

namespace SampleContentControl.Models
{
	public class AppBootstrapper
	{

		public AppBootstrapper()
		{
			ConfigureLogging();

			Locator.CurrentMutable.RegisterLazySingleton(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
			Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
			Locator.CurrentMutable.Register(() => new AssignedOptionsView(), typeof(IViewFor<AssignedOptionsViewModel>));
			Locator.CurrentMutable.Register(() => new PackagesView(), typeof(IViewFor<PackagesViewModel>));
			Locator.CurrentMutable.Register(() => new OptionsView(), typeof(IViewFor<OptionsViewModel>));
			Locator.CurrentMutable.Register(() => new UsersView(), typeof(IViewFor<UsersViewModel>));

		}

		private void ConfigureLogging()
		{
#if DEBUG
			Locator.CurrentMutable.RegisterConstant(new LoggingService { Level = LogLevel.Debug }, typeof(ILogger));
#endif
		}
	}
}
