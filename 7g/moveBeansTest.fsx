
// This list represents the board.
let field = [3;3;3;3;3;3;0;3;3;3;3;3;3;0]

// REMEMBER!
// There are 3 important variables used for the various functions below.
//      "l" (not one, but ell) is the list we working with.
//      "i" is the index we are situated at.
//      "b" is the number of beans we are holding.

// This empties the pit that the player chooses.
let clearPit (l: int list) (i: int) =
    l.[0..i-1] @ [0] @ l.[i+1..13]

// This places a bean everytime we move from one index to another.
let rec addBeans (l: int list) (i: int) (b: int) =

    // "æ" is all unchanged element before "ø".
    let æ = l.[0..i-1]

    // "ø" is the element we place a bean.
    let ø = [l.[i]+1]

    // "å" is all unchanged element after "ø".
    let å = l.[i+1..13]

    // "uL" is the updated list.
    let uL = æ @ ø @ å

    // This allows us to keep placing beans.
    if i >= 13 then
        addBeans uL 0 (b-1)
    
    // This is the end condition for "addBeans".
    elif b = 1 then
        uL
    
    // If the condition is not met "addBeans"'s life purpose continues.
    else
        // We write "i+1", because we want to move to the next index.
        // We write "b-1", because we placed a bean
        addBeans uL (i+1) (b-1)

// This takes the beans from the chosen pit.
let getItem (l: int list) i =
    l.[i]

printfn "\n\n\n%A" field
printf "\nEnter an integer between 0 to 5 or 7 to 12: "
let choice = int (System.Console.ReadLine())

let rec ask choice =
        if choice>=0 && choice<=5 || choice>=7 && choice<=12 then
            printfn "\n%A" (addBeans (clearPit field choice) (choice+1) (getItem field choice))
        else
            printfn "\n\n\n%A" field
            printf "\nEnter an integer between 0 to 5 or 7 to 12: "
            ask (int (System.Console.ReadLine()))

ask choice
;;