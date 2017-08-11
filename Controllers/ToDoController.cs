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
        private readonly IToDoList _toDoBL;

        public ToDoController(IToDoList todoBL)
        {
            _toDoBL = todoBL;
        }

        [HttpGet]
        public async Task<JsonResult> GetItems()
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoBL.GetItems(token));
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoBL.GetItem(id, token));
        }

        [HttpPost]
        public async Task<JsonResult> AddItem()
        {
            String data = new System.IO.StreamReader(HttpContext.Request.Body).ReadToEnd();
            ToDoItem item = JsonConvert.DeserializeObject<ToDoItem>(data);
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoBL.AddItem(item, token));
        }

        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateItem(Guid id)
        {
            String data = new System.IO.StreamReader(HttpContext.Request.Body).ReadToEnd();
            ToDoItem item = JsonConvert.DeserializeObject<ToDoItem>(data);
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoBL.UpdateItem(item, token));
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteItem(Guid id)
        {
            var token = HttpContext.RequestAborted;
            return new JsonResult(await _toDoBL.DeleteItem(id, token));
        }

    }
}
