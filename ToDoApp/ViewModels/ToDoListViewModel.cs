
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; set; }

        public ToDoListViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItemViewModel>();
            PopulateList();
        }

        private async void PopulateList()
        {
            ToDoItems.Clear();

            List<ToDoItem> todos = await FetchToDoList();

            foreach (ToDoItem todo in todos)
            {
                ToDoItems.Add(new ToDoItemViewModel(todo));
            }

        }

        private static async Task<List<ToDoItem>> FetchToDoList()
        {
            var streamTask = client.GetStreamAsync("https://jsonplaceholder.typicode.com/users/1/todos");
            List<ToDoItem> todos = await JsonSerializer.DeserializeAsync<List<ToDoItem>>(await streamTask);
            return todos;
        }

        public async Task<ObservableCollection<ToDoItemViewModel>> addToDoItem()
        {
            ToDoItem item = new ToDoItem()
            {
                Title = "New Item",
                Completed = false
            };

            string json = JsonSerializer.Serialize<ToDoItem>(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            
            response = await client.PostAsync("https://jsonplaceholder.typicode.com/users/1/todos", content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");
                var responseStream = response.Content.ReadAsStreamAsync();
                ToDoItem addedItem = await JsonSerializer.DeserializeAsync<ToDoItem>(await responseStream);
                ToDoItems.Add(new ToDoItemViewModel(addedItem));
            }

            return ToDoItems;
        }

        private static readonly HttpClient client = new HttpClient();
    }
      
}
