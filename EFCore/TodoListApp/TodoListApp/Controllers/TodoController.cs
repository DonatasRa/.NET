using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Todo> todos = _context.Todos.Where(t => t.Description != null).ToList();
            return View(todos);
        }
    }
}
