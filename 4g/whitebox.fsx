let diff = 0.01

let mutable functionName = "getAngle"
let mutable vector = vec2d.createVector 0.0 1.0
printfn "%s" (whitebox.TuplesSignleInFloatOut functionName vector (vec2d.getAngle vector) 1.57)
vector <- vec2d.createVector 1.0 0.0
printfn "%s" (whitebox.TuplesSignleInFloatOut functionName vector (vec2d.getAngle vector) 0.0)

functionName <- "subtractVector"
let mutable vector2 = vec2d.createVector 0.0 0.0
vector <- vec2d.createVector 0.0 0.0
printfn "%s" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.subtractVector vector vector2) (0.0, 0.0))

vector <- vec2d.createVector (-1.0) 0.0
vector2 <- vec2d.createVector 0.0 1.0
printfn "%s" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.subtractVector vector vector2) (0.0, 0.0))