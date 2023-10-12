function AddFigure(color, figure, div) {
    let img = document.createElement("img");
    
    img.setAttribute("src", "../../wwwroot/files/figures/" + color + "-" + figure + ".png");
    img.className = "figure";
    div.appendChild(img);
}

function GenerateChessBoard() {
    let chessBoard = document.querySelector("#chessBoard");

    for (let i = 0; i < 8; i++) {
        let ul = document.createElement("ul");
        ul.className = "navbar-nav flex-grow-1 d-table-cell";
        if (i % 2 == 0) odd = true;
        else odd = false;
        for (let j = 0; j < 8; j++) {
            let li = document.createElement("li");
            li.className = "nav-item";
            let div = document.createElement('div');


            if (odd) {
                if (j % 2 == 0) div.className = "cell b";
                else div.className = "cell w";
            }
            else {
                if (j % 2 == 0) div.className = "cell w";
                else div.className = "cell b";
            }

            div.id = "" + j + i;


            // Ниже - расстановка фигур
            if (div.id[0] == 1) {
                AddFigure("black", "pawn", div);
            }
            else if (div.id[0] == 6) {
                AddFigure("white", "pawn", div);
            }
            else if (div.id[0] == 0) {
                if ((div.id[1] == 0) || (div.id[1] == 7)) {
                    AddFigure("black", "rook", div);
                }
                else if ((div.id[1] == 1) || (div.id[1] == 6)) {
                    AddFigure("black", "knight", div);
                }
                else if ((div.id[1] == 2) || (div.id[1] == 5)) {
                    AddFigure("black", "bishop", div);
                }
                else if (div.id[1] == 3) {
                    AddFigure("black", "queen", div);
                }
                else {
                    AddFigure("black", "king", div);
                }
            }
            else if (div.id[0] == 7) {
                if ((div.id[1] == 0) || (div.id[1] == 7)) {
                    AddFigure("white", "rook", div);
                }
                else if ((div.id[1] == 1) || (div.id[1] == 6)) {
                    AddFigure("white", "knight", div);
                }
                else if ((div.id[1] == 2) || (div.id[1] == 5)) {
                    AddFigure("white", "bishop", div);
                }
                else if (div.id[1] == 3) {
                    AddFigure("white", "queen", div);
                }
                else {
                    AddFigure("white", "king", div);
                }
            }


            li.appendChild(div);
            ul.appendChild(li);
        }
        chessBoard.appendChild(ul);
    }
}

GenerateChessBoard();
