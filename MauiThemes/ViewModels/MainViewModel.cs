using CommunityToolkit.Mvvm.ComponentModel;
using MauiThemes.Models;
using System.Collections.ObjectModel;

namespace MauiThemes.ViewModels
{
	internal partial class MainViewModel : ObservableObject
	{
		[ObservableProperty]
		private ObservableCollection<Item> _items = new();

		public Task InitializeAsync()
		{
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

	}
}
