using System;

namespace ToDoApp.ViewModels
{
    public class ToDoItem
    {
        public string Text { get; set; }
        public bool Completed { get; set; }
        public Guid Id { get; set; }
    }
}