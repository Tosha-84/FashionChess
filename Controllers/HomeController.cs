using FashionChess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;

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

        private String UserName()
        {
            if (User.Identity.IsAuthenticated)
            {
                db.Users.Select(u => u.Name);
                return db.Users.Find(Int32.Parse(User.Identity.Name)).Name;
            }
            return null;
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
            ViewData["Name"] = UserName();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Authorize()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content("не аутентифицирован");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}