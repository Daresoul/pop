module whitebox
// Check if float is between a value of error
//let isbetween (desiredValue : float) (off : float) (value : float) =
//    if (desiredValue - off) < value then
//        if (desiredValue + off) > value then
//            true
//        else
//            false
//    else
//        false

/// This is for a single tupe input - single tupe output
let printtupes (functionName : string) (tupeInput : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput
    let (x2, y2) = func
    let (ex, ey) = expected
    sprintf "%s (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f)" functionName x y x2 y2 ex ey

/// This is for 2 tupe input - single tupe output
let printtupes (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    let (x2, y2) = func
    let (ex, ey) = expected
    sprintf "%s (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f) (%.2f, %.2f)" functionName x y x1 y1 x2 y2 ex ey