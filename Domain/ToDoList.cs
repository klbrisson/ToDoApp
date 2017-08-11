using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Shared;
using ToDoApp.ViewModels;

namespace ToDoApp.Domain
{
    internal class ToDoList : IToDoList
    {
        private readonly IRepo _repo;

        public ToDoList(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<ToDoItem> GetItemAsync(Guid id, CancellationToken token)
        {
            return await _repo.GetItemAsync(id, token);
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(CancellationToken token)
        {
            return await _repo.GetItemsAsync(token);
        }

        public async Task<ToDoItem> UpdateItemAsync(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItemAsync(token, item);
        }

        public async Task<ToDoItem> AddItemAsync(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItemAsync(token, item);
        }

        public async Task<ToDoItem> DeleteItemAsync(Guid id, CancellationToken token)
        {
            return await _repo.DeleteItemAsync(id, token);
        }
    }
}