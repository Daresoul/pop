
let board = [0; 3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]

printfn "Init board: %A" (Awari.isGameOver board)
let board1 = [0; 0; 0; 0; 0; 0; 3; 0; 3; 3; 3; 3; 3; 3]
printfn "all except one 0 on one side: %A" (Awari.isGameOver board1)

let board2 = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 3]
printfn "all except one 0: %A" (Awari.isGameOver board2)

let board3 = [0; 0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3]
printfn "all player 1 side empty: %A" (Awari.isGameOver board3)

let board4 = [0; 3; 3; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0]
printfn "all player 2 side empty: %A" (Awari.isGameOver board4)