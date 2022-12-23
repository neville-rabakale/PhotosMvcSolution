using Microsoft.AspNetCore.Mvc;
using PhotosMvc.Models;
using PhotosMvc.Views.Home;
using System.Diagnostics;

namespace PhotosMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataService service;

        public HomeController(DataService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var model = await service.GetPhotosAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}