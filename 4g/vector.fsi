
module vec2d

///<summary>
/// This creates a vector as a tupe
///</summary>
///<param name="x">The x point of the vector</param>
///<param name="y">The y point of the vector</param>
///<returns>a tupe with the 2 values</returns>
val createVector : float -> float -> float * float

///<summary>
/// This will calculate the length of a vector
///</summary>
///<param name="vector">A vector tupe</param>
///<returns>length of vector</returns>
val getLength : float * float -> float

///<summary>
/// This will calculate the angle of a vector
///</summary>
///<param name="vector"></param>
///<returns>length of vector</returns>
val getAngle : float * float -> float

///Takes two floats and adds them.
///Calculates and returns dot product of 2 vectors.
val addVectors : float * float -> float * float -> float * float

///Takes two vectors and returns dot product.
val vectorProduct : float * float -> float * float -> float * float

///Multiplies the x's and the y's of two vectors.
val multiplyVector : float * float -> float -> float * float