﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Shared
{
    public interface IRepo
    {
        Task<IEnumerable<ToDoItem>> GetItemsAsync(CancellationToken token);
        Task<ToDoItem> GetItemAsync(Guid id, CancellationToken token);
        Task<ToDoItem> AddOrUpdateItemAsync(CancellationToken token, ToDoItem item);
        Task<ToDoItem> DeleteItemAsync(Guid id, CancellationToken token);
    }
}