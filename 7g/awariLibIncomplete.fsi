module Awari
///  Each player has a set of regular pits and one home pit. A pit holds zero or more beans
type pit = int
/// A board consists of pits.
type board = int list
/// A game is played between two players
type player = Player1 | Player2

/// <summary>
/// 
/// </summary>
/// <param name=""></param>
/// <returns></returns>
val clearPit : l : int list -> p : pit -> int list

/// <summary>
///  this will give you the opposite index on the map.
/// </summary>
/// <param name="p">the index you wanna find the opposite of</param>
/// <returns>this returns the opposite index</returns>
val matchOppsitePit : p : pit -> pit

/// <summary>
/// this will return a new board, when you hit an empty pit, this new board has the opposite pit emtied and layed into your home
/// </summary>
/// <param name="b">board int list</param>
/// <param name="p">the pit index</param>
/// <param name="player">player value</param>
/// <returns>returns a new board where the beans has moved</returns>
val emptyPit : b : board -> p : pit -> board * pit

/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="l">The present statu of the board</param>
/// <param name="p">the pit value to use from</param>
/// <param name="b">the amount to still distrubute</param>
/// <param name="player">the player value</param>
/// <returns>A new board after the beans of pit i has been distributed, and the last pit index</returns>
val distribute : l:board -> p : pit -> b : int -> player : player -> board * pit

/// <summary>
/// Print the board
/// </summary>
/// <param name="b"> A board to be printed </param>
/// <returns>() - it just prints</returns>
/// , e.g.,
/// <remarks>
/// Output is for example,
/// <code>
///      3  3  3  3  3  3
///   0                    0
///      3  3  3  3  3  3
/// </code>
/// where player 1 is bottom row and rightmost home
/// </remarks>
val printBoard : b:board -> unit

/// <summary>
/// this will print a message of whom won the game
/// </summary>
/// <param name="b">the current board</param>
/// <returns>returns a message to display for the users</returns>
val findWinner : b : board -> string

/// <summary>
/// Check whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
val isGameOver : b:board -> bool

/// <summary>
/// Check whether a pit is the player's home
/// </summary>
/// <param name="b">A board to check</param>
/// <param name="p">The player, whos home to check</param>
/// <param name="i">A regular or home pit of a player</param>
/// <returns>True if i is a homespot of player p</returns>
val isHome : b:board -> p:player -> i:pit -> bool


/// <summary>
/// checks if the specific pit spot selected by a player is empty.If so returns -1, else returns pitvalue given. A bit redundant in its build but works with the specific code parameters. 
/// </summary>
/// <param b:board >A board to check</param>
/// <param i:int> The index of the board list that shall be checked</param>
/// <param p:pit> The pit coorsponding to the index of the board being checked</param>
/// <returns>If the pit is not empty it just returns the pit number. If pit empty it returns -1</returns>
val pitEmpty : b:board -> i : int -> x : pit -> pit

////// <summary>
/// /// Takes an int = [1-6] and returns the "reversed" int = [6-1] 
/// </summary>
/// <param name= i> the index that have to be reversed.</param>
/// <returns>The reversed int</returns>
val reverseNumbers : i : int -> int

/// <summary>
/// Get the pit of next move from the user
/// </summary>
/// <param name="b">The board the player is choosing from</param>
/// <param name="p">The player, whose turn it is to choose</param>
/// <param name="q">The string to ask the player</param>
/// <returns>The pit the player has chosen</returns>
val getMove : b:board -> p:player -> q:string -> pit

/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>
val turn : b:board -> p:player -> board

/// <summary>
/// Play game until one side is empty
/// </summary>
/// <param name="b">The initial board</param>
/// <param name="p">The player who starts</param>
/// <returns>A new board after one player has won</returns>
val play : b:board -> p:player -> board
