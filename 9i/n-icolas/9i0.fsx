let safeIndexIf (arr : 'a array) (i : int) : 'a =
    if (i > (arr.Length - 1)) then
        -1
    else
        arr.[i]

let safeIndexTry (arr : 'a array) (i : int) : 'a =
    try
        if (i > (arr.Length - 1)) then
            failwith ("index out of range!")
        else
            arr.[i]
    with
    | Failure(msg) -> printfn "%s" msg; -1


let safeIndexOption (arr : 'a array) (i : int) : 'a option=
    if( i > (arr.Length - 1)) then
        None
    else
        Some ( arr.[i] )

let arr1 = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]

// med index 1
// burde returne 2


(********************************************************************************************
****************************************FIRST TEST*******************************************
********************************************************************************************)
let index1 = 1
let exp1 = 2
let resIf1 = safeIndexIf (arr1) (index1)
let resTry1 = safeIndexTry (arr1) (index1)
let resOption1 = safeIndexOption (arr1) (index1)

printfn "resIf result gave %i was this as expected? %b" resIf1 (resIf1 = exp1)
printfn "resTry result gave %i was this as expected? %b" resTry1 (resTry1 = exp1)
printfn "resOption result gave %A was this as expected? %b" resOption1 (resOption1 = Some (exp1))
printfn "\n\n\n"

(********************************************************************************************
***************************************SECOND TEST*******************************************
********************************************************************************************)

let index2 = 9
let exp2 = 10
let resIf2 = safeIndexIf (arr1) (index2)
let resTry2 = safeIndexTry (arr1) (index2)
let resOption2 = safeIndexOption (arr1) (index2)

printfn "resIf result gave %i was this as expected? %b" resIf2 (resIf2 = exp2)
printfn "resTry result gave %i was this as expected? %b" resTry2 (resTry2 = exp2)
printfn "resOption result gave %A was this as expected? %b" resOption2 (resOption2 = Some (exp2))
printfn "\n\n\n"

(********************************************************************************************
***************************************THIRD TEST********************************************
********************************************************************************************)

let index3 = 10
let exp3 = -1
let resIf3 = safeIndexIf (arr1) (index3)
let resTry3 = safeIndexTry (arr1) (index3)
let resOption3 = safeIndexOption (arr1) (index3)

printfn "resIf result gave %i was this as expected? %b" resIf3 (resIf3 = exp3)
printfn "resTry result gave %i was this as expected? %b" resTry3 (resTry3 = exp3)
printfn "resOption result gave %A was this as expected? %b" resOption3 (resOption3 = None)
