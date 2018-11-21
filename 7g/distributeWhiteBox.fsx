let board : Awari.board = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let player1 = Awari.Player1
// For b <= 1 and p != 13
let pit1 = 1
let distributedBoard1 = Awari.distribute board pit1 1 player1
let expOutput1 = ([0; 4; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3], pit1)

printfn "pit: %i is function output as expected %A %b" pit1 distributedBoard1 (distributedBoard1 = expOutput1)

// for p = 13 and b <= 1
let pit2 = 13
let distributedBoard2 = Awari.distribute board pit2 1 player1
let expOutput2 = ([0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 4], pit2)

printfn "pit: %i is function output as expected %A %b" pit2 distributedBoard2 (distributedBoard2 = expOutput2)


// for p = 13 but b > 1
let pit3 = 13
let distributedBoard3 = Awari.distribute board pit3 2 player1
let expOutput3 = ([1; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 4], 0)

printfn "pit: %i is function output as expected %A %b" pit3 distributedBoard3 (distributedBoard3 = expOutput3)

// for p != 13 and b > 1
let pit4 = 1
let distributedBoard4 = Awari.distribute board pit4 3 player1
let expOutput4 = ([0; 4; 4; 4; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3], pit4 + 2)

printfn "pit: %i is function output as expected %A %b" pit4 distributedBoard4 (distributedBoard4 = expOutput4)

// for l.[p] = 0 and b = 1 and p != 0 and p != 7

let b = [0; 0; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let pit5 = 1
let distributedBoard5 = Awari.distribute b pit5 1 player1
let expOutput5 = ([0; 0; 3; 3; 3; 3; 3; 4; 3; 3; 3; 3; 3; 0], 1)
printfn "pit %i is function as expected %A %b" pit5 distributedBoard5 (expOutput5 = distributedBoard5)