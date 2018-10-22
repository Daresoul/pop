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


//Angle check (working 50%)
///<summary>
/// Returns formated string with all the values inside
///</summary>
///<param name="functionName">A string with the function name inside</param>
///<param name="tupeInput">a tuple input of floats</param>
///<param name="output">The output made by the function</param>
///<param name="expected">The expected output of the function</param>
///<returns>Returns formated string with values</returns>
let TuplesSignleInFloatOut (functionName : string) (tupeInput : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput
    sprintf "%14s: Vector (%.2f, %.2f) angle =>  %.2f == %.2f => %b" functionName x y output expected ((output>expected*0.99)&&(output<(expected*1.01)))
 
/// This is for 2 tupe input - single tupe output
///<summary>
/// Returns formated string with all the values inside
///</summary>
///<param name="functionName">A string with the function name inside</param>
///<param name="tupeInput1">a tuple input of floats</param>
///<param name="tupeInput2">a tuple input of floats</param>
///<param name="output">The output made by the function</param>
///<param name="expected">The expected output of the function</param>
///<returns>Returns formated string with values</returns>
let TuplesTwoInSingleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    let (x2, y2) = output
    let (ex, ey) = expected
    sprintf "%14s: Vector (%.2f, %.2f) and vector (%.2f, %.2f) => (%.2f, %.2f) == (%.2f, %.2f) => %b" functionName x y x1 y1 x2 y2 ex ey (((ex*0.99<x2)&&(ex*1.01>x2))&&((ey*0.99<y2)&&(ey*1.01>y2)))

/// This is for 2 tupe input - single tupe output
///<summary>
/// Returns formated string with all the values inside
///</summary>
///<param name="functionName">A string with the function name inside</param>
///<param name="tupeInput1">a tuple input of floats</param>
///<param name="tupeInput2">a tuple input of floats</param>
///<param name="output">The output made by the function</param>
///<param name="expected">The expected output of the function</param>
///<returns>Returns formated string with values</returns>
let TuplesTwoInFloatOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float * float) (output : float) (expected : float) =
    let (x, y) = tupeInput1
    let (x1, y1) = tupeInput2
    sprintf "%14s: Vector (%.2f, %.2f) dot vector (%.2f, %.2f) => (%.2f) == (%.2f) => %b" functionName  x y  x1 y1  output expected (output = expected)

//multiplytest (working)
///<summary>
/// Returns formated string with all the values inside
///</summary>
///<param name="functionName">A string with the function name inside</param>
///<param name="tupeInput1">a tuple input of floats</param>
///<param name="tupeInput2">a tuple input of floats</param>
///<param name="output">The output made by the function</param>
///<param name="expected">The expected output of the function</param>
///<returns>Returns formated string with values</returns>
let TupleAndConstInTupleOut (functionName : string) (tupeInput1 : float * float) (tupeInput2 : float) (output : float * float) (expected : float * float) =
    let (x, y) = tupeInput1
    let (x1, y1) = expected
    let (x2, y2) = output
    sprintf "%14s: Vector (%.2f, %.2f) multiply by (%.2f) => (%.2f, %.2f) == (%.2f, %.2f) => %b" functionName x y tupeInput2 x2 y2 x1 y1 (x2=x1 && y2 =y1)
