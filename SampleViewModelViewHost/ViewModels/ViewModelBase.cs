using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using ReactiveUI;

namespace SampleViewModelViewHost.ViewModels
{
	public abstract class ViewModelBase : ReactiveObject, IActivatableViewModel, IDisposable
	{
		#region Constructor
		public ViewModelBase()
			: base()
		{
			_disposables = new CompositeDisposable();
			Activator = new ViewModelActivator();

			this.WhenActivated(async (d) => await OnActivated(d));
		}
		#endregion Constructor

		#region ReactiveUI OnActivated

		private async Task OnActivated(CompositeDisposable d)
		{
			Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: OnActivated({++_activatedCount})");

			try
			{

				Disposable
					.Create(() => Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: Deactivated."))
					.DisposeWith(d);
			}
			catch (Exception ex)
			{
				string msg = $"{ex.Message}:{Environment.NewLine}{ex.StackTrace}";
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: Exception: ({msg})");
			}

			await Task.FromResult(Task.CompletedTask);
		}
		#endregion ReactiveUI OnActivated

		#region Observable Properties and/or Properties with backing fields
		#endregion Observable Properties and/or Properties with backing fields

		#region Automatic properties
		#region IActivatableViewModel implementation
		public ViewModelActivator Activator { get; }
		#endregion IActivatableViewModel implementation
		//#region IRoutableViewModel implementation
		//public string UrlPathSegment { get; set; }
		//public IScreen HostScreen { get; set; }
		//#endregion IRoutableViewModel implementation
		#endregion Automatic properties

		#region Fields
		private CompositeDisposable _disposables;
		private int _activatedCount = 0;
		#endregion Fields

		#region IDisposable Support
		private bool _isDisposed = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
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

				_isDisposed = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ReactiveObservableBase() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

	}
}
