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
}

