using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiThemes.Models;
using MauiThemes.Pages;
using System.Collections.ObjectModel;

namespace MauiThemes.ViewModels
{
	internal partial class MainViewModel : ObservableObject
	{
		private bool _isInitialized = false;
		[ObservableProperty]
		private ObservableCollection<Item> _items = new();

		public Task InitializeAsync()
		{
			if (_isInitialized)
				return Task.CompletedTask;

			_isInitialized = true;
			for (int i = 0; i < 100; i++)
			{
				Items.Add(CreateItem(i));
			}

			return Task.CompletedTask;
		}

		private Item CreateItem(int id)
		{
			var item = new Item()
			{
				Age = id,
				Category = $"Cat {id}",
				Name = $"{id} NAME"
			};

			return item;
		}

		[RelayCommand]
		private async void NavigateToSettingsPage()
		{
			await Shell.Current.GoToAsync(nameof(SettingsPage));
		}

	}
}
