open System.Numerics
open System
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
    let tæller = ceil (decimal2fraction floatValue)
    let nævner = tæller / floatValue
    let tæller2 = bigint tæller
    let nævner2 = bigint nævner
    printfn "%f %f %f" floatValue tæller nævner
    let gcd = (BigInteger.GreatestCommonDivisor(tæller2,nævner2))
    let returnTæller = (tæller2/gcd)
    let returnNævner = (nævner2/gcd)
    printfn "%A %A %A"gcd returnTæller returnNævner
    (int returnNævner,int returnTæller)


//let cfToScalar cf = List.foldBack (fun elem acc -> float elem + (1.0 / float acc)) cf System.Double.MaxValue

[<EntryPoint>]
let main args =
    let lst = [3;7;15;1;292;1]
    let lst2 = [3;4;12;4]
    let lst3 = []

   // printfn "%f" (cfToScalar lst)

    printfn "The list [3;4;12;4] makes the continued fraction: %i %i" <|| (cfrac2frac (lst2) (3)) 
    //printfn "The list [] makes the continued fraction: %i %i" <|| (cfrac2frac (lst3) (1))
    printfn "The list [3;7;15;1;292;1] makes the continued fraction: %i %i" <|| (cfrac2frac (lst) (3))
    0