using Microsoft.AspNetCore.Mvc;
using MVC_crash_course.Models;

namespace MVC_crash_course.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name = "keyboard" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}
