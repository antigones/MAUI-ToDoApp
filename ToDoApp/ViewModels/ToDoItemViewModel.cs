using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class ToDoItemViewModel
    {
        public ToDoItemViewModel(ToDoItem toDoItem)
        {
            _title = toDoItem.Title;
            _completed = toDoItem.Completed;
           
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _completed;
        public string Completed
        {
            get {
                if (_completed) return "Completed";
                return "Not Completed";
            }
            set {
                if (value == "Completed")
                    _completed = true;
                _completed = false;
            }
        }

    }
}
