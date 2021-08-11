
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ToDoListViewModel
    {

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public ToDoListViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();
            PopulateList();
        }

        private async void PopulateList()
        {
            ToDoItems.Clear();

            List<ToDoItem> todos = await FetchToDoList();

            foreach (ToDoItem todo in todos)
            {
                ToDoItems.Add(todo);
            }

        }

        private static async Task<List<ToDoItem>> FetchToDoList()
        {
            var streamTask = client.GetStreamAsync("https://jsonplaceholder.typicode.com/users/1/todos");
            List<ToDoItem> todos = await JsonSerializer.DeserializeAsync<List<ToDoItem>>(await streamTask);
            return todos;
        }

        private static readonly HttpClient client = new HttpClient();
    }
      
}
