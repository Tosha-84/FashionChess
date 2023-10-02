using FashionChess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FashionChess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Что за строчка?
        private ApplicationDBContext db;


        /*public HomeController(ILogger<HomeController> logger)*/
        public HomeController(ApplicationDBContext context)
        {
            /*_logger = logger; // ?*/

            db = context;
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Authorize()
        {
            return Content(User.Identity.Name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}