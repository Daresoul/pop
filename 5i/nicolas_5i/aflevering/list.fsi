module lists

///<summary>
/// This will checl if all lists inside a list have the same length.
///</summary>
///<param name="thislist">A list with 1 or multiple lists inside it</param>
///<returns>Returns true if all inner lists is the same length</returns>
val isTable : 'a list list -> bool

///<summary>
/// This will get the first column of all lists inside of a list.
///</summary>
///<param name="thislist">A list with 1 or multiple lists inside it</param>
///<returns>Returns a list with the first element of every innerlist</returns>
val firstColumn : 'a list list -> 'a list

///<summary>
/// This will take a list with 1 or multiple lists inside, and remove the first element from every inner list
///</summary>
///<param name="thislist">A list with 1 or multiple lists inside it</param>
///<returns>Returns a list with lists inside where the 1 element of the list is removed</returns>
val dropFirstColumn : 'a list list -> 'a list list

///<summary>
/// This will reformat the lists from a list with 1 or more lists in, to be i columns it is coming out instead og rows
///</summary>
///<param name="thislist">A list with 1 or multiple lists inside it</param>
///<returns>Returns a transposed list where the original inner lists is in columns instead of rows</returns>
val transpose : 'a list list -> 'a list list

///<summary>
/// This will create a single list of all numbers from a list of lists.
///</summary>
///<param name="lst">A list with 1 or multiple lists inside it</param>
///<returns>Returns a single list og all numbers in input list of lists</returns>
val concat : 'a list list -> 'a list

///<summary>
/// Will find a median of all the numbers in a list, of floats.
///</summary>
///<param name="lst">A list of floats</param>
///<returns>Returns the median of all the floats in the list</returns>
val gennemsnit : float list -> float option