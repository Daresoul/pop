//<summary> Takes a list of int and returns a float calculated as a continued fraction (i.e. q0 + 1/(q1+1/(q2...etc))
//<remarks> It returns 0.0 if the list is empty.
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

    printfn "The list %A makes the continued fraction: %f" lst (cfrac2float(lst))
    printfn "The list %A makes the continued fraction: %f" lst2 (cfrac2float(lst2))
    printfn "The list %A makes the continued fraction: %f" lst3 (cfrac2float(lst3))
    0   