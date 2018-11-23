
// Checking for player 1 winning
let b = [0; 0; 0; 0; 0; 0; 0; 1; 3; 3; 3; 3; 3; 3]
let result = Awari.findWinner b
let expResult = "Player 1 won with 1 points, while Player 2 had 0"
printfn "player 1 won is expected is expected result the same %b" (result = expResult)

// Checking for player 2 winning
let b1 = [1; 0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3]
let result1 = Awari.findWinner b1
let expResult1 = "Player 2 won with 1 points, while Player 1 had 0"
printfn "player 2 won is expected is expected result the same %b" (result1 = expResult1)

// Checking for draw
let b2 = [0; 0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3]
let result2 = Awari.findWinner b2
let expResult2 = "Both players are drawn with a score of 0:0!"
printfn "draw is expected is expected result the same %b" (result2 = expResult2)