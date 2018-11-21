// Checking for pit is empty
let b = [0; 0; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let i = 0
let x = 2

let result = Awari.pitEmpty b i x
let expresult = -1
printfn "is the pit empty %i and are expected result the same %b" result (expresult = result)

// checking for pit is not empty

let b1 = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let i1 = 1
let x1 = 2

let result1 = Awari.pitEmpty b1 i1 x1 
let expresult1 = x1
printfn "is the pit empty %i and are expected result the same %b" result1 (expresult1 = result1)