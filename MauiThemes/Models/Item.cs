using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiThemes.Models
{
	[ObservableObject]
	internal partial class Item
	{
		[ObservableProperty]
		private string _name;

		[ObservableProperty]
		private int _age;

		[ObservableProperty]
		private string _category;
	}
}
