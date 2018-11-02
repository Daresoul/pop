///<summary> Takes a list of int and returns a float calculated as a continued fraction (i.e. q0 + 1/(q1+1/(q2...etc))</summary>
///<param name="lst">The list with the continued fraction values</param>
///<returns>Float value of the continued fraction</returns>
let rec cfrac2float (lst: int list) : float =
    if lst.IsEmpty then 0.0
    elif lst.Length<2 then 
        (float lst.Head)
    else 
        let r1 = (float lst.Head)
        let r2 = (float 1/(cfrac2float(lst.Tail)))
        r1 + r2 




[<EntryPoint>]
let main args =
    let lst = [3;7;15;1;292]
    let lst2 = [3;4;12;4]
    let lst3 = []

    printfn "BlackBox Test\n\n"
    printfn "The list %A Makes the float value: %f" lst (cfrac2float(lst))
    printfn "The list %A Makes the float value: %f" lst2 (cfrac2float(lst2))
    printfn "The list %A Makes the float value: %f" lst3 (cfrac2float(lst3))

    printfn "\n\n\nWhitebox Test\n\n"
    printfn "The list %A Makes the float value: %.9f expected value: %.9f" lst (cfrac2float lst) 3.141592653
    printfn "The list %A Makes the float value: %.9f expected value: %.9f" lst2 (cfrac2float lst2) 3.245
    printfn "The list %A Makes the float value: %.9f expected value: %.9f" lst3 (cfrac2float lst3) 0.0
    0   