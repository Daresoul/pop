module Awari
type pit = int
type board = int list
type player = Player1 | Player2

// intentionally many missing implementations and additions

let isGameOver (b : board) : bool =
  if b.IsEmpty then
    true
  else
    let player1gameover = List.forall (fun elem -> elem = 0) b.[1..6]
    let player2gameover = List.forall (fun elem -> elem = 0) b.[8..13]
  
    if player1gameover then
      player1gameover
    elif player2gameover then
      player2gameover
    else
      false

let isHome (b : board) (p : player) (i : pit) : bool =

  if b.IsEmpty then
    false
  else
    let halfBoardLen = b.Length / 2
    let player1Home = halfBoardLen - halfBoardLen
    let player2Home = b.Length - halfBoardLen

    match p with
    | Player1 ->
      if i = player1Home then
        true
      else
        false

    | Player2 ->
      if i = player2Home then
        true
      else
        false

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      else 
        "Again? "
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit) 
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0 

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
