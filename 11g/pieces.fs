module Pieces
open Chess

/// A king is a chessPiece which moves 1 square in any direction
type king(col : Color) =
  inherit chessPiece(col)
  override this.nameOfType = "king"
  // king has runs of 1 in 8 directions: (N, NE, E, SE, S, SW, W, NW)
  override this.candiateRelativeMoves =
      [[(-1,0)];[(-1,1)];[(0,1)];[(1,1)];
      [(1,0)];[(1,-1)];[(0,-1)];[(-1,-1)]]
  // an overshadowing to ensuring that the king cannot be placed in check. 
  override this.availableMoves (board : Board) : (Position list * chessPiece list) =
    let opponentPosition = board.getPieces(col)
    let potentialMoves = board.getVacantNNeighbours this 
    let mutable allowedMoves = []
    let mutable i = 0
    let mutable illigalPositions = []
    for _ in opponentPosition do
      if (opponentPosition.[i].nameOfType <> "king") then//<-- if this is checked with a king a everlasting resurive call between 1< kings will occure. 
        illigalPositions <-illigalPositions @ (fst(opponentPosition.[i].availableMoves board))
      else //<- recalcualting abselute moves for king basend upon relative moves and position of king
        let mutable n = 0
        for _ in this.candiateRelativeMoves do
          illigalPositions <- illigalPositions @ [((fst(opponentPosition.[i].position.Value)) + (fst((this.candiateRelativeMoves.[n].[0])))), ((snd(opponentPosition.[i].position.Value)) + (snd((this.candiateRelativeMoves.[n].[0]))))]
          n <- n+1
        n<-0  
      i <- i+1
    i <- 0 
   
    let mutable j = 0
    let mutable notAllowed = 0
    for _ in (fst potentialMoves) do
      for _ in illigalPositions do
        if ((fst potentialMoves).[i]) = illigalPositions.[j] then
          notAllowed <-1
        j <- j+1
      if notAllowed = 0 then
        allowedMoves <- allowedMoves @ [((fst potentialMoves).[i])]
      notAllowed <- 0 
      j <- 0
      i <- i + 1
    let opponents = snd potentialMoves
    
    (allowedMoves , (snd potentialMoves))



/// A rook is a chessPiece which moves horisontally and vertically
type rook(col : Color) =
  inherit chessPiece(col)
  // rook can move horisontally and vertically
  // Make a list of relative coordinate lists. We consider the
  // current position and try all combinations of relative moves
  // (1,0); (2,0) ... (7,0); (-1,0); (-2,0); ...; (0,-7).
  // Some will be out of board, but will be assumed removed as
  // illegal moves.
  // A list of functions for relative moves
  let indToRel = [
    fun elm -> (elm,0); // South by elm
    fun elm -> (-elm,0); // North by elm
    fun elm -> (0,elm); // West by elm
    fun elm -> (0,-elm) // East by elm
    ]
  // For each function in indToRel, we calculate List.map f [1..7].
  // swap converts (List.map fct indices) to (List.map indices fct).
  let swap f a b = f b a
  override this.candiateRelativeMoves =
    List.map (swap List.map [1..7]) indToRel (*//§\label{chessPieceSwapApp}§*)
  override this.nameOfType = "rook"
