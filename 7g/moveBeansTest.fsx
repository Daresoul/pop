
let field = [3;3;3;3;3;3;0;3;3;3;3;3;3;0]

let clearPit (l: int list) (i: int) =
    l.[0..i-1] @ [0] @ l.[i+1..13]

let rec addBeans (l: int list) (i: int) (b: int) =
    if i >= 13 then
        addBeans (l.[0..i-1] @ [l.[i]+1] @ l.[i+1..13]) 0 (b-1)
    elif b = 1 then
        l.[0..i-1] @ [l.[i]+1] @ l.[i+1..13]
    else
        addBeans (l.[0..i-1] @ [l.[i]+1] @ l.[i+1..13]) (i+1) (b-1)

let getItem (l: int list) i =
    l.[i]

let mutable choice = -1

while choice<0 || choice=6 || choice>13 do
    printfn "\n%A" field
    printf "\nEnter an integer between 0 to 5 or 7 to 12: "
    choice <- int (System.Console.ReadLine())

printfn "\n%A" (addBeans (clearPit field choice) (choice+1) (getItem field choice))
;;