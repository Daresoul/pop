//<summary> Calculates the continued fraction of a fraction based upon two integers.
//<remarks> Returns an empty list if dividing with zero. 
let rec frac2cfrac (t:int)(n:int): int list =
    if n = 0 then
        let lst = List.empty<int> 
        lst
        else
        let r1 = n
        let r2 = t
        let ri = r2 % r1
        let qi = r2/r1
        let pass = n
        let lst = [qi]
        //printfn "r1 = %i r2 = %i ri = %i qi = %i pass = %i lst = %A "r1 r2 ri qi pass lst
        if (ri > 0) then lst@frac2cfrac(pass)(ri)
            else lst
    
 
        
[<EntryPoint>]
let main args =
    let t1 = 649
    let n1 = 200
    let r1 = frac2cfrac(t1)(n1)
    printfn "%i / %i has the continued fraction %A" t1 n1 r1
    let t2 = 1
    let n2 = 20
    let r2 = frac2cfrac(t2)(n2)
    printfn "%i / %i has the continued fraction %A" t2 n2 r2
    let t3 = 12
    let n3 = 1
    let r3 = frac2cfrac(t3)(n3)
    printfn "%i / %i has the continued fraction %A" t3 n3 r3
    let t4 = 314159 
    let n4 = 100000
    let r4 = frac2cfrac(t4)(n4)
    printfn "%i / %i has the continued fraction %A" t4 n4 r4
    let t5 = 1
    let n5 = 0
    let r5 = frac2cfrac(t5)(n5)
    printfn "%i / %i has the continued fraction %A" t5 n5 r5
    let t6 = 0 
    let n6 = 1
    let r6 = frac2cfrac(t6)(n6)
    printfn "%i / %i has the continued fraction %A" t6 n6 r6
    0   