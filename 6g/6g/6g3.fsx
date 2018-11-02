///<summary>Creates a fraction of a continued fraction</summary>
/// <remarks>Will return a tuple of (0,0) if index is larger than list length and if list has no elements, this means that you cant use it for division to get a number</remarks>
///<param name="lst">The list with the continued fraction</param>
///<param name="i">The number of elements from the list to be used (plus the first)</param>
///<returns>Returns a tuple with (numerator, denominator) that explains the continued fraction</returns>
let rec cfrac2frac(lst: int list)(i: int): int*int=
    if i > (lst.Length - 1) then (0,0)
    elif lst.Length < 1 then (0,0)
    elif i = -1 then (1,0)
    elif i = -2 then (0,1)
    else
    let tæller = lst.[i] * fst( cfrac2frac (lst) ((i-1))) + fst( cfrac2frac (lst) ((i-2)))
    let nævner = lst.[i] * snd( cfrac2frac (lst) ((i-1))) + snd( cfrac2frac (lst) ((i-2)))
    (tæller,nævner)

[<EntryPoint>]
let main args =
    let lst = [3;7;15;1;292] 
    let lst2 = [3;4;12;4]
    let lst3 = []
    
    printfn "BlackBoxTest \n\n\n"
    printfn "The list %A makes the continued fraction: %i %i" lst <|| (cfrac2frac (lst) (3))
    printfn "The list %A makes the continued fraction: %i %i" lst <|| (cfrac2frac (lst) (5))
    printfn "The list %A makes the continued fraction: %i %i" lst2 <|| (cfrac2frac (lst2) (3)) 
    printfn "The list %A makes the continued fraction: %i %i" lst3 <|| (cfrac2frac (lst3) (0))
    printfn "The list %A makes the continued fraction: %i %i" lst3 <|| (cfrac2frac (lst3) (1))

    printfn "\n\n\nWhiteboxBoxTest \n\n\n"
    let tuple1 = (cfrac2frac (lst) (3))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple1) (snd tuple1) (float ((float (fst tuple1)) / (float (snd tuple1)))) 3.141592920

    let tuple2 = (cfrac2frac (lst) (5))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple2) (snd tuple2) (float ((float (fst tuple2)) / (float (snd tuple2)))) 0.0

    let tuple3 = (cfrac2frac (lst2) (0))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple3) (snd tuple3) (float ((float (fst tuple3)) / (float (snd tuple3)))) 0.0

    let tuple4 = (cfrac2frac (lst2) (3))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple4) (snd tuple4) (float ((float (fst tuple4)) / (float (snd tuple4)))) 3.245

    let tuple5 = (cfrac2frac (lst3) (3))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple5) (snd tuple5) (float ((float (fst tuple5)) / (float (snd tuple5)))) 0.0

    let tuple6 = (cfrac2frac (lst3) (3))
    printfn "The list %A makes the continued fraction: %i %i and divided gives %.9f expected dividing float: %.9f" lst (fst tuple6) (snd tuple6) (float ((float (fst tuple6)) / (float (snd tuple6)))) 0.0

    // Some of these will give NaN because we try to divide 0 by 0 whitch is illegal in math, and therefore cannot be divided.
    
    0