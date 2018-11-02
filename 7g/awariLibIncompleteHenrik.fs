module Awari
type pit = int// intentionally left empty
type board = int list
type player = Player1 | Player2

// intentionally many missing implementations and additions

let printBoard(b: board): unit = //For printing the board a variation of the Maurits-printing-metoed seen in previus assigment.
  printfn "\n    %i  %i  %i  %i  %i  %i\n %i        Awari       %i\n    %i  %i  %i  %i  %i  %i" (b.Item(6)) (b.Item(5)) (b.Item(4)) (b.Item(3)) (b.Item(2)) (b.Item(1)) (b.Item(7)) (b.Item(0)) (b.Item(8)) (b.Item(9)) (b.Item(10)) (b.Item(11)) (b.Item(12)) (b.Item(13))  
  //Spacial locality? What is that... 

let isGameOver (b: board): int =
  let result1 = b.Item(0)
  let sum1 = List.fold(fun acc elem -> acc + elem) 0 b.[1..6]
  let result2 = b.Item(7)
  let sum2 = List.fold(fun acc elem -> acc + elem) 0 b.[8..13]//Better Spacial locality though
  if ((sum1 = 0)||(sum2=0)) then
    if result1=result2 then 3 //draw
    elif result1<result2 then 2 //play2 won
    else 1 //play 1 won
  else 0 //nobody won yet
    
let rec getMove (b: board) (p: player) : int option = 

  
(*
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
*)
(*
let rec play (b : board) (p : player) : board =
  let result = isGameOver b
  if (result) then
    b  
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP

*)
