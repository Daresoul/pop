let board : Awari.board = []
let player1 : Awari.player = Awari.Player1
let player2 : Awari.player = Awari.Player2
let playerPit : Awari.pit = 0

printfn "empty list: %A" (Awari.isHome board player1 playerPit)

let board1 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]

printfn "full board player 1 home: %A" (Awari.isHome board1 player1 playerPit)

let playerPit1 : Awari.pit = 7
printfn "full board player 2 home: %A" (Awari.isHome board1 player2 playerPit1)

printfn "full board player 1 in player 2 home: %A" (Awari.isHome board1 player1 playerPit1)

let playerPit2 : Awari.pit = 0
printfn "full board player 2 in player 1 home: %A" (Awari.isHome board1 player2 playerPit2)

let playerPit3 : Awari.pit = 8
printfn "full board player 1 random spot: %A" (Awari.isHome board1 player1 playerPit3)

let playerPit4 : Awari.pit = 4
printfn "full board player 2 random spot: %A" (Awari.isHome board1 player2 playerPit4)