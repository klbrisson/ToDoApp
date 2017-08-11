using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal class ToDoList : IToDoList
    {
        private readonly IRepo _repo;

        public ToDoList(IRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get a to do item from the data repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> GetItemAsync(Guid id, CancellationToken token)
        {
            return await _repo.GetItemAsync(id, token);
        }

        /// <summary>
        /// Get all to do items from the data repo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(CancellationToken token)
        {
            return await _repo.GetItemsAsync(token);
        }

        /// <summary>
        /// Update a to do item in the repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> UpdateItemAsync(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItemAsync(token, item);
        }

        /// <summary>
        /// Add a new to do item to the repo
        /// </summary>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> AddItemAsync(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItemAsync(token, item);
        }

        /// <summary>
        /// Delete an item from the repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> DeleteItemAsync(Guid id, CancellationToken token)
        {
            return await _repo.DeleteItemAsync(id, token);
        }
    }
}