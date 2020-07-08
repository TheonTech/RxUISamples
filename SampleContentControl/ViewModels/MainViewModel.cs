using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;

namespace SampleContentControl.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		#region Constructor
		public MainViewModel()
			: base()
		{
			_disposables = new CompositeDisposable();


			this.WhenActivated(async (d) => await OnActivated(d));
		}
		#endregion Constructor

		#region ReactiveUI OnActivated

		private async Task OnActivated(CompositeDisposable d)
		{
			Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: MainViewModel: OnActivated({++_activatedCount})");

			try
			{
				Title = $"LDKeyGen";
				CurrentViewModel = LoginViewModel;

				var canNavigate = this.WhenAnyValue(x => x.CurrentViewModel)
					.Select(y => !(y is LoginViewModel));

				_navigateCommand = ReactiveCommand.CreateFromObservable<string, Unit>(
						(view) =>
							{
								switch (view)
								{
									case "assignedOptions":
										CurrentViewModel = AssignedOptionsViewModel;
										break;
									case "options":
										CurrentViewModel = OptionsViewModel;
										break;
									case "packages":
										CurrentViewModel = PackagesViewModel;
										break;
									case "users":
										CurrentViewModel = UsersViewModel;
										break;
								}

								return Observable.Return(Unit.Default);
							});
						//	},
						//canNavigate);

			Disposable
				.Create(() => Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: MainViewModel: Deactivated."))
				.DisposeWith(d);
			}
			catch (Exception ex)
			{
				string msg = $"{ex.Message}:{Environment.NewLine}{ex.StackTrace}";
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: MainViewModel: Exception: ({msg})");
			}

			await Task.FromResult(Task.CompletedTask);
		}
		#endregion ReactiveUI OnActivated

		#region Observable Properties and/or Properties with backing fields

		//private readonly ObservableAsPropertyHelper<string> _title;
		//public string Title => _title.Value;


		private string _title;
		public string Title { get => _title; set => this.RaiseAndSetIfChanged(ref _title, value); }

		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel { get => _currentViewModel; set => this.RaiseAndSetIfChanged(ref _currentViewModel, value); }


		private LoginViewModel _loginViewModel;
		public LoginViewModel LoginViewModel
		{
			get => _loginViewModel ??= new LoginViewModel();
			set
			{
				if (_loginViewModel != value)
				{
					_loginViewModel?.Dispose();
					_loginViewModel = value;
				}
			}
		}

		private AssignedOptionsViewModel _assignedOptionsViewModel;
		public AssignedOptionsViewModel AssignedOptionsViewModel
		{
			get => _assignedOptionsViewModel ??= new AssignedOptionsViewModel();
			set
			{
				if (_assignedOptionsViewModel != value)
				{
					_assignedOptionsViewModel?.Dispose();
					_assignedOptionsViewModel = value;
				}
			}
		}

		private PackagesViewModel _packagesViewModel;
		public PackagesViewModel PackagesViewModel
		{
			get => _packagesViewModel ??= new PackagesViewModel();
			set
			{
				if (_packagesViewModel != value)
				{
					_packagesViewModel?.Dispose();
					_packagesViewModel = value;
				}
			}
		}

		private OptionsViewModel _optionsViewModel;
		public OptionsViewModel OptionsViewModel
		{
			get => _optionsViewModel ??= new OptionsViewModel();
			set
			{
				if (_optionsViewModel != value)
				{
					_optionsViewModel?.Dispose();
					_optionsViewModel = value;
				}
			}
		}


		private UsersViewModel _usersViewModel;
		public UsersViewModel UsersViewModel
		{
			get => _usersViewModel ??= new UsersViewModel();
			set
			{
				if (_usersViewModel != value)
				{
					_usersViewModel?.Dispose();
					_usersViewModel = value;
				}
			}
		}

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
		private ReactiveCommand<string, Unit> _navigateCommand;
		public ReactiveCommand<string, Unit> NavigateCommand => _navigateCommand;
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
