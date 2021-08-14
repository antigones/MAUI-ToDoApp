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
        private readonly ToDoItem _toDoItem;

        public ToDoItemViewModel(ToDoItem toDoItem)
        {
            _toDoItem = toDoItem;
           
        }

       
        public string Title
        {
            get { return _toDoItem.Title; }
            set { _toDoItem.Title = value; }
        }


        public string Completed
        {
            get {
                if (_toDoItem.Completed) return "Completed";
                return "Not Completed";
            }
            set {
                if (value == "Completed")
                    _toDoItem.Completed = true;
                _toDoItem.Completed = false;
            }
        }



    }
}
