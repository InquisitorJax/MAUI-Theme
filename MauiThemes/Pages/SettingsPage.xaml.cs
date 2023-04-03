using MauiThemes.Services;

namespace MauiThemes.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private void Switch_Toggled(object sender, ToggledEventArgs e)
	{
		var theme = App.AppTheme.ExplicitTheme == ThemeState.Dark ? ThemeState.Light : ThemeState.Dark;
		App.AppTheme.SetTheme(theme);
	}
}