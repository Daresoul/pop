module Game
open Chess
open Pieces

type game()=
  member this.run()=

    let printPiece (board : Board) (p : chessPiece) : unit =
      printfn "%A: %A %A" p p.position (p.availableMoves board)
    //Creats and set up the board and game.
    let mutable playerNumber = 0 //Internaly the players are zero indexed. 
    let mutable keepPlaying = true
    let board = Chess.Board () 
    let pieces = [|
      king (White) :> chessPiece;
      rook (White) :> chessPiece;
      rook (White) :> chessPiece;
      king (Black) :> chessPiece 
      rook (Black) :> chessPiece;
      rook (Black) :> chessPiece;|]
    board.[0,4] <- Some pieces.[0]
    board.[0,7] <- Some pieces.[1]
    board.[0,0] <- Some pieces.[2]
    board.[7,4] <- Some pieces.[3]
    board.[7,7] <- Some pieces.[4]
    board.[7,0] <- Some pieces.[5]
    
     
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
            playerNumber <- ((playerNumber+1)%2)
           
            printfn "%c" (exMove.[0].[0])
            printfn "%c" (exMove.[0].[1])
            printfn "%c" (exMove.[1].[0])
            printfn "%c" (exMove.[1].[1])
            //I think the input format shall be changed from 0,1 0,0 etc to the A2 to A1 format here?



(*
    board.move (1,1) (4,1) // Moves a piece from (1,1) to (3,1)
    printfn "%A" board
    Array.iter (printPiece board) pieces
*)