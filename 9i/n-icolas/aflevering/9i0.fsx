/// <summary>This returns the i index of the array</summary>
/// <param name="arr">The array you wanna find the index of</param>
///<param name="i">The index you wanna find</param>
///<returns>returns the index of the array unless it is larger than the max index and it returns the 0 indexed element</returns>
let safeIndexIf (arr : 'a array) (i : int) : 'a =
    if (i > (arr.Length - 1)) then
        arr.[0]
    else
        arr.[i]
/// <summary>This returns the i index of the array</summary>
/// <param name="arr">The array you wanna find the index of</param>
///<param name="i">The index you wanna find</param>
///<returns>returns the index of the array unless it is larger than the max index and it returns the 0 indexed element</returns>
///<exception>Thrown when the index is larger than the array</exception>
let safeIndexTry (arr : 'a array) (i : int) : 'a =
    try
        if (i > (arr.Length - 1)) then
            failwith ("index out of range!")
        else
            arr.[i]
    with
    | Failure(msg) -> printfn "%s" msg; arr.[0]

/// <summary>This returns the i index of the array</summary>
/// <param name="arr">The array you wanna find the index of</param>
///<param name="i">The index you wanna find</param>
///<returns>returns the index of the array as an option unless it is larger than the max index then it will throw None</returns>
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


(*
De 3 forskellige metoder virker forskelligt

safeIndexIf
Virker med if statements og kan virke godt til tidspunkter hvor programmet skal kunne kører videre selv hvis der sker en fejl i systemet, og kan derfor returner andre værdier for senere at fortælle at den skal gøre det uden den her værdi.

safeIndexTry
bruger try with som virker lidt ligesom exceptions, og er god hvis det der skal findes og returneres er kritisk for det, det skal bruges til. Sådan at systemet fejler. men stadig skriver en besked ud til dig der hjælper dig med at finde fejlen.

safeIndexOption
Works basicly as the If statement would but can return None as a failure instead of the first item in the array, or a -1 or some other value
    
    
*)