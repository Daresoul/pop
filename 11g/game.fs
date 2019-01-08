module Game
open Chess
open Pieces
open player
open System.Windows.Forms

type game()=

  member this.validateAvailableMove (pos : int * int) (piece : chessPiece option) (board : Board) =
      // Just for security we are going to check if its a Some again
      match piece with
      | Some (p) -> 
        let availeableMoves = p.availableMoves board
        let mutable isItAvailAble = false

        for m in fst availeableMoves do
          //printfn "check: %A = %A" m pos
          if (m = pos) then
            isItAvailAble <- true

        for p in snd availeableMoves do
          if (p.position =  Some pos) then
            pritfn "yes"
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

  member this.run()=

    let player1 = Human()
    let player2 = Human()

    let printPiece (board : Board) (p : chessPiece) : unit =
      printfn "%A: %A %A" p p.position (p.availableMoves board)
    //Creats and set up the board and game.
    let mutable playerNumber = 0 //Internaly the players are zero indexed. 
    let mutable keepPlaying = true
    let board = Chess.Board () 
    let pieces = [| //We are not really told what start-setup we should have. So i just made one. 
      king (White) :> chessPiece;
      rook (White) :> chessPiece;
      king (Black) :> chessPiece;
      rook (Black) :> chessPiece; |]
    board.[0,4] <- Some pieces.[0]
    board.[0,7] <- Some pieces.[1]
    board.[7,7] <- Some pieces.[2]
    board.[4,7] <- Some pieces.[3]

    //Starting the game    
    while keepPlaying do

        printfn "%A" board
        Array.iter (printPiece board) pieces


        printfn "Player %i´s turn. Enter a move from a location to a location:" (playerNumber + 1)
        if (playerNumber = 0) then
          let moves = player1.nextMove

          match moves with
          | [] ->
            printfn "Something about your formatting is wrong"
          | [(-1, -1)] ->
            keepPlaying <- false
          | [(x1,y1); (x2,y2)] ->
            if (this.checkValidMove (x2, y2) (board.[x1, y1]) (board) playerNumber) then
              playerNumber <- ((playerNumber+1)%2)
              board.move (x1, y1) (x2, y2)
          | _ ->
            printfn "Something went wrong about your formating or inputs!"
        else
          let moves = player2.nextMove
          
          match moves with
          | [] ->
            printfn "Something about your formatting is wrong"
          | [(-1, -1)] ->
            keepPlaying <- false
          | [(x1,y1); (x2,y2)] ->
            if (this.checkValidMove (x2, y2) (board.[x1, y1]) (board) playerNumber) then
              playerNumber <- ((playerNumber+1)%2)
              board.move (x1, y1) (x2, y2)
          | _ ->
            printfn "Something went wrong about your formating or inputs!"

     
