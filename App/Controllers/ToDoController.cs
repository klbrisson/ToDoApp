using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using ToDoApp.Shared;
using ToDoApp.ViewModels;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoList _toDoList;

        public ToDoController(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        [HttpGet]
        public async Task<JsonResult> GetItems()
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.GetItemsAsync(token));
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.GetItemAsync(id, token));
        }

        [HttpPost]
        public async Task<JsonResult> AddItem()
        {
            using(var reader = new System.IO.StreamReader(Request?.Body))
            {
                var item = JsonConvert.DeserializeObject<ToDoItem>(await reader.ReadToEndAsync());
                var token = HttpContext.RequestAborted;
                return new JsonResult(await _toDoList.AddItemAsync(item, token));
            }
        }

        [HttpPut]
        public async Task<JsonResult> UpdateItem()
        {
            using (var reader = new System.IO.StreamReader(Request?.Body))
            {
                var item = JsonConvert.DeserializeObject<ToDoItem>(await reader.ReadToEndAsync());
                var token = HttpContext.RequestAborted;
                return new JsonResult(await _toDoList.UpdateItemAsync(item, token));
            }
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.DeleteItemAsync(id, token));
        }
    }
}
