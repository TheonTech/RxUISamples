using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using ReactiveUI;
using SampleViewModelViewHost.ViewModels;
using Splat;

namespace SampleViewModelViewHost.Views
{
	/// <summary>
	/// Interaction logic for UsersView.xaml
	/// </summary>
	public partial class UsersView : ReactiveUserControl<UsersViewModel>
	{
		public UsersView()
		{
			InitializeComponent();

			#region WhenActivated
			IDisposable _whenActivatedSub = null;
			_whenActivatedSub = this.WhenActivated(d =>
			{
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: UsersView: WhenActivated():ViewModel is null: {null == ViewModel},  DataContext is null: {null == DataContext}");
				if (null == DataContext) DataContext = ViewModel;
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: UsersView: ViewModel is null: {null == ViewModel}, DataContext is null: {null == DataContext}");
				// add any binding, commands, etc. here


				_whenActivatedSub.DisposeWith(d);
			});
			#endregion WhenActivated
		}
	}
}
