using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp
{
	public partial class ToDoItemAddPage : ContentPage
	{

		ToDoItemViewModel NewToDoItem;
		
		public ToDoItemAddPage()
        {
			InitializeComponent();
			ToDoItem NewItem = new ToDoItem() { Title = "", Completed = false } ;
			NewToDoItem = new ToDoItemViewModel(NewItem);
			BindingContext = NewToDoItem;
		}

		private async void AddToDoItem(object sender, EventArgs args)
		{
			
			//string toDoText = ToDoText.Text;
			//string toDoCompleted = ToDoCompleted.SelectedItem.ToString();
			Debug.WriteLine(@"\toDoText: "+ NewToDoItem.Title);
			Debug.WriteLine(@"\toDoCompleted: " + NewToDoItem.Completed);
		}


	}
}
