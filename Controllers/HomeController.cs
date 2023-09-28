using FashionChess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace FashionChess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Что за строчка?
        private ApplicationDBContext db;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // ?

            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}