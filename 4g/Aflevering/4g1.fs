module whitebox
// Check if float is between a value of error
let isbetween (desiredValue : float) (off : float) (value : float) =
    if (desiredValue - off) < value then
        if (desiredValue + off) > value then
            true
        else
            false
    else
        false

/// This is for a single tupe input - single tupe output
(*let TuplesSignleInSingleOut (functionName : string) (tupeInput : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput
    let (x2, y2) = output
    let (ex, ey) = expected
    sprintf "%14s: (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f)" functionName x y x2 y2 ex ey *)

//Angle check (working 50%)
let TuplesSignleInFloatOut (functionName : string) (tupeInput : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput
    sprintf "%14s: Vector (%.2f, %.2f) angle =>  %.2f == %.2f => %b" functionName x y output expected ((output>expected*0.99)&&(output<(expected*1.01)))
 
/// This is for 2 tupe input - single tupe output
let TuplesTwoInSingleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    let (x2, y2) = output
    let (ex, ey) = expected
    sprintf "%14s: Vector (%.2f, %.2f) and vector (%.2f, %.2f) => (%.2f, %.2f) == (%.2f, %.2f) => %b" functionName x y x1 y1 x2 y2 ex ey (((ex*0.99<x2)&&(ex*1.01>x2))&&((ey*0.99<y2)&&(ey*1.01>y2)))

/// This is for 2 tupe input - single tupe output
let TuplesTwoInFloatOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    sprintf "%14s: Vector (%.2f, %.2f) dot vector (%.2f, %.2f) => (%.2f) == (%.2f) => %b" functionName  x y  x1 y1  output expected (output = expected)

//multiplytest (working)
let TupleAndConstInTupleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = expected
    let (x2, y2) = output
    sprintf "%14s: Vector (%.2f, %.2f) multiply by (%.2f) => (%.2f, %.2f) == (%.2f, %.2f) => %b" functionName x y tupeInput2 x2 y2 x1 y1 (x2=x1 && y2 =y1)
