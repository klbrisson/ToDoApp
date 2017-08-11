using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoList _toDoBL;

        //public HomeController(IToDoList todoBL)
        //{
        //    _toDoBL = todoBL;
        //}

        public IActionResult Index()
        {
            //_toDoBL.AddToDoItem()
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
