/// A simulator for animals in a closed environment. Presently, two animals are implemented: moose and wolves as prey and preditor.
module animals
/// A symbol to print an animal on a board
type symbol = char
/// A position on a board
type position = int * int
/// Base class for all animals. An animal has a position, age and a time to reproduce.
type animal =
  class
    /// <summary>Create a new animal represented with symbol symb and which reproduces every repLen ticks.</summary>
    /// <param name="symb">A symbol (character) used to represent the animal type when the board is printed.</param>
    /// <param name="repLen">The time in ticks until the animal attempts to produce an offspring.</param>
    new : symb:symbol * repLen:int -> animal
    /// The symbol as string for printing.
    override ToString : unit -> string
    /// The symbol representing this animal.
    member symbol : symbol
    /// Get the position of this animal. If position is None, then the animal is not on the board.
    member position : position option
    /// Set the position of this animal.
    member position : position option with set
    /// Get the reproduction counter in ticks. Starts as repLen and is counted down with every tick. The animals age is repLen - reproduction.
    member reproduction : int
    /// Set the reproduction counter to repLen.
    member resetReproduction : unit -> unit
    /// Reduce the reproduction counter by a tick.
    member updateReproduction : unit -> unit
  end
/// A moose is an animal with methods for updating its age and producing offspring.
type moose =
  class
    inherit animal
    /// <summary>Create a moose with symbol 'm'.</summary>
    /// <param name="repLen">The number of ticks until a moose attempts to produce an offspring.</param>
    new : repLen:int -> moose
    /// <summary>Checks wether a moose is able to give birth</summary>
    /// <return> returns a moose option if able to give birth otherwise it returns None </return>
    member tick : unit -> moose option
  end
/// A wolf is an animal with hunger and methods for updating its age and hunger and for reproducing offspring. If the wolf has not eaten in a specified number of ticks, then it is taken off the board.
type wolf =
  class
    inherit animal
    /// <summary>Create a wolf with symbol 'w'.</summary>
    /// <param name="repLen">The number of ticks until a wolf attempts to produce an offspring.</param>
    /// <param name="hungLen">The number of ticks since it last ate until a wolf dies.</param>
    new : repLen:int * hungLen:int -> wolf
    /// Reduce the reproduction counter by a tick. If repLen is 0 then a new wolf is returned and the counter is reset to repLen.
    member hunger : int
    /// Set the hunger counter to hungLen.
    member resetHunger : unit -> unit
    /// Reduce the hunger counter by a tick. If hunger reaches 0, then the wolf is removed from the board.
    member updateHunger : unit -> unit
    /// <summary>Checks wether a wolf is able to give birth</summary>
    /// <return> returns a wolf option if able to give birth otherwise it returns None </return>
    member tick : unit -> wolf option
  end
/// A square board with length width. The board is implicitly represented by its width and the coordinates in the animals.
type board =
  {
    /// The width of the board. The board size is width x width.
    width: int;
    /// The list of moose. If a moose has position None, then it is not on the board.
    mutable moose: moose list;
    /// The list of wolves. If a wolf has position None, then it is not on the board.
    mutable wolves: wolf list;}
