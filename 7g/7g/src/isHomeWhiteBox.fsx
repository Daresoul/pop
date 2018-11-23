
// let isHome (b : board) (p : player) (i : pit) : bool =

let player1 = Awari.Player1
let player2 = Awari.Player2

// player 1 with empty board

let b = []
let result = Awari.isHome b player1 3
let expresult = false
printfn "player one with empty board result %b is it as expected %15b" result (result = expresult)

// Check if player 1 is home where he is home

let b1 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result1 = Awari.isHome b1 player1 7
let expresult1 = true
printfn "player one where is in home result %b is it as expected %15b" result1 (result1 = expresult1)

// Check if player 1 is home where he is on his own side

let b2 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result2 = Awari.isHome b2 player1 3
let expresult2 = false
printfn "player one where he is in pit 3 result %b is it as expected %15b" result2 (result2 = expresult2)

// check if player 1 is home while he is on opposite home

let b3 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result3 = Awari.isHome b3 player1 0
let expresult3 = false
printfn "player one where he is in opposite home result %b is it as expected %15b" result3 (result3 = expresult3)


// player 2 with empty board

let b4 = []
let result4 = Awari.isHome b4 player2 2
let expresult4 = false
printfn "player two with empty board result %b is it as expected %15b" result4 (result4 = expresult4)

// check if player 2 is home while being at home
let b5 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result5 = Awari.isHome b5 player2 0
let expresult5 = true
printfn "player two while being home %b is it as expected %15b" result5 (result5 = expresult5)

// check if player 2 is home while being on own side

let b6 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result6 = Awari.isHome b6 player2 10
let expresult6 = false
printfn "player two on pit 10 (on own side) result %b is it as expected %15b" result6 (result6 = expresult6)

// check if player 2 is home while being in opposite home
let b7 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result7 = Awari.isHome b6 player2 10
let expresult7 = false
printfn "player two while being in opposite home result %b is it as expected %15b" result7 (result7 = expresult7)