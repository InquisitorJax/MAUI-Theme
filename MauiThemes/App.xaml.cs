using MauiThemes.Services;

namespace MauiThemes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		AppTheme = new AppThemeService();
		AppTheme.Initialize();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }


    public static AppThemeService AppTheme { get; private set; }
}
