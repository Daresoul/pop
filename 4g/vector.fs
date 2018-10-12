module vec2d

///This Function takes 2 arguments shoves it in a tuple and then returns the tuple.
///<parameter>x, y</parameter>
///<return>a tuple (x, y)</return>
let createVector (x : float) (y : float) =
    (x,y)

///<summary>
/// Creates a vector by a specific length and with an angle to the x-axis
///</summary>
///<param name="ang">The angle you want your vector with</param>
///<param name="len">The length you want your vector to be</param>
///<returns>Returns a vector as tuple with an angle</returns>
let createVectorAngLen (ang : float) (len : float) =
    let x = len * (cos ang)
    let y = len * (sin ang)

    (x,y)


///<summary>
/// This will calculate the length of a vector
///</summary>
///<param name="vector">The vector you want to get the lenght of</param>
///<returns>length of vector</returns>
let getLength vector =
    let x = fst vector
    let y = snd vector

    let len : float = sqrt (x**2.0+y**2.0)

    len


///<summary>
/// This will calculate the angle of a vector
///</summary>
///<param name="vector">The vector we wanna get the angle of</param>
///<returns>The angle of the vector</returns>
let getAngle  vector =
    let x = fst vector
    let y = snd vector

    atan2 y x


///<summary>
/// Creates a vector between the 2 vector ends
///</summary>
///<param name="vector1">The first vector we want to subtract</param>
///<param name="vector2">The second vector we want to subtract</param>
///<returns>returns a vector as a tuple</returns>
let subtractVector (vector1 : float * float) (vector2 : float * float) : float * float =
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = abs (x1 - x2)
    let y3 = abs (y1 - y2)

    (x3, y3)


///<summary>
/// This will add 2 vectors together
///</summary>
///<param name="vector1">This is the first vector</param>
///<param name="vector2">This is the second vector</param>
///<returns>returns a longer vector where vector1 and vector2 has been added</returns>
let addVectors (vector1 : float * float) (vector2 : float * float) =
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = x1 + x2
    let y3 = y1 + y2

    (x3, y3)


///<summary>
/// Calculates and returns dot product of 2 vectors.
///</summary>
///<param name="vector1">This is the first vector</param>
///<param name="vector2">This is the second vector</param>
///<returns>returns dot product of both the vectors</returns>
let vectorProduct (vector1 : float * float) (vector2 : float * float) = 
    let x1 = fst vector1
    let x2 = fst vector2

    let y1 = snd vector1
    let y2 = snd vector2

    let x3 = x1 * x2
    let y3 = y1 * y2

    let dotProdukt = x3 + y3

    dotProdukt


///<summary>
/// Multiplies the x's and the y's of two vectors.
///</summary>
///<param name="vector1">This is the vector you wanna change</param>
///<param name="a">The number you wanna multiply the vector by</param>
///<returns>Returns a larger vector where x and y has been multiplied</returns>
let multiplyVector (vector1 : float * float) (a : float) =
    let x : float = fst vector1
    let y : float = snd vector1

    let x2 : float = x * a
    let y2 : float = y * a

    (x2, y2)

///<summary>
/// Returns the value of pi
///</summary>
///<returns>Returns pi</returns>
let getPi =
    System.Math.PI

///<summary>
/// Converts an angle in degrees to an angle in radians
///</summary>
///<param name="n">The angle in deegrees</param>
///<returns>Returns an angle in radians</returns>
let convertDegreeToRadian (n : float) =
    ((n * (float getPi))/(float 180))


///Calculates the length of a pseudo circle with n edges.
///<parameter>n, r, float</parameter>
///<return>float</return>
// n = antallet af punkter
let polyLen (n : int) (r : float) : float =
    let angle : float = (float 360) / (float n)
    let radianAngle : float = convertDegreeToRadian angle

    let startVector = createVector r 0.0

    let letnewVector = createVectorAngLen (float radianAngle) r

    let newvec = subtractVector startVector letnewVector

    let len = getLength newvec
    
    (len * (float n))




    
