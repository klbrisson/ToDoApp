using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Shared
{
    public interface IToDoList
    {
        Task<ToDoItem> AddItemAsync(ToDoItem item, CancellationToken token);
        Task<IEnumerable<ToDoItem>> GetItemsAsync(CancellationToken token);
        Task<ToDoItem> GetItemAsync(Guid id, CancellationToken token);
        Task<ToDoItem> UpdateItemAsync(ToDoItem item, CancellationToken token);
        Task<ToDoItem> DeleteItemAsync(Guid id, CancellationToken token);
    }
}