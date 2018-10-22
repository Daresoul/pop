let cfrac2float (lst: int list) (i : int) : float =
    let newint = i+1
    let rec hahaha (lst : int list) (r : int) =
        if lst.IsEmpty then 0.0
        elif r = newint then 1.0
        elif lst.Length<2 then 
            //printfn "List is lower than 2"
            (float lst.Head)
        else
            //printfn "%i %f" r (float lst.[r])
            let r1 = (float lst.[r])
            let r2 = ( 1.0 / (hahaha (lst) (r+1) ) )
            if r = newint then r1 + (r2 - 1.0)
            else
                //printfn "%i %f" r (r1 + r2)
                r1 + r2
    
    let thisfloat = hahaha (lst) (0)
    thisfloat
    
let rec decimal2fraction(number: float) : float =
    let r = ceil number
    let r2 = number - r
    let r3 = -0.1
    if (r2<r3) then 
        decimal2fraction(number*10.0)
    else 
        number  

let cfrac2frac(lst: int list)(i: int): int*int=
    let floatValue = cfrac2float (lst) (i)
    let tæller = decimal2fraction floatValue
    let nævner = tæller / floatValue
    printfn "%f %f %f" floatValue tæller nævner
    ((int tæller), (int nævner))


[<EntryPoint>]
let main args =
    let lst = [3;7;15;1;292]
    let lst2 = [3;4;12;4]
    let lst3 = []

    printfn "The list %A makes the continued fraction: %A" lst (cfrac2frac (lst) (3))
    //printfn "The list %A makes the continued fraction: %f" lst2 (cfrac2float (lst2) (2))
    //printfn "The list %A makes the continued fraction: %f" lst3 (cfrac2float (lst3) (1))
    0