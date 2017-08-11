using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoList _toDoList;

        public ToDoController(IToDoList todoBL)
        {
            _toDoList = todoBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetItems()
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.GetItems(token));
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.GetItem(id, token));
        }

        [HttpPost]
        public async Task<JsonResult> AddItem()
        {
            using(var reader = new System.IO.StreamReader(Request.Body))
            {
                var item = JsonConvert.DeserializeObject<ToDoItem>(await reader.ReadToEndAsync());
                var token = HttpContext.RequestAborted;
                return new JsonResult(await _toDoList.AddItem(item, token));
            }
        }

        [HttpPut]
        public async Task<JsonResult> UpdateItem()
        {
            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                var item = JsonConvert.DeserializeObject<ToDoItem>(await reader.ReadToEndAsync());
                var token = HttpContext.RequestAborted;
                return new JsonResult(await _toDoList.UpdateItem(item, token));
            }
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoList.DeleteItem(id, token));
        }

    }
}
