let board : Awari.board = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]

let pit = 1
let board1 : Awari.board = Awari.clearPit board pit
let expboard1 : Awari.board = [0; 0; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
printfn "pit %i now haves value %i was this correct?result list \n%A expected value\n%A %b\n\n" pit board1.[pit] board1 expboard1 (board1 = expboard1)

let pit1 = 3
let board2 : Awari.board = Awari.clearPit board pit1
let expboard2 : Awari.board = [0; 3; 3; 0; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
printfn "pit %i now haves value %i was this correct?result list \n%A expected value\n%A %b\n\n" pit1 board2.[pit1] board2 expboard2 (board2 = expboard2)
let pit2 = 7
let board3 : Awari.board = Awari.clearPit board pit2
let expboard3 : Awari.board = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
printfn "pit %i now haves value %i was this correct?result list \n%A expected value\n%A %b\n\n" pit2 board3.[pit2] board3 expboard3 (board3 = expboard3)
let pit3 = 13
let board4 : Awari.board = Awari.clearPit board pit3
let expboard4 : Awari.board = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 0]
printfn "pit %i now haves value %i was this correct?result list \n%A expected value\n%A %b\n\n" pit3 board4.[pit3] board4 expboard4 (board4 = expboard4)

