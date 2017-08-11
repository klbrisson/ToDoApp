using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp;

// The functions in this class use Task.Run() and a dictionary to simulate an asynchronous data request
public class ToDoRepo : IRepo
{
    // Adding for demo purposes
    private static ToDoItem _testToDoItem = new ToDoItem()
    {
        id = Guid.NewGuid(),
        text = "My first to do"
    };

    private static Dictionary<Guid, ToDoItem> _repo = new Dictionary<Guid, ToDoItem>()
    {
        // Adding for demo purposes
        { _testToDoItem.id, _testToDoItem }
    };

    /// <summary>
    /// Get a to do item
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<ToDoItem> GetItem(Guid id, CancellationToken token)
    {
        ToDoItem item = null;
        await Task.Run(() =>
            _repo.TryGetValue(id, out item)
        , token);
        return item;
    }

    /// <summary>
    /// Get all to do items 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<ToDoItem>> GetItems(CancellationToken token)
    {
        IEnumerable<ToDoItem> items = null;
        await Task.Run(() =>
            items = _repo.Values
        , token);
        return items;
    }

    /// <summary>
    /// Add or update a to do item
    /// </summary>
    /// <param name="item"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ToDoItem> AddOrUpdateItem(CancellationToken token, ToDoItem item)
    {
        if (item.id.Equals(new Guid()) || !_repo.ContainsKey(item.id))
        {
            item.id = Guid.NewGuid();
            await Task.Run(() =>
                _repo.Add(item.id, item)
            , token);
        }
        else
        {
            await Task.Run(() =>
                _repo[item.id] = item
            , token);
        }
        return item;
    }

    /// <summary>
    /// Delete a to do item
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ToDoItem> DeleteItem(Guid id, CancellationToken token)
    {
        ToDoItem item = null;
        await Task.Run(() => {
            _repo.TryGetValue(id, out item);
            _repo.Remove(id);
        }, token);
        return item;
    }

    
}
