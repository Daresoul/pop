module animals
open System
open System.IO
open System.Collections.Generic

type symbol = char
type position = int * int
type neighbour = position * symbol

let mSymbol : symbol = 'm'
let wSymbol : symbol = 'w'
let eSymbol : symbol = ' '
let rnd = System.Random ()
let attackPercent = 0.5


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
    //printfn "%A %b" this.reproduction (this.reproduction <= 0)
    if this.reproduction <= 0 then
      Some (moose(repLen))
    else
      None

/// A wolf is an animal with a hunger counter
type wolf (repLen : int, hungLen : int) =
  inherit animal (wSymbol, repLen)
  let mutable _hunger = hungLen

  member this.hunger = _hunger
  member this.updateHunger () =
    _hunger <- _hunger - 1
    if _hunger <= 0 then
      this.position <- None
  member this.resetHunger () =
    _hunger <- hungLen

  member this.tick () : wolf option =
    if this.reproduction <= 0 then
      Some (wolf(repLen, hungLen))
    else
      None
     


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

    /// <summary>Gets a random direction (as vector)</summary>
    ///<returns>The vector of the direction the animal wanna move</returns>
    member this.genMoveVector() =
      let newrnd = System.Random().Next(0, 8)
      match newrnd with
      | 0 -> (0, -1)
      | 1 -> (-1, -1)
      | 2 -> (-1, 0)
      | 3 -> (-1, 1)
      | 4 -> (0, 1)
      | 5 -> (1, 1)
      | 6 -> (1, 0)
      | _ -> (1, -1) // i.e samme som 7


  /// <summary>This will create a new position for an animal</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  /// <returns>The new position option for the animal or None if already None</returns>
  member this.moveAnimal(pos) =
    let moveVector = this.genMoveVector()
    match pos with
    | Some x ->
      let newPos = ((fst x) + fst moveVector, (snd x) + snd moveVector)


      (Some(newPos))
    | None -> None

  /// <summary>Counts all mooses</summary>
  /// <returns>An integer of how many not dead mooses left</returns>
  member this.countMoose =
    let mutable count = 0
    for m in _board.moose do
      match m.position with
      | Some (x) -> count <- count + 1
      | None -> count <- count

    count

  /// <summary>Counts all wolfs</summary>
  /// <returns>An integer of how many not dead wolfs left</returns>
  member this.countWolfs =
    let mutable count = 0
    for w in _board.wolves do
      match w.position with
      | Some (x) -> count <- count + 1
      | None -> count <- count
    count

  /// <summary>Checks if any animal is at this position</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  /// <returns>false if anything was there and true if nothing is there</returns>
  member this.checkForAnimalsAtPosition(pos) =
    let mutable verbose = true
    for w in _board.wolves do
      if w.position = Some pos then
        verbose <- false
    
    for m in _board.moose do
      if m.position = Some pos then
        verbose <- false
    
    verbose
  /// <summary>Checks wether it is a legal move to make for the animal</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  /// <returns>true if the move is valid and false if it is not a valid move</returns>
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

  /// <summary>Checks if any animal is at this position</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  /// <returns>Sends back a tuple of string and bool where string represents the type of animal and if it was there</returns>
  member this.findMooseAtPosition(pos) =
    let mutable verbose = false
    for moose in _board.moose do
      if (moose.position = pos) then
        verbose <- true

    verbose


  member this.checkFieldsAround(pos) =
    match pos with
    | Some x ->
      let coords = [(0, -1); (-1, -1); (-1, 0); (-1, 1); (0, 1); (1, 1); (1, 0); (1, -1)]
      let mutable result = false
      for c in coords do
        if (this.checkValidMove (Some (fst x + fst c, snd x + snd c))) then
          result <- true
      
      result
          

    | None -> false

  /// <summary>Gets all the coordinates of the board around a given animal</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  /// <returns>a generic list with all the possible ways to move</returns>
  member this.CheckEating(pos) =
    let coords = [(0, -1); (-1, -1); (-1, 0); (-1, 1); (0, 1); (1, 1); (1, 0); (1, -1)]
    let mutable availableEatingSpaces = new List<position>()

    match pos with
    | Some(x) ->
      for i in coords do   
        if this.findMooseAtPosition(Some ((fst x + fst i), (snd x + snd i))) then
          availableEatingSpaces.Add((fst x + fst i, snd x + snd i))

          

      availableEatingSpaces

    | None -> availableEatingSpaces

  /// <summary>Kills a specific moose from its position</summary>
  /// <param name="pos">The position the animal is at right now, as an position option</param>
  member this.KillMooseFromPosition(pos) =
    for moose in _board.moose do
      if (moose.position = pos) then
        moose.position <- None

  // member this.removeMooseAt (index : int) =
  //   if _board.moose.Length > 0 then
  //     //Laver en tuple af om boolean og int
  //     // booleanen bliver lavet ved at den er true hvis den er alt andet end indexet.
  //     let checkedList = List.mapi (fun i el -> (i <> index, el)) _board.moose

  //     // tager den første tuple i alle elementerne i listen og tjekker om de er true, alt der ikke er true bliver smidt væk
  //     let filteredList = List.filter fst checkedList

  //     // laver listen af tupler om til den gamle liste uden det valgte index, det gør vi udfra snd tuplen af vores filterede liste.
  //     let newList = List.map snd filteredList
      
  //     _board.moose <- newList
  
  // member this.removeWolfAt (index : int) =
  //   printfn "list len: %A" _board.wolves.Length
  //   printfn "list: %A" _board.wolves.[index]
  //   printfn "index: %i" index

  //   if _board.wolves.Length > 0 then
  //     //Laver en tuple af om boolean og int
  //     // booleanen bliver lavet ved at den er true hvis den er alt andet end indexet.
  //     let checkedList = List.mapi (fun i el -> (i <> index, el)) _board.wolves

  //     // tager den første tuple i alle elementerne i listen og tjekker om de er true, alt der ikke er true bliver smidt væk
  //     let filteredList = List.filter fst checkedList

  //     // laver listen af tupler om til den gamle liste uden det valgte index, det gør vi udfra snd tuplen af vores filterede liste.
  //     let newList = List.map snd filteredList

  //     _board.wolves <- newList

  member this.mooseMove(i : int) =
    let moose = _board.moose.[i]

    match moose.tick() with
      | Some x ->
        //printfn "Moose choosing to reproduce"
        let coords = [(0, -1); (-1, -1); (-1, 0); (-1, 1); (0, 1); (1, 1); (1, 0); (1, -1)]
        if Option.isSome moose.position then
          let posValue = Option.get moose.position
          //printfn "%A" posValue
          let mutable hasBeenBorn = false
          for i = 0 to (coords.Length - 1) do
            if this.checkValidMove(Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])) then
              if not hasBeenBorn then
                _board.moose <- x::_board.moose
                x.position <- Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])
                moose.resetReproduction()
                hasBeenBorn <- true
      | None ->
        //printfn "Moose chose to move!"
        if this.checkFieldsAround(moose.position) then
          let mutable moveValid : bool = false

          while not moveValid do
            let newPos = this.moveAnimal(moose.position)

            if (this.checkValidMove(newPos)) then
              moveValid <- true
              moose.position <- newPos
        moose.updateReproduction()

  member this.wolfMove(i : int) =
    let wolf = _board.wolves.[i]

    let EatingPlaces = this.CheckEating( wolf.position )
    //printfn "%A" EatingPlaces
    if (EatingPlaces.Count = 0) then

      match wolf.tick() with
      | Some x ->
        let coords = [(0, -1); (-1, -1); (-1, 0); (-1, 1); (0, 1); (1, 1); (1, 0); (1, -1)]
        if Option.isSome wolf.position then
          let posValue = Option.get wolf.position
          let mutable hasBeenBorn = false
          for i = 0 to (coords.Length - 1) do
            if this.checkValidMove(Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])) then
              if not hasBeenBorn then
                _board.wolves <- x::_board.wolves
                x.position <- Some (fst posValue + fst coords.[i], snd posValue + snd coords.[i])
                wolf.resetReproduction()
                hasBeenBorn <- true
      | None ->
        // check around for move
        if this.checkFieldsAround(wolf.position) then
          let mutable moveValid : bool = false

          while not moveValid do
            let newPos = this.moveAnimal(wolf.position)

            if (this.checkValidMove(newPos)) then
              moveValid <- true
              wolf.position <- newPos
    else
      let attackChance = rnd.NextDouble()
      if (attackChance < attackPercent) then
        wolf.resetHunger()
        this.KillMooseFromPosition(Some (EatingPlaces.Item(0)))
        wolf.position <- Some (EatingPlaces.Item(0))

    wolf.updateReproduction()
    wolf.updateHunger()

  member this.removeDeadAnimals =
    let checkedListWolf = List.mapi (fun i el -> (_board.wolves.[i].position <> None, el)) _board.wolves
    let filteredListWolf = List.filter fst checkedListWolf
    let newListWolf = List.map snd filteredListWolf

    _board.wolves <- newListWolf

    let checkedListMoose = List.mapi (fun i el -> (_board.moose.[i].position <> None, el)) _board.moose
    let filteredListMoose = List.filter fst checkedListMoose
    let newListMoose = List.map snd filteredListMoose

    _board.moose <- newListMoose

  /// <summary>Moves all animals and make them do thir choices</summary>
  member this.tick () =
    let queList = this.makeQueue

    for animal in queList do
      if (fst animal) = "w" then
        this.wolfMove (snd animal)
      elif (fst animal) = "m" then
        this.mooseMove (snd animal)
    
    this.removeDeadAnimals

  member this.makeQueue =
    let any = System.Random()
    let mutable queue = []
    
    let mutable End = _board.wolves.Length-1
    for i=0 to End do
      queue <- ("w", i) :: queue
    
    End <- _board.moose.Length-1
    for i=0 to End do
      queue <- ("m", i) :: queue
    
    let mutable r = []

    End <- queue.Length-1
    for i=0 to End do
        let j = any.Next(0, queue.Length)
        r <- queue.[j] :: r
        queue <- List.filter (fun x -> not(x=queue.[j])) queue
    r

  member this.WriteOutInfo (currentTick : int) =
    let arr = draw _board
    let mooseCount = this.countMoose
    let wolfCount = this.countWolfs
    let mutable ret = "\n\n  "
    for j = 0 to _board.width-1 do
      ret <- ret + string (j) + " "
    ret <- ret + "\r\n"
    for i = 0 to _board.width-1 do
      ret <- ret + string (i) + " "
      for j = 0 to _board.width-1 do
        ret <- ret + string arr.[i,j] + " "
      ret <- ret + "\r\n"
    ret <- ret + "Animals: " + (mooseCount + wolfCount).ToString() + "\r\n"
    ret <- ret + "mooses: " + mooseCount.ToString() + "\r\n"
    ret <- ret + "wolves: " + wolfCount.ToString() + "\r\n"
    ret <- ret + "currentTick: " + currentTick.ToString() + "\r\n"
    ret <- ret + "moose list: " + _board.moose.Length.ToString() + "\r\n"
    ret <- ret + "wolf list: " + _board.wolves.Length.ToString() + "\r\n\r\n"

    ret

type Game(T : int, fileDest : string, n : int, e : int ,fe : int ,u : int ,fu : int ,s : int ) = 
//T = iterations, filDest = file destination, n = size of square sides, e = antal elge, fu = formenrings tid elge, u = ulve , fu = antal ulve, s = sult tid


  let env = environment(n, e, fu, u, fu, s, true)
  let mutable currentTick : int = 0
  let mutable gameInfo = ""

  member this.startGame() =
    while (currentTick <= T) do
      //printfn "%s" (env.WriteOutInfo(currentTick))
      env.tick()
      gameInfo <- gameInfo + env.WriteOutInfo(currentTick)
 
      currentTick <- currentTick + 1
    File.WriteAllText(fileDest, gameInfo)
    