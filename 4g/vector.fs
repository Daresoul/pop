module vec2d

let createVector (x : float) (y : float) =
    (x,y)

let createVectorAngLen (vector : float * float) (ang : float) (len : float) =
    let vectorx = fst vector
    let vectory = snd vector
    let x = len * (cos ang)
    let y = len * (sin ang)

    (x,y)

let createVectorAngLenDecimal (vector : decimal * decimal) (ang : decimal) (len : decimal) =
    let vectorx = fst vector
    let vectory = snd vector
    let x = len * (decimal (cos ang))
    let y = len * (decimal (sin ang))

    (x,y)

let getLength vector =
    let x = fst vector
    let y = snd vector

    let len : float = sqrt (x**2.0+y**2.0)

    len

let getLengthDecimal (vector : decimal * decimal) =
    let x = fst vector
    let y = snd vector

    let len : decimal = sqrt (x**2.0+y**2.0)

    len

let getAngle vector =
    let x = fst vector
    let y = snd vector

    atan2 y x

let subtractVectors (vector1 : float * float) (vector2 : float * float) : float * float =
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = abs (x1 - x2)
    let y3 = abs (y1 - y2)

    (x3, y3)

let subtractVectorDecimal (vector1 : decimal * decimal) (vector2 : decimal * decimal) : decimal * decimal =
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = abs (x1 - x2)
    let y3 = abs (y1 - y2)

    (x3, y3)

let addVectors (vector1 : float * float) (vector2 : float * float) =
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = x1 + x2
    let y3 = y1 + y2

    (x3, y3)

let vectorProduct (vector1 : float * float) (vector2 : float * float) = 
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = x1 * x2
    let y3 = y1 * y2

    (x3, y3)

let multiplyVector (vector1 : float * float) (a : float) =
    let x : float = fst vector1
    let y : float = snd vector1

    let x2 : float = x * a
    let y2 : float = y * a

    (x2, y2)

let getPi =
    System.Math.PI

let convertDegreeToRadian (n : float) =
    ((n * (float getPi))/(float 180))

let convertDegreeToRadianDecimal (n : decimal) =
    ((n * (decimal getPi))/(decimal 180))

// n = antallet af punkter
let polyLen (n : int) (r : float) : float =
    let angle : float = (float 360) / (float n)
    let radianAngle : float = convertDegreeToRadian angle
    //printfn "%f\n%f" angle radianAngle

    let startVector = createVector r 0.0
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst startVector) (snd startVector) (getLength startVector)

    let letnewVector = createVectorAngLen startVector (float radianAngle) r
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst letnewVector) (snd letnewVector) (getLength letnewVector)

    let newvec = subtractVectorDecimal startVector letnewVector
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst letnewVector) (snd newvec) (getLength newvec)


    let len = getLength newvec
    //printfn "len: %f" len 
    
    (len * (float n))

let polyLenDecimal (n : int) (r : float) : decimal =
    let angle : decimal = (decimal 360) / (decimal n)
    let radianAngle : decimal = convertDegreeToRadianDecimal float angle
    //printfn "%f\n%f" angle radianAngle

    let startVector = createVector r 0.0
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst startVector) (snd startVector) (getLength startVector)

    let letnewVector = createVectorAngLenDecimal startVector (float radianAngle) r
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst letnewVector) (snd letnewVector) (getLength letnewVector)

    let newvec = subtractVectors startVector letnewVector
    //printfn "vector: (%f, %f)\nlen: %f\n\n" (fst letnewVector) (snd newvec) (getLength newvec)


    let len = getLengthDecimal newvec
    //printfn "len: %f" len 
    
    (len * (float n))




    
