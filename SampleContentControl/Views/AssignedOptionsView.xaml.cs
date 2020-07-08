using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using ReactiveUI;
using SampleContentControl.ViewModels;
using Splat;

namespace SampleContentControl.Views
{
	/// <summary>
	/// Interaction logic for AssignedOptionsView.xaml
	/// </summary>
	public partial class AssignedOptionsView : ReactiveUserControl<AssignedOptionsViewModel>
	{
		public AssignedOptionsView()
		{
			InitializeComponent();

			#region WhenActivated
			IDisposable _whenActivatedSub = null;
			_whenActivatedSub = this.WhenActivated(d =>
			{
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: AssignedOptionsView: WhenActivated():ViewModel is null: {null == ViewModel},  DataContext is null: {null == DataContext}");
				if (null == DataContext) DataContext = ViewModel;
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: AssignedOptionsView: ViewModel is null: {null == ViewModel}, DataContext is null: {null == DataContext}");
				// add any binding, commands, etc. here


				_whenActivatedSub.DisposeWith(d);
			});
			#endregion WhenActivated
		}
	}
}