/// An environment. Animals that have no position are considered dead.
type environment =
  class
    /// <summary>Create a new environment.</summary>
    /// <param name="boardWidth">The width of the board.</param>
    /// <param name="NMooses">The initial number of moose.</param>
    /// <param name="NWolves">The initial number of wolves.</param>
    /// <param name="mooseRepLen">The number of ticks until a moose attempts to produce an offspring.</param>
    /// <param name="wolvesRepLen">The number of ticks until a wolf attempts to produce an offspring.</param>
    /// <param name="wolvesHungLen">The number of ticks since it last ate until a wolf dies.</param>
    /// <param name="verbose">If the verbose flag is true, then messages are printed on screen at key events.</param>
    new : boardWidth:int * NMooses:int * mooseRepLen:int * NWolves:int *
          wolvesRepLen:int * wolvesHungLen:int * verbose:bool -> environment
    /// A board as a matrix of symbols for moose and wolves.
    override ToString : unit -> string
    /// The board.
    member board : board
    /// The number of animals on the board.
    member count : int
    /// The positions on the board.
    member size : int

    /// <summary>gives a vector for an animal to move in</summary>
    /// <return> a random vector direction</return>
    member genMoveVector : unit -> int * int

    /// <summary>This will create a new position for an animal</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    /// <returns>The new position option for the animal or None if already None</returns>
    member moveAnimal : (int * int) option -> (int * int option)

    /// <summary>Counts all mooses</summary>
    /// <returns>An integer of how many not dead mooses left</returns>
    member countMoose : int

    /// <summary>Counts all Wolfs</summary>
    /// <returns>An integer of how many not dead Wolfs left</returns>
    member countWolfs : int

    /// <summary>Checks if any animal is at this position</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    /// <returns>false if anything was there and true if nothing is there</returns>
    member checkForAnimalsAtPosition : position -> bool

    /// <summary>Checks wether it is a legal move to make for the animal</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    /// <returns>true if the move is valid and false if it is not a valid move</returns>
    member checkValidMove : (int * int) option -> bool

    /// <summary>Checks if any animal is at this position</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    /// <returns>Sends back a tuple of string and bool where string represents the type of animal and if it was there</returns>
    member findMooseAtPosition : position option -> bool

    /// <summary>Checks positions around to see if ant valid moves</summary>
    /// <param name="pos">the position of the animal</param>
    /// <returns>Sends back all possible positions</returns>
    member checkFieldsAround : (int * int) option -> bool

    /// <summary>Gets all the coordinates of the board around a given animal</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    /// <returns>a generic list with all the possible ways to move</returns>
    member CheckEating : (int * int) option -> List<position>

    /// <summary>Kills a specific moose from its position</summary>
    /// <param name="pos">The position the animal is at right now, as an position option</param>
    member KillMooseFromPosition : position option -> unit

    /// <summary>The sequence of the moose choosing what to do, either move or reproduce</summary>
    /// <param name="i">the index of the moose that wants to move</param>
    member mooseMove : int -> unit

    /// <summary>The sequence of the wolf choosing what to do, either move, reproduce or eat</summary>
    /// <param name="i">the index of the wolf that wants to move</param>
    member mooseMove : int -> unit

    /// <summary>Removes all dead animals in both moose and wolf list</summary>
    member removeDeadAnimals : unit

    /// <summary> Goes though a scrambled list of all animals and calls the appropriate function to do their move </summary>
    member tick : unit -> unit

    /// <summary> Scrambles both list into a single with a string to identify the type of animal and an index in their list </summary>
    /// <return> returns a list of tuples with a string of animal type and an index in their respective lists </return>
    member makeQueue : (string * int) list

    /// <summary> Writes out a board with current tick and amount of animals in it, to a string </summary>
    /// <return> string with board and info is returned </return>
    member WriteOutInfo : int -> string
    
  end

  type game =
  class
    /// <summary>Setup and rund the moose-wolf game</summary>
    /// <param name="T"> iterations of the game. I.e how many rounds</param>
    /// <param name="filDest">file destination of the return file</param>
    /// <param name="n">size of the square board </param>
    /// <param name="e"> number of mooses at start </param>
    /// <param name="fe">moose reproduction time </param>
    /// <param name="u"> number of wolfs at start </param>
    /// <param name="fu">wolf reproduction time</param>
    /// <param name="s"> hunger time of wolfs</param>
    /// <returns>Dont returns anything, but creats a .txt file</returns>
    new: T : int * fileDest : string * n : int * e : int * fe : int * u : int * fu : int * s : int -> unit

    member startGame : game
    /// Starts the game 
  end

