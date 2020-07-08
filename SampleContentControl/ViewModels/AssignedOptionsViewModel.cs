using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace SampleContentControl.ViewModels
{
	public class AssignedOptionsViewModel : ViewModelBase
	{
		#region Constructor
		public AssignedOptionsViewModel()
			: base()
		{
			_disposables = new CompositeDisposable();


			this.WhenActivated(async (d) => await OnActivated(d));
		}
		#endregion Constructor

		#region ReactiveUI OnActivated

		private async Task OnActivated(CompositeDisposable d)
		{
			Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: AssignedOptionsViewModel: OnActivated({++_activatedCount})");

			try
			{

				Disposable
					.Create(() => Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: AssignedOptionsViewModel: Deactivated."))
					.DisposeWith(d);
			}
			catch (Exception ex)
			{
				string msg = $"{ex.Message}:{Environment.NewLine}{ex.StackTrace}";
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: AssignedOptionsViewModel: Exception: ({msg})");
			}

			await Task.FromResult(Task.CompletedTask);
		}
		#endregion ReactiveUI OnActivated

		#region Observable Properties and/or Properties with backing fields
		#endregion Observable Properties and/or Properties with backing fields

		#region Automatic properties
		#endregion Automatic properties

		#region Fields
		private CompositeDisposable _disposables;
		private int _activatedCount = 0;
		#endregion Fields

		#region Events
		#endregion Events

		#region Commands
		#endregion Commands

		#region public Methods
		#endregion public Methods

		#region private/protected Methods
		#endregion private/protected Methods

		#region IDisposable Support
		private bool _isDisposed = false; // To detect redundant calls
		public bool IsDisposed { get => _isDisposed; set => this.RaiseAndSetIfChanged(ref _isDisposed, value); }

		protected override void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_disposables?.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				IsDisposed = true;
			}

			base.Dispose(disposing);
		}
		#endregion
	}
}
