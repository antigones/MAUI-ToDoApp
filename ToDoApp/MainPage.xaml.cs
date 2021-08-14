﻿using System;
using Microsoft.Maui.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp
{
	public partial class MainPage : ContentPage
	{
		public ToDoListViewModel ToDoListViewModel { get; set; }

		public MainPage()
        {
			InitializeComponent();
			ToDoListViewModel = new ToDoListViewModel();
			BindingContext = ToDoListViewModel;
		}

        private async void OnAddToDoItemClicked(object sender, EventArgs args)
		{
            await Navigation.PushAsync(new ToDoItemAddPage());
			
		}

	}
}
