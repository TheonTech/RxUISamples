using System;
using System.Reactive.Disposables;
using ReactiveUI;
using SampleViewModelViewHost.ViewModels;
using Splat;

namespace SampleViewModelViewHost
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : ReactiveWindow<MainViewModel>
	{
		public MainWindow()
		{
			InitializeComponent();

			ViewModel = new MainViewModel();

			IDisposable _whenActivatedSub = null;
			_whenActivatedSub = this.WhenActivated(d =>
			{
				this
					.BindCommand(ViewModel, vm => vm.NavigateCommand, v => v.assignOptionsNavBtn)
					.DisposeWith(d);

				this
					.BindCommand(ViewModel, vm => vm.NavigateCommand, v => v.packagesNavBtn)
					.DisposeWith(d);

				this
					.BindCommand(ViewModel, vm => vm.NavigateCommand, v => v.optionsNavBtn)
					.DisposeWith(d);

				this
					.BindCommand(ViewModel, vm => vm.NavigateCommand, v => v.usersNavBtn)
					.DisposeWith(d);

				this
					.OneWayBind(ViewModel, vm => vm.CurrentViewModel, v => v.host.ViewModel)
					.DisposeWith(d);


				_whenActivatedSub.DisposeWith(d);
			});

		}
	}
}
