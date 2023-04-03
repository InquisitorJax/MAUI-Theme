using MauiThemes.Services;

namespace MauiThemes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		AppTheme = new AppThemeService();
		AppTheme.Initialize();
	}

	public static AppThemeService AppTheme { get; private set; }
}
