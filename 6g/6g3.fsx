let rec cfrac2frac(lst: int list)(i: int): int*int=
    if i = -1 then (1,0)
    elif i = -2 then (0,1)
    else
    let tæller = lst.[i] * fst( cfrac2frac (lst) ((i-1))) + fst( cfrac2frac (lst) ((i-2)))
    let nævner = lst.[i] * snd( cfrac2frac (lst) ((i-1))) + snd( cfrac2frac (lst) ((i-2)))
    (tæller,nævner)

[<EntryPoint>]
let main args =
    let lst = [3;7;15;1;292;1] 
    let lst2 = [3;4;12;4]
    let lst3 = []

    printfn "The list [3;7;15;1;292;1] makes the continued fraction: %i %i" <|| (cfrac2frac (lst) (3))
    //printfn "The list [3;4;12;4] makes the continued fraction: %i %i" <|| (cfrac2frac (lst2) (3)) 
    //printfn "The list [] makes the continued fraction: %i %i" <|| (cfrac2frac (lst3) (1))
    0