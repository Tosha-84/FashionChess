using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FashionChess.Controllers
{
    public class ChessController : Controller
    {
        public class ChessBoard
        {
            public class Cell
            {
                public bool color { get; set; }
                public ChessFigure figure { get; set; }

                public Cell(bool color)
                {
                    this.color = color;
                }
            }

            public Cell[,] board = new Cell[8, 8];

            public ChessBoard()
            {
                for (byte i = 0; i < 8; i++)
                {
                    for (byte j = 0; j < 8; j++)
                    {
                        if (((i % 2 == 0) && (j % 2 == 0)) || ((i % 2 != 0) && (j % 2 != 0))) board[i, j] = new Cell(true);
                        else if (((i % 2 == 0) && (j % 2 != 0)) || ((i % 2 != 0) && (j % 2 == 0))) board[i, j] = new Cell(false);
                    }
                }

                // Вывод доски на экран
                // for (byte i = 0; i < 8; i++)
                // {
                //     for (byte j = 0; j < 8; j++)
                //     {
                //         System.Consol    e.Write(board[i, j].color + " ");
                //     } 
                //     System.Console.WriteLine();
                // }
            }

        }

        private interface IChessFigure
        {
            public void Choose();
            public void Move();
        }

        public abstract class ChessFigure
        {
            private byte xPosition { get; set; }
            private byte yPosition { get; set; }
        }

        private class Pawn : ChessFigure, IChessFigure
        {
            public void Choose()
            {
                System.Console.WriteLine("Choose");
            }
            public void Move()
            {
                System.Console.WriteLine("Moove");
            }
        }



        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


    }
}
