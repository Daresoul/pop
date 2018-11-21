//let emptyPit (b: board) (p: pit) (player : player): board * pit =
let b = [0; 0; 3; 0; 3; 3; 0; 0; 3; 3; 3; 3; 3; 3]
let player1 = Awari.Player1
let player2 = Awari.Player2

// player1 

let result = Awari.emptyPit b 1 player1
let expresult = ([0; 0; 3; 0; 3; 3; 0; 4; 3; 3; 3; 3; 3; 0], 1)
printfn "player 1 hit empty field and result %A was this as expected %b" result (result = expresult)

let result1 = Awari.emptyPit b 4 player1
let expresult1 = ([0; 0; 3; 0; 0; 3; 0; 7; 3; 3; 0; 3; 3; 3], 4)
printfn "player 1 hit empty field and result %A was this as expected %b" result1 (result1 = expresult1)

let result2 = Awari.emptyPit b 6 player1
let expresult2 = ([0; 0; 3; 0; 3; 3; 0; 4; 0; 3; 3; 3; 3; 3], 6)
printfn "player 1 hit empty field and result %A was this as expected %b" result2 (result2 = expresult2)

// player 2

let b1 = [0; 3; 3; 3; 3; 3; 3; 0; 0; 3; 0; 3; 3; 0]
let result3 = Awari.emptyPit b1 8 player2
let expresult3 = ([4; 0; 3; 3; 3; 3; 3; 0; 0; 3; 0; 3; 3; 0], 8)
printfn "player 2 hit empty field and result %A was this as expected %b" result3 (result3 = expresult3)

let result4 = Awari.emptyPit b1 10 player2
let expresult4 = ([4; 0; 3; 3; 3; 0; 3; 3; 8; 9; 0; 3; 3; 0], 10)
printfn "player 2 hit empty field and result %A was this as expected %b" result4 (result4 = expresult4)