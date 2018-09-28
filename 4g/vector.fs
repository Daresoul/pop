module vec2d

let createVector (x : float) (y : float) =
    (x,y)

let createVectorAngLen (ang : float) (len : float) =
    let x = len * (cos ang)
    let y = len * (sin ang)

    (x,y)

let getLength vector =
    let x = fst vector
    let y = snd vector

    let len : float = sqrt (x**2.0+y**2.0)

    len

let getAngle  vector =
    let x = fst vector
    let y = snd vector

    atan2 y x

let subtractVector (vector1 : float * float) (vector2 : float * float) : float * float =
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

    let dotProdukt = x3 + y3

    dotProdukt

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

// n = antallet af punkter
let polyLen (n : int) (r : float) : float =
    let angle : float = (float 360) / (float n)
    let radianAngle : float = convertDegreeToRadian angle

    let startVector = createVector r 0.0

    let letnewVector = createVectorAngLen (float radianAngle) r

    let newvec = subtractVector startVector letnewVector

    let len = getLength newvec
    
    (len * (float n))




    
