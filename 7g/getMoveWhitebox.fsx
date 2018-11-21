//let getMove (b : board) (p:player) (q:string) : pit =

let player1 = Awari.Player1
let player2 = Awari.Player2

let q = "set move"

// Valid move with 3
let b1 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result1 = Awari.getMove b1 player1 q
let expresult1 = 4
printfn "getmove on with input 3 returns %i is this same as expected %b" result1 (expresult1 = result1)

// invalid move with 0
let result2 = Awari.getMove b1 player1 q
let expresult2 = -1
printfn "getmove on with input 0 returns %i is this same as expected %b" result2 (expresult2 = result2)


// invalid move with 7
let result3 = Awari.getMove b1 player1 q
let expresult3 = -1
printfn "getmove on with input 7 returns %i is this same as expected %b" result3 (expresult3 = result3)


// invalid move with abc
let result4 = Awari.getMove b1 player1 q
let expresult4 = -1
printfn "getmove on with input abc returns %i is this same as expected %b" result4 (expresult4 = result4)
