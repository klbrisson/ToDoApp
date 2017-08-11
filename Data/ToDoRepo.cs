using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp;

// The functions in this class use Task.Run and a dictionary to simulate an asynchronous data request
public class ToDoRepo : IRepo
{
    private ConcurrentDictionary<Guid, ToDoItem> repo = new ConcurrentDictionary<Guid, ToDoItem>();

    public ToDoRepo()
    {
        // Adding for demo purposes
        var item = new ToDoItem()
        {
            id = Guid.NewGuid(),
            text = "My first to do"
        };
        repo.TryAdd(item.id, item);
    }

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
            repo.TryGetValue(id, out item)
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
            items = repo.Values
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
        if (item.id.Equals(new Guid()))
        {
            item.id = Guid.NewGuid();
        }

        await Task.Run(() =>
            repo.AddOrUpdate(item.id, item, (id, old) => item)
        , token);
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
        await Task.Run(() =>
            repo.TryRemove(id, out item)
        , token);
        return item;
    }

    
}
