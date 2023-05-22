namespace MauiThemes.Services;


//doc: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/theming?view=net-maui-7.0
//issue?: https://github.com/dotnet/maui/issues/8236 - so fixed in 7.0.81 & 8.0.0 preview.3.8149?
// This is still broken for 7.0.302 VS 17.6.0

public class AppThemeService
{
	private ThemeState _currentTheme;

	public void Initialize()
	{
		_currentTheme = ResolveSystemTheme();
		SetTheme(_currentTheme);
	}

	public void SetTheme(ThemeState theme)
	{
		ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
		if (mergedDictionaries != null)
		{
			var themeDictionaries = mergedDictionaries.Where(d => d.GetType() == typeof(Resources.Styles.DarkTheme)
				|| d.GetType() == typeof(Resources.Styles.LightTheme)).ToList();

			foreach (var themeDictionary in themeDictionaries)
			{
				mergedDictionaries.Remove(themeDictionary);
			}

			if (theme == ThemeState.System)
			{
				theme = Application.Current.RequestedTheme == AppTheme.Dark ? ThemeState.Dark : ThemeState.Light;
			}

			switch (theme)
			{
				case ThemeState.Dark:
					mergedDictionaries.Add(new Resources.Styles.DarkTheme());
					break;
				case ThemeState.Light:
				default:
					mergedDictionaries.Add(new Resources.Styles.LightTheme());
					break;
			}
			_currentTheme = theme;
		}

		Application.Current.UserAppTheme = theme.AsOSAppTheme();
	}

	public ThemeState ExplicitTheme
	{
		get
		{
			var systemTheme = ResolveSystemTheme();
			return _currentTheme == ThemeState.System ? systemTheme : _currentTheme;
		}
	}

	public static ThemeState ResolveSystemTheme()
	{
		ThemeState systemTheme;
		switch (Application.Current.RequestedTheme)
		{
			case AppTheme.Dark:
				systemTheme = ThemeState.Dark;
				break;
			case AppTheme.Light:
				systemTheme = ThemeState.Light;
				break;
			default:
				systemTheme = ThemeState.Light;
				break;
		}
		return systemTheme;
	}

}

public enum ThemeState
{
	System,
	Dark,
	Light
}


public static class ThemeStateExtensions
{
	public static AppTheme AsOSAppTheme(this ThemeState theme)
	{
		AppTheme retOSTheme;

		switch (theme)
		{
			case ThemeState.Dark:
				retOSTheme = AppTheme.Dark;
				break;
			case ThemeState.Light:
				retOSTheme = AppTheme.Light;
				break;
			default:
				retOSTheme = AppTheme.Unspecified;
				break;
		}

		return retOSTheme;
	}
}
