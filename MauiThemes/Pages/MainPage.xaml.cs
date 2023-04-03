using MauiThemes.ViewModels;

namespace MauiThemes.Pages;

public partial class MainPage : ContentPage
{
	private MainViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new MainViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_ = _viewModel.InitializeAsync();
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		int gridSpan = 1;
		if (width > 1000)
		{
			gridSpan = 3;
		}
		else if (width > 500)
		{
			gridSpan = 2;
		}

		// changing span not working when windows resizing
		// https://github.com/dotnet/maui/pull/13137
		if (_layout.Span != gridSpan)
		{
			// crash on iOS
			MainThread.BeginInvokeOnMainThread(() =>
			{
				_layout.Span = gridSpan;
			});
		}

	}

}

