using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Shared;
using ToDoApp.ViewModels;

// The functions in this class use Task.Run and a dictionary to simulate an asynchronous data request
namespace ToDoApp.Data
{
    public class ToDoRepo : IRepo
    {
        private readonly ConcurrentDictionary<Guid, ToDoItem> _repo = new ConcurrentDictionary<Guid, ToDoItem>();

        public ToDoRepo()
        {
            // Adding for demo purposes
            var item = new ToDoItem()
            {
                Id = Guid.NewGuid(),
                Text = "My first to do"
            };
            _repo.TryAdd(item.Id, item);
        }

        public async Task<ToDoItem> GetItemAsync(Guid id, CancellationToken token)
        {
            ToDoItem item = null;
            await Task.Run(() => _repo.TryGetValue(id, out item), token);
            return item;
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(CancellationToken token)
        {
            IEnumerable<ToDoItem> items = null;
            await Task.Run(() => items = _repo.Values, token);
            return items;
        }

        public async Task<ToDoItem> AddOrUpdateItemAsync(CancellationToken token, ToDoItem item)
        {
            if (item.Id.Equals(new Guid()))
            {
                item.Id = Guid.NewGuid();
            }

            await Task.Run(() => _repo.AddOrUpdate(item.Id, item, (id, old) => item), token);
            return item;
        }

        public async Task<ToDoItem> DeleteItemAsync(Guid id, CancellationToken token)
        {
            ToDoItem item = null;
            await Task.Run(() => _repo.TryRemove(id, out item), token);
            return item;
        }
    }
}
