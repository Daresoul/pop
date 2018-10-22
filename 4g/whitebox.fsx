///This program whitebox-tests the functions in the file, vector.fs. It also prints a table showing what works and what does'nt

printfn "WhiteBox test.\nFunction name: Relevant vector information for calculation => answer == expected answer => Are they the same. Numerical numbers are estimated within a 1 procent margin.\n"
let mutable functionName = "getAngle"
let mutable vector = vec2d.createVector 0.0 1.0
printfn "%s\n" (whitebox.TuplesSignleInFloatOut functionName vector (vec2d.getAngle vector) 1.57)
vector <- vec2d.createVector 1.0 0.0
printfn "%s\n" (whitebox.TuplesSignleInFloatOut functionName vector (vec2d.getAngle vector) 0.00)
///__________________________________________________________________________________________________///
functionName <- "subtractVector"
let mutable vector2 = vec2d.createVector 1.0 2.0
vector <- vec2d.createVector 0.0 0.0
printfn "%s\n" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.subtractVector vector vector2) (1.0 , 2.0))

vector2 <- vec2d.createVector -1.0 0.0
printfn "%s\n" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.subtractVector vector vector2) (1.0, 0.0))
///__________________________________________________________________________________________________///
functionName <- "addVectors"
printfn "%s\n" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.addVectors vector vector2) (-1.0,0.0))

vector <- vec2d.createVector 1.0 2.0
printfn "%s\n" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.addVectors vector vector2) (0.0,2.0))

vector2 <- vec2d.createVector 30.0 21.0
printfn "%s\n" (whitebox.TuplesTwoInSingleOut functionName vector vector2 (vec2d.addVectors vector vector2) (31.0, 23.0))
///__________________________________________________________________________________________________///
functionName <- "vectorProduct"
vector <- vec2d.createVector 0.0 0.0
printfn "%s\n" (whitebox.TuplesTwoInFloatOut functionName vector vector2 (vec2d.vectorProduct vector vector2) 0.0)

vector <- vec2d.createVector (-30.0) (-21.0)
printfn "%s\n" (whitebox.TuplesTwoInFloatOut functionName vector vector2 (vec2d.vectorProduct vector vector2) -1341.00)

vector <- vec2d.createVector 3.0 5.0
vector2 <- vec2d.createVector 2.0 3.0
printfn "%s\n" (whitebox.TuplesTwoInFloatOut functionName vector vector2 (vec2d.vectorProduct vector vector2) 21.0)
///__________________________________________________________________________________________________///
functionName <- "multiplyVector"
vector <- vec2d.createVector 0.0 0.0
printfn "%s\n" (whitebox.TupleAndConstInTupleOut functionName vector (0.0) (vec2d.multiplyVector vector (0.0)) (0.0, 0.0))

printfn "%s\n" (whitebox.TupleAndConstInTupleOut functionName vector2 (-1.0) (vec2d.multiplyVector vector2 (-1.0)) (-2.0, -3.0))



