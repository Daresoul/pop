/// A 2 dimensional vector libary
/// Vectors are represented as a string contaning the starting point and end point of the vector.
/// Tne format of the string is x1;y1;x2;y2 where x1 and x2 is the starting coordinate and ending coordinate respectively.
/// The same formate applies for the y-values. 
/// In this setup the starting point of a vector is not pre-defined. (i.e. it is not just (0;0))

module stringVector2D
/// The length of the vector
val len : string -> float 
/// The angle between two vectors
val ang : string -> string -> float
/// Multiplication of a float and a vector
val scale : string -> float -> string
/// Addition of two vectors
val add : string -> string -> string
/// Dot the product of two vectors
val dot : string -> string -> float

/// By using strings as a way to represent vectros, tubels are avoided as requested. This will require a bit more coding to do calculatios on the vectors, since the string would have to be read, the values extracted and type cast to floats. (use ';' as indication of new sign) To manipulate severel vectors the output of some of the functions the require the concatenation of a new vector string. 
/// By not having a predefined starting point in the (0;0) more is required of the user to do calculations, but more advanced calculations can be done, since the vectors are now free. 
/// Finally the use of the type string to store vectors is gonna require more memory since each individual char in the string is represented by the ASCII charchters. 
/// An more logical alternative would be to make a object that represent a vector. 