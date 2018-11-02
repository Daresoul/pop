
let getItem (l: int list) p =
    l.[p]

let clearPit (l: int list) p =
    let æ = l.[0..p-1]
    let ø = [0]
    let å = l.[p+1..13]
    æ @ ø @ å

let rec addBean (l: int list) p b =
    let æ = l.[0..p-1]
    let ø = [l.[p]+1]
    let å = l.[p+1..13]
    let uL = æ @ ø @ å

    if p >= 13 then
        addBean uL 0 (b-1)
    elif b <= 1 then
        uL
    else
        addBean uL (p+1) (b-1)

let w = 5

let board (l: int list) =
    printf "\n\n%*s" w ""

    let æ = List.rev l.[0..5]
    for e in æ do
        printf "%-*i" w e
    printf "\n"

    printf "%-*i%*s%*s%*s%*s%*s%*s%-*i\n%*s" w l.[6] w "" w "" w "" w "" w "" w "" w l.[13] w ""

    let å = l.[7..12]
    for e in å do
        printf "%-*i" w e

    printf "\nEnter an integer between 0 to 5 or 7 to 12: "

let rec ask (l: int list) =
    board l
    let c = int (System.Console.ReadLine())
    let uL = addBean (clearPit l c) (c+1) (getItem l c)
    
    if 0 <= c  && c <= 5 || 7 <= c && c <= 13 then
        ask uL
    else
        printfn "You entered wrong, the program ended."

let field = [3;3;3;3;3;3;0;3;3;3;3;3;3;0]

ask field
;;