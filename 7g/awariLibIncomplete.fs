module Awari
type pit = int
type board = int list
type player = Player1 | Player2

// intentionally many missing implementations and additions

let getItem (l: int list) p =
    l.[p]

let clearPit (l: int list) p =
    let æ = l.[0..p-1]
    let ø = [0]
    let å = l.[p+1..13]
    æ @ ø @ å

let rec distribute (l: board) (p : pit) (b : int) : board * pit =
    let æ = l.[0..p-1]
    let ø = [l.[p]+1]
    let å = l.[p+1..13]
    let uL = æ @ ø @ å

    if p >= 13 then
        distribute uL 0 (b-1)
    elif b <= 1 then
        (uL, p)
    else
        distribute uL (p+1) (b-1)

let printBoard (l: int list) =
    let w = 5
    printf "\n\n%*s" w ""

    let æ = List.rev l.[0..5]
    for e in æ do
        printf "%-*i" w e
    printf "\n"

    printf "%-*i%*s%*s%*s%*s%*s%*s%-*i\n%*s" w l.[6] w "" w "" w "" w "" w "" w "" w l.[13] w ""

    let å = l.[7..12]
    for e in å do
        printf "%-*i" w e

    printf "\nEnter an integer between 0 to 5 or 7 to 12: "

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
      if i = player1Home then
        true
      else
        false

    | Player2 ->
      if i = player2Home then
        true
      else
        false

let getMove (b : board) (p:player) (q:string) : pit =
  printfn "%s" q

  let userInput = System.Console.ReadLine()

  let userInt = System.Int32.TryParse(userInput)

  match userInt with
  | (true, pitValue) ->
    if pitValue < 7 && pitValue > 0 then
      match p with
      | Player1     -> abs pitValue
      | Player2     -> b.Length - abs pitValue
    else
      -1
  | _           -> -1

let turn (b : board) (p : player) : board =
  
  
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str = 
      if n = 0 then
        sprintf "Player %A's move? " p
      else 
        "Again? "
    let i = getMove b p str
    let (newB, finalPit) = (distribute b i (getItem b i))
    if not (isHome b p finalPit) 
       || (isGameOver newB) then
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
