// Checking for empty
let b = []
let result = Awari.isGameOver b
let expresult = true
printfn "is game over %b is this same as expected? %b" result (result = expresult)


// Checking for false
let b2 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let result2 = Awari.isGameOver b2
let expresult2 = false
printfn "is game over %b is this same as expected? %b" result2 (result2 = expresult2)

// Checking for false
let b3 = [0; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 3]
let result3 = Awari.isGameOver b3
let expresult3 = false
printfn "is game over %b is this same as expected? %b" result3 (result3 = expresult3)

// Checking for player 1 won
let b4 = [0; 0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3]
let result4 = Awari.isGameOver b4
let expresult4 = true
printfn "is game over %b is this same as expected? %b" result4 (result4 = expresult4)

// Checking for player 2 won
let b5 = [0; 3; 3; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0]
let result5 = Awari.isGameOver b5
let expresult5 = true
printfn "is game over %b is this same as expected? %b" result5 (result5 = expresult5)