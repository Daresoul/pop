let board = [0; 0; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3]
let pit = 6
let player = Awari.Player1
let printt = Awari.HitEmptyPit (board) pit player

printfn "print: %A" (printt)