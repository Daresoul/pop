
module vec2d

///<summary>
/// This creates a vector as a Tuple
///</summary>
///<param name="x">The x point of the vector</param>
///<param name="y">The y point of the vector</param>
///<returns>a tupe with the 2 values formated as (x, y)</returns>
val createVector : float -> float -> float * float

///<summary>
/// Creates a vector by a specific length and with an angle to the x-axis
///</summary>
///<param name="ang">The angle you want your vector with in radians</param>
///<param name="len">The length you want your vector to be</param>
///<returns>Returns a vector as tuple with an angle</returns>
val createVectorAngLen : float -> float -> float * float

///<summary>
/// This will calculate the length of a vector
///</summary>
///<param name="vector">The vector you want to get the lenght of</param>
///<returns>length of vector</returns>
val getLength : float * float -> float

///<summary>
/// This will calculate the angle of a vector
///</summary>
///<param name="vector">The vector we wanna get the angle of</param>
///<returns>The angle of the vector</returns>
val getAngle : float * float -> float

///<summary>
/// Creates a vector between the 2 vector ends
///</summary>
///<param name="vector1">The first vector we want to subtract</param>
///<param name="vector2">The second vector we want to subtract</param>
///<returns>returns a vector as a tuple</returns>
val subtractVector : float * float -> float * float -> float * float

///<summary>
/// This will add 2 vectors together
///</summary>
///<param name="vector1">This is the first vector</param>
///<param name="vector2">This is the second vector</param>
///<returns>returns a longer vector where vector1 and vector2 has been added</returns>
val addVectors : float * float -> float * float -> float * float

///<summary>
/// Calculates and returns dot product of 2 vectors.
///</summary>
///<param name="vector1">This is the first vector</param>
///<param name="vector2">This is the second vector</param>
///<returns>returns dot product of both the vectors</returns>
val vectorProduct : float * float -> float * float -> float * float

///<summary>
/// Multiplies the x's and the y's of two vectors.
///</summary>
///<param name="vector1">This is the vector you wanna change</param>
///<param name="a">The number you wanna multiply the vector by</param>
///<returns>Returns a larger vector where x and y has been multiplied</returns>
val multiplyVector : float * float -> float -> float * float

///<summary>
/// Returns the value of pi
///</summary>
///<returns>Returns pi</returns>
val getPi : float

///<summary>
/// Converts an angle in degrees to an angle in radians
///</summary>
///<param name="n">The angle in deegrees</param>
///<returns>Returns an angle in radians</returns>
val convertDegreeToRadian : float -> float

///<summary>
/// Calculates the circumfrance of a pseudo circle with n edges and r radius big
///</summary>
///<param name="n">The amount of edges it has</param>
///<param name="r">The radius of the circle</param>
///<returns>Returns the length of around the polygon</returns>
val polyLen : int -> float -> float