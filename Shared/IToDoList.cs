using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoApp
{
    public interface IToDoList
    {
        Task<ToDoItem> AddItem(ToDoItem item, CancellationToken token);
        Task<IEnumerable<ToDoItem>> GetItems(CancellationToken token);
        Task<ToDoItem> GetItem(Guid id, CancellationToken token);
        Task<ToDoItem> UpdateItem(ToDoItem item, CancellationToken token);
        Task<ToDoItem> DeleteItem(Guid id, CancellationToken token);
    }
}