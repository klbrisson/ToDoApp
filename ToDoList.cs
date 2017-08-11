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
        public async Task<ToDoItem> GetItem(Guid id, CancellationToken token)
        {
            return await _repo.GetItem(id, token);
        }

        /// <summary>
        /// Get all to do items from the data repo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ToDoItem>> GetItems(CancellationToken token)
        {
            return await _repo.GetItems(token);
        }

        /// <summary>
        /// Update a to do item in the repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> UpdateItem(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItem(token, item);
        }

        /// <summary>
        /// Add a new to do item to the repo
        /// </summary>
        /// <param name="item"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> AddItem(ToDoItem item, CancellationToken token)
        {
            return await _repo.AddOrUpdateItem(token, item);
        }

        /// <summary>
        /// Delete an item from the repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ToDoItem> DeleteItem(Guid id, CancellationToken token)
        {
            return await _repo.DeleteItem(id, token);
        }
    }
}