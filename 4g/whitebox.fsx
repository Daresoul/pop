let isbetween (start : float) (End : float) (value : float) =
    if start < value then
        if End > value then
            true
        else
            false
    else
        false


let mutable vector = (0.0, 0.0)
printfn "%s %30s %30s %15s %15s" "function" "input" "output" "forventet output" "ca omkring"

vector <- vec2d.createVector 0.0 1.0
printfn "%s %25s(%f, %f) %30f %15f %15b" "getAngle" "" (fst vector) (snd vector) (vec2d.getAngle vector) 1.57 (isbetween 1.57 1.58 (vec2d.getAngle vector))

vector <- vec2d.createVector 1.0 0.0
printfn "%s %25s(%f, %f) %30f %15f %15b" "getAngle" "" (fst vector) (snd vector) (vec2d.getAngle vector) 0.00 (isbetween -0.001 0.001 (vec2d.getAngle vector))

vector <- vec2d.createVector 0.0 (0.0)
printfn "%s %25s(%f, %f) %30f %15f %15b %7b" "Subtract" "" (fst vector) (snd vector) (vec2d.getAngle vector) 0.00 (isbetween -0.001 0.001 ( fst vec2d.subtractVector (0.0 -1.0) (-1.0 0.0))) (isbetween -0.001 0.001 ( snd vec2d.subtractVector (0.0 -1.0) (-1.0 0.0)))


//4g.2
//b)
//For a polygone with n-> infinity the length (i.e. circumference) goes towords that of a perfect circle.
// This can be seen if one looks at a megagon (polygon with a million sides.) It is for the human eye a perfec circle.

// Suggestion - Since the circle has 1 as radius, its circumference should be pi.
// Meaning the bigger n is, the return value is closer to 2 * pi.
