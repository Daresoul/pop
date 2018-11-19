module Awari
type pit = int
type board = int list
type player = Player1 | Player2

// intentionally many missing implementations and additions

let getItem (l: int list) p =
    l.[p]

let clearPit (l: int list) p =
    let a = l.[0..p-1]
    let b = [0]
    let c = l.[p+1..13]
    a @ b @ c

let rec distribute (l: board) (p : pit) (b : int) : board * pit = 

  let a = l.[..p-1] //Tager listen og klippe første del og gemmer det. 
  let d = [l.[p]+1] //gemmer pittet som vælges
  let c = l.[p+1..] //Listerne efter
  let uL = a @ d @ c

  if p >= 13 then
      distribute uL 0 (b-1)
  elif b <= 1 then
      (uL, p)
  else
      distribute uL (p+1) (b-1)

let printBoard(b: board): unit = //For printing the board a variation of the Maurits-printing-metoed seen in previus assigment.
  printfn "    1  2  3  4  5  6\n         <--       \n    %i  %i  %i  %i  %i  %i\n %i        Awari       %i\n    %i  %i  %i  %i  %i  %i" (b.Item(6)) (b.Item(5)) (b.Item(4)) (b.Item(3)) (b.Item(2)) (b.Item(1)) (b.Item(7)) (b.Item(0)) (b.Item(8)) (b.Item(9)) (b.Item(10)) (b.Item(11)) (b.Item(12)) (b.Item(13))  
  //Spacial locality? What is that... 

let findWinner (b : board) : string =
  let player1Pit = b.[7]
  let player2Pit = b.[0]

  if(player1Pit > player2Pit) then
    sprintf "Player 1 won with %i points, while Player 2 had %i" player1Pit player2Pit
  else
    sprintf "Player 2 won with %i points, while Player 1 had %i" player2Pit player1Pit



let isGameOver (b : board) : bool =
  if b.IsEmpty then
    true
  else
    // checker om player1's side består af 0 pinde
    let player2gameover = List.forall (fun elem -> elem = 0) b.[1..6]
    // checker om player2's side består af 0 pinde
    let player1gameover = List.forall (fun elem -> elem = 0) b.[8..13]
  
    // Returner resultater fra udregninger ovenfor
    if player1gameover then
      player1gameover
    elif player2gameover then
      player2gameover
    else
      false

let isHome (b : board) (p : player) (i : pit) : bool =

  // Hvis listen er tom er der ingen hjem derfor return false
  if b.IsEmpty then
    false
  else
    // Finder ud af hvor stort halvdelen af boardet er
    let halfBoardLen = b.Length / 2

    // Plyayer 1's hjem er det første elem (kan også udregnes som 0) men det samme som halvdelen af boardets længde minus halvdelen af boardets længde
    let player1Home = halfBoardLen - halfBoardLen

    // Player 2's hjem kan udregnes ved at halvere boardets længde (kan også bare laves som halfBoardLen)
    let player2Home = b.Length - halfBoardLen

    // Checker hvilken spiller der skal tjekkes om er hjemme
    match p with
    | Player1 ->
      if i = 7 then
        true
      else
        false

    | Player2 ->
      if i = 0 then
        true
      else
        false

//Checks if a pit is epmty. If so returns -1, else retuns the object pit.
let pitEmpty (b:board)(i:int)(x:pit): pit = 
  if ((b.Item(i))=0) then  -1 else x;

//Since the board list goes the reveresd of the numbers player one uses, the numbers are matched here. 
let reverseNumbers(i:int): int =
  match i with
  | 1 -> 6
  | 2 -> 5
  | 3 -> 4
  | 4 -> 3
  | 5 -> 2
  | 6 -> 1


let getMove (b : board) (p:player) (q:string) : pit =
  printfn "%s" q

  let userInput = System.Console.ReadLine()

  let userInt = System.Int32.TryParse(userInput)
  
  match userInt with
  | (true, pitValue) ->
    if pitValue < 7 && pitValue > 0 then
        match p with
        | Player1     -> pitEmpty b (reverseNumbers(snd(userInt))) ((b.Length / 2) - abs pitValue)
        | Player2     -> pitEmpty b (snd(userInt)+7) ((b.Length / 2) + abs pitValue)
    else
      -1
  | _           -> -1



let turn (b : board) (p : player) : board =
  
  let rec repeat (b: board) (p: player) (n: int) (t : bool) : board =
    printBoard b
    let str = 
      if n = 0 then
        if t then
          sprintf "Invalid user input, please select number between 1 - 6, and be sure that there is one or more beans in the pit. \nPlayer %A's move? " p
        else
          sprintf "Player %A's move? " p
      else
        if t then
          sprintf "Invalid user input, please select number between 1 - 6, and be sure that there is one or more beans in the pit.\nAgain?"
        else
          sprintf "Again?"
    let i = getMove b p str
    if i <> -1 then  //If move is true enteres this loop. 

      if(i = 13) then //If play2 selects last index in board list. 
        let (newB, finalPit) = (distribute (clearPit b i) (0) (getItem b i))
        //printfn "Here %b\n" (isHome b p finalPit)
        if not (isHome b p finalPit) || (isGameOver newB) then
          newB
        else
          //printfn "Yass it is called"
          repeat newB p (n + 1) false
      else
        let (newB, finalPit) = (distribute (clearPit b i) (1+i) (getItem b i))
        //printfn "Also here %b" (isHome b p finalPit) //<----
        if not (isHome b p finalPit) || (isGameOver newB) then
          newB
        else
          //printfn "yass it is called"
          repeat newB p (n + 1) false
    else
      repeat b p n true //If move is false. 

  repeat b p 0 false

let rec
 play (b : board) (p : player) : board =
  if isGameOver b then
    printfn "%s" (findWinner b)
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
