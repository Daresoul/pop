
let field = [3;3;3;3;3;3;0;3;3;3;3;3;3;0]

let clearPit (l: int list) (i: int) =
    l.[0..i-1] @ [0] @ l.[i+1..13]

let rec addBeans (l: int list) (i: int) (b: int) =
    if b = 1 then
        l.[0..i-1] @ [l.[i]+1] @ l.[i+1..13]
    else
        addBeans (l.[0..i-1] @ [l.[i]+1] @ l.[i+1..13]) (i+1) (b-1)

let getItem (l: int list) i =
    l.[i]

printf "\nPlayer 1, enter an integer between 1 to 6\n"
let choice = int (System.Console.ReadLine()) - 1

printfn "\n%A" field
printfn "\n%A" (clearPit field choice)
printfn "\n%A" (addBeans (clearPit field choice) (choice+1) (getItem field choice))

;;