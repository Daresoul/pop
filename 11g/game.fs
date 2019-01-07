module Game
open Chess
open Pieces
open System.Windows.Forms

type game()=


  member this.checkValidMove (pos : int * int) (piece : chessPiece option) (board : Board) = 
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
           
            // check team of chosen piece
            // Do this by checking if white = player1 (lower Case)
            // and black = player2 (Capital)

            //printfn "%c" (exMove.[0].[0])   //We need a check to ensure this is a char
            //printfn "%c" (exMove.[0].[1])   //We need a check to ensure this is a int
            //printfn "%c" (exMove.[1].[0])   //We need a check to ensure this is a char
            //printfn "%c" (exMove.[1].[1])   //We need a check to ensure this is a int
            //I think the input format shall be changed from 0,1 0,0 etc to the A2 to A1 format at this point?
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
                    if (this.checkValidMove (secondMove1, secondMove2) (board.[firstMove1, firstMove2]) (board)) then
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