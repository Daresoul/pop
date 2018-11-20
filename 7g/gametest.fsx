printfn "\nWin Player 1 test(1) ";
let board1 : Awari.board = [0; 3; 3; 3; 3; 3; 3; 1; 0; 0; 0; 0; 0; 0]
Awari.play (board1) (Awari.Player1)
printfn "\nWin Player 1 test(2)";
let board2 : Awari.board = [0; 0; 0; 0; 0; 0; 0; 1; 3; 3; 3; 3; 3; 3]
Awari.play (board2) (Awari.Player1)
printfn "\nWin Player 2 test (1)";
let board3 : Awari.board = [1; 3; 3; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0]
Awari.play (board3) (Awari.Player1)
printfn "\nWin Player 2 test (2)";
let board4 : Awari.board = [1; 0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3]
Awari.play (board4) (Awari.Player1)
printfn "\nDraw test (1)";
let board5 : Awari.board = [1; 3; 3; 3; 3; 3; 3; 1; 0; 0; 0; 0; 0; 0]
Awari.play (board5) (Awari.Player1)
printfn "\nDraw test (2)";
let board6 : Awari.board = [1; 0; 0; 0; 0; 0; 0; 1; 3; 3; 3; 3; 3; 3]
Awari.play (board6) (Awari.Player1)

printfn "\nDristribution check.";
let board7 : Awari.board = [0; 1; 1; 0; 1; 1; 1; 0; 3; 3; 3; 3; 3; 3]
printfn "%A" board7
printfn "%A" (Awari.distribute (board7) 3 2)

(*printfn "\nIlligal move zero select and out of range. Press 4, press non (1-6)";
let board8 : Awari.board = [0; 1; 1; 0; 1; 1; 1; 0; 3; 3; 3; 3; 3; 3]
Awari.play (board8) (Awari.Player1)*)