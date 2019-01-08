module Game
open Chess
open Pieces
open System.Windows.Forms

type game()=

  member this.validateAvailableMove (pos : int * int) (piece : chessPiece option) (board : Board) =
      // Just for security we are going to check if its a Some again
      match piece with
      | Some (p) -> 
        let availeableMoves = p.availableMoves board
        let mutable isItAvailAble = false

        for m in fst availeableMoves do
          printfn "check: %A = %A" m pos
          if (m = pos) then
            isItAvailAble <- true
        
        isItAvailAble
      | None ->
        false

  member this.checkValidMove (pos : int * int) (piece : chessPiece option) (board : Board) (player : int) = 
    match piece with
    | Some (p) ->
      
      // kan laves om til en enkelt ved at skrive en eller imellem de 2, ved ikke om det er bedre
      printfn "player: %i\ncolor: %A" player p.color
      if (player = 0 && p.color = Color.White) then
        this.validateAvailableMove pos piece board
      elif (player = 1 && p.color = Color.Black) then
        this.validateAvailableMove pos piece board
      else
        false
    | None ->
      printfn "No piece on this field"
      false

  member this.getCharAsNumber (place : char) : int =
    match place with
    | 'A' -> 0
    | 'B' -> 1
    | 'C' -> 2
    | 'D' -> 3
    | 'E' -> 4
    | 'F' -> 5
    | 'G' -> 6
    | 'H' -> 7
    | _ -> -1

  member this.run()=

    let printPiece (board : Board) (p : chessPiece) : unit =
      printfn "%A: %A %A" p p.position (p.availableMoves board)
    //Creats and set up the board and game.
    let mutable playerNumber = 0 //Internaly the players are zero indexed. 
    let mutable keepPlaying = true
    let board = Chess.Board () 
    let pieces = [| //We are not really told what start-setup we should have. So i just made one. 
      king (White) :> chessPiece;
      rook (Black) :> chessPiece;
      rook (White) :> chessPiece;
      king (Black) :> chessPiece |]
    board.[2,4] <- Some pieces.[0]
    board.[0,7] <- Some pieces.[1]
    board.[1,7] <- Some pieces.[2]
    board.[2,6] <- Some pieces.[3]

    
   (*member this.HumanVhuman The while part here is only for human vs human *)
    //Starting the game    
    while keepPlaying do
        printfn "%A" board
        Array.iter (printPiece board) pieces
        printfn "Player %i´s turn. Enter a move from a location to a location:" (playerNumber + 1)
        let playerInput = string (System.Console.ReadLine())
        let exMove = (playerInput.ToLower().Split([|' '|]))  
        if playerInput ="quit" then 
            keepPlaying <- false
            printfn "Game over"
        elif (playerInput.Length <>5) || (exMove.Length <>2) then //<- Removes input of wrong format. 
            printfn "Please follow the correct input format. Example: A1 B2" 
        else
           
            let firstChar = exMove.[0].[0]
            let secondChar = exMove.[1].[0]


            match System.Int32.TryParse(exMove.[0].[1].ToString()) with
            | (true,int1) -> 
              match System.Int32.TryParse(exMove.[1].[1].ToString()) with
              | (true,int2) ->
                let firstMove1 = this.getCharAsNumber (System.Char.ToUpper firstChar)
                if firstMove1 <> -1 then
                  let firstMove2 = int1 - 1
                  let secondMove1 = this.getCharAsNumber (System.Char.ToUpper secondChar)
                  if secondMove1 <> -1 then
                    let secondMove2 = int2 - 1
                    printfn "startMove: %i, %i" firstMove1 firstMove2
                    if (this.checkValidMove (secondMove1, secondMove2) (board.[firstMove1, firstMove2]) (board) playerNumber) then
                      playerNumber <- ((playerNumber+1)%2)
                      board.move (firstMove1, firstMove2) (secondMove1, secondMove2)
                    else
                      printfn "The move was not available"
                  else
                    printfn "bad char 2"
                else
                  printfn "bad char 1"
              | _ ->
                printfn "Please write it in as a char and int, ex. A1"
            | _ ->
              printfn "Please write it in as a char and int, ex. A1"

            // board.move (x1,y1) (x2,y2)
