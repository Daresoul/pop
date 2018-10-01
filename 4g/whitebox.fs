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
let TuplesSignleInSingleOut (functionName : string) (tupeInput : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput
    let (x2, y2) = output
    let (ex, ey) = expected
    sprintf "%s (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f)" functionName x y x2 y2 ex ey

let TuplesSignleInFloatOut (functionName : string) (tupeInput : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput
    sprintf "%s (%.2f, %.2f) %.2f %.2f" functionName x y output expected

/// This is for 2 tupe input - single tupe output
let TuplesTwoInSingleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    let (x2, y2) = output
    let (ex, ey) = expected
    sprintf "%s (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f)" functionName x y x1 y1 x2 y2 ex ey

/// This is for 2 tupe input - single tupe output
let TuplesTwoInFloatOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    sprintf "%s %10s(%.2f, %.2f) %10s(%.2f, %.2f) %10s(%.2f) %10s(%.2f)" functionName "" x y "" x1 y1 "" output "" expected

let TupleAndConstInTupleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = expected
    let (x2, y2) = output
    sprintf "%s On given vector (%.2f, %.2f) multiply by (%.2f) we get (%.2f, %.2f) vs what we expect (%.2f, %.2f)" functionName x y tupeInput2 x2 y2 x1 y1