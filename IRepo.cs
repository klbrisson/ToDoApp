using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoApp
{
    public interface IRepo
    {
        Task<IEnumerable<ToDoItem>> GetItems(CancellationToken token);
        Task<ToDoItem> GetItem(Guid id, CancellationToken token);
        Task<ToDoItem> AddOrUpdateItem(CancellationToken token, ToDoItem item);
        Task<ToDoItem> DeleteItem(Guid id, CancellationToken token);
    }
}