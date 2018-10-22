
///<summary> Takes a float and returns its numerator as part fraction with a denominator of 10 to the power of n.</summary>
///<remarks> 3.254 would be returned as 3254. We are returning a aproximation. </remarks>
let rec decimal2fraction(number: float) : float =
    let r = ceil number
    let r2 = number - r
    let r3 = -0.00001
    if (r2<r3) then 
        decimal2fraction(number*10.0)
    else 
        number   

///<summary> Aproximate the continued fraction of a float and returns it as an int list. </summary>
///<remarks>  A few type casting are done to reduce risk of overflow during calulations. Finally the returned list is a Int32,since it is estimated that the risk of an overflow in the return list indexes is little to none. Pressision of an apriximation on the number pi goes to the 9th continued fraction index. 
///<remarks>According to oeis.org (A001203) at index 10 it should have been 14, not 4. The exact reason is not known, and is beyond the scope of this assigment. (Potential causes are: a longer row of decimals of pi is used at oeis.org or an conversion error. While printfn statments showed no sign of the error in the calculation, it is assumed it is due to the shorter use of the pi decimals.) </remarks>
let float2cfrac (number: float ) : int list =
    if number = 0.0 then 
        let lst = [0]
        lst
    else 
        let x1 = decimal2fraction(number)
        let x2 = System.Convert.ToInt64(x1)
        let y1 = x1/number
        let y2 = System.Convert.ToInt64(y1)
        let rec calculation (r1: int64)(r2: int64): int list = //Function in function start.
            let ri2 = r1
            let ri = r1 % r2
            let qi = r1/r2
            let pass = r2
            let lst = [System.Convert.ToInt32(qi)]
            if ri > (System.Convert.ToInt64(0)) then lst@calculation(pass)(System.Convert.ToInt64(ri))
            else lst //Function in function end.
        let lst = calculation(x2)(y2) //<- Function in function called. 
        lst
        
[<EntryPoint>]
let main args =
    let t1 = 3.245
    let r1 = float2cfrac(t1)
    printfn "The float %f has the continued fraction %A" t1 r1
    let t2 = 0.05
    let r2 = float2cfrac(t2)
    printfn "The float %f has the continued fraction %A" t2 r2
    let t3 = 12.0
    let r3 = float2cfrac(t3)
    printfn "The float %f has the continued fraction %A" t3 r3
    let t4 = 3.14159265359 
    let r4 = float2cfrac(t4)
    printfn "The float %f has the continued fraction %A" t4 r4
    let t5 = 0.0
    let r5 = float2cfrac(t5)
    printfn "The float %f has the continued fraction %A" t5 t5
    
    0   