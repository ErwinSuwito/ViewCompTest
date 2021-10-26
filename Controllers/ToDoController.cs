using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewCompFinal.ViewModels;
using System.Collections.Generic;

namespace ViewComponentSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _ToDoContext;

        public ToDoController(ToDoContext context)
        {
            _ToDoContext = context;

            // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
            // see: https://github.com/aspnet/EntityFrameworkCore/issues/11666 
            _ToDoContext.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var viewmodel = new IndexViewModel()
            {
                TodoItems = _ToDoContext.ToDo.ToList(),
                PageLayout = "<vc:priority-list max-priority=\"2\" is-done=\"false\"></vc:priority-list>",
            };

            return View(viewmodel);
        }
        #region snippet_IndexVC
        public IActionResult IndexVC()
        {
            return ViewComponent("PriorityList", new { maxPriority = 3, isDone = false });
        }
        #endregion

        public async Task<IActionResult> IndexFinal()
        {
            return View(await _ToDoContext.ToDo.ToListAsync());
        }

        public IActionResult IndexNameof()
        {
            return View(_ToDoContext.ToDo.ToList());
        }
        public IActionResult IndexTypeof()
        {
            return View(_ToDoContext.ToDo.ToList());
        }

        public IActionResult IndexFirst()
        {
            return View(_ToDoContext.ToDo.ToList());
        }
    }
}
