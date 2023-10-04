using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FashionChess.Controllers
{
    public class ChessController : Controller
    {
        public class ChessBoard
        {
            private class Cell
            {
                bool 
            }
        }

        private interface IChessFigure
        {
            public void choose();
            public void Move();
        }

        private abstract class ChessFigure : IChessFigure
        {
            private byte _xPosition { get; set; }
            private byte _yPosition { get; set; }


        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


    }
}
