module animals
open System

type symbol = char
type position = int * int
type neighbour = position * symbol

let mSymbol : symbol = 'm'
let wSymbol : symbol = 'w'
let eSymbol : symbol = ' '
let rnd = System.Random ()

/// An animal is a base class. It has a position and a reproduction counter.
type animal (symb : symbol, repLen : int) =
  let mutable _reproduction = rnd.Next(1,repLen)
  let mutable _pos : position option = None
  let _symbol : symbol = symb

  member this.symbol = _symbol
  member this.position
    with get () = _pos
    and set aPos = _pos <- aPos
  member this.reproduction = _reproduction
  member this.updateReproduction () =
    _reproduction <- _reproduction - 1
  member this.resetReproduction () =
    _reproduction <- repLen

  override this.ToString () =
    string this.symbol

/// A moose is an animal
type moose (repLen : int) =
  inherit animal (mSymbol, repLen)

  member this.tick () : moose option = 
    // Move


    this.updateReproduction()
    None // Intentionally left blank. Insert code that updates the moose's age and optionally an offspring.

/// A wolf is an animal with a hunger counter
type wolf (repLen : int, hungLen : int) =
  inherit animal (wSymbol, repLen)
  let mutable _hunger = hungLen

  member this.hunger = _hunger
  member this.updateHunger () =
    _hunger <- _hunger - 1
    if _hunger <= 0 then
      this.position <- None // Starve to death
  member this.resetHunger () =
    _hunger <- hungLen

  member this.tick () : wolf option =
    
    // if reproduction tick timer is 0 then
      // and if hunger is over 50% then
        // reproduce (by) checking for a space in each direction
      //else check for eating
    // else
      // check if any moose nearby
        // eat
      // else
        // move somewhere

    this.updateReproduction() // Tells the reproduction tick timer to go 1 down

    this.updateHunger() // Tells the hunger tick timer to go 1 down

    None // Intentionally left blank. Insert code that updates the moose's age and optionally an offspring.
     


/// A board is a chess-like board implicitly representedy by its width and coordinates of the animals.
type board =
  {width : int;
   mutable moose : moose list;
   mutable wolves : wolf list;}

/// An environment is a chess-like board with all animals and implenting all rules.
type environment (boardWidth : int, NMooses : int, mooseRepLen : int, NWolves : int, wolvesRepLen : int, wolvesHungLen : int, verbose : bool) =
  let mutable _board : board = {
    width = boardWidth;
    moose = List.init NMooses (fun i -> moose(mooseRepLen));
    wolves = List.init NWolves (fun i -> wolf(wolvesRepLen, wolvesHungLen));
  }

  /// Project the list representation of the board into a 2d array.
  let draw (b : board) : char [,] =
    let arr = Array2D.create<char> boardWidth boardWidth eSymbol
    for m in b.moose do
      Option.iter (fun p -> arr.[fst p, snd p] <- mSymbol) m.position
    for w in b.wolves do
      Option.iter (fun p -> arr.[fst p, snd p] <- wSymbol) w.position
    arr

  /// return the coordinates of any empty field on the board.
  let anyEmptyField (b : board) : position =
    let arr = draw b
    let mutable i = rnd.Next b.width
    let mutable j = rnd.Next b.width
    while arr.[i,j] <> eSymbol do
      i <- rnd.Next b.width
      j <- rnd.Next b.width
    (i,j)

  // populate the board with animals placed at random.
  do for m in _board.moose do
       m.position <- Some (anyEmptyField _board)
  do for w in _board.wolves do
       w.position <- Some (anyEmptyField _board)
  member this.size = boardWidth*boardWidth
  member this.count = _board.moose.Length + _board.wolves.Length
  member this.board = _board

    member this.genMoveVector() =
      let rnd = System.Random().Next(0, 8)
      match rnd with
      | 0 -> (0, -1)
      | 1 -> (-1, -1)
      | 2 -> (-1, 0)
      | 3 -> (-1, 1)
      | 4 -> (0, 1)
      | 5 -> (1, 1)
      | 6 -> (1, 0)
      | 7 -> (1, -1)
      
  member this.moveAnimal(pos) =
    let moveVector = this.genMoveVector()
    match pos with
    | Some x ->
      let newPos = ((fst x) + fst moveVector, (snd x) + snd moveVector)


      (Some(newPos))
    | None -> None

  member this.countMoose =
    let mutable count = 0
    for m in _board.moose do
      match m.position with
      | Some (x) -> count <- count + 1
      | None -> count <- count

    count

  member this.countWolfs =
    let mutable count = 0
    for w in _board.wolves do
      match w.position with
      | Some (x) -> count <- count + 1
      | None -> count <- count

    count

  member this.checkForAnimalsAtPosition(pos) =
    let mutable verbose = true
    for w in _board.wolves do
      if w.position = Some pos then
        verbose <- false
    
    for m in _board.moose do
      if m.position = Some pos then
        verbose <- false
    
    verbose
  member this.checkValidMove(pos) =
    match pos with
    | Some x ->
      if fst x >= 0 && fst x < boardWidth && snd x >= 0 && snd x < boardWidth then
        if this.checkForAnimalsAtPosition(x) then
          true
        else
          false
      else
        false
    | None -> true

  member this.tick () = 
    for wolf in _board.wolves do
      wolf.tick()
    
    for moose in _board.moose do
      // for movement
      let mutable moveValid : bool = false

      while not moveValid do
        let newPos = this.moveAnimal(moose.position)

        if (this.checkValidMove(newPos)) then
          moveValid <- true
          moose.position <- newPos
          printfn "move made!"

      //moose.tick()

  override this.ToString () =
    let arr = draw _board
    let mooseCount = this.countMoose
    let wolfCount = this.countWolfs
    let mutable ret = "\n\n  "
    for j = 0 to _board.width-1 do
      ret <- ret + string (j % 10) + " "
    ret <- ret + "\n"
    for i = 0 to _board.width-1 do
      ret <- ret + string (i % 10) + " "
      for j = 0 to _board.width-1 do
        ret <- ret + string arr.[i,j] + " "
      ret <- ret + "\n"
    ret <- ret + "Animals: " + (mooseCount + wolfCount).ToString() + "\n"
    ret <- ret + "mooses: " + mooseCount.ToString() + "\n"
    ret <- ret + "wolves: " + wolfCount.ToString() + "\n\n"

    ret


type Game(maxtick : int) =

  let env = environment(10, 10, 10, 10, 10, 10, true)
  let mutable currentTick : int = 0
  let mutable gameInfo = ""
  member this.startGame() =
    while (currentTick <= maxtick) do
      env.tick()
      printfn "%s" (env.ToString())
      //gameInfo <- gameInfo + env.ToString()
      currentTick <- currentTick + 1

  member this.printgameInfo() = 
    printfn "%s" gameInfo