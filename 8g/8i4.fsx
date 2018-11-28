///<summary> A function that moves a circle, by taking the old one and returning a new in a different location. </summary>
///<param centrum = (x1,y1)> The center of the circle.</param>
///<param direction = (x,y)> The amount that the x and y coordinats the circle shall be moved.</param>
///<param radius = r> The radius of the circle </param>
///<param colour> The colour of the circle </param>
///<returns> A new figure where the circle have been moved </returns>
let moveCircle (x1,y1)(x,y)(r)(colour) = 
    let (newCenter : ImgUtil . point) = (x1 + x , y1 + y)
    let (newCircle : ImgUtil . figure) = ImgUtil . Circle (newCenter, r, colour)
    newCircle

///<summary> A function that moves a Rectangle, by taking the old one and returning a new in a different location. </summary>
///<param upper left corner = (x1,y1)> The upper left corner of the Rectangle.</param>
///<param Lower right corner = (x1,y1)> The lower right corner of the Rectangle.</param>
///<param direction = (x,y)> The amount that the x and y coordinats the Rectanglee shall be moved.</param>
///<param colour> The colour of the Rectangle </param>
///<returns> A new figure where the Rectangle have been moved </returns>
let moveRectangle (x1,y1)(x2,y2)(x,y)(colour)  =
    let (newSqrLeft : ImgUtil . point) = ((x1 + x), (y1 + y))
    let (newSqrRight : ImgUtil . point) =  ((x2 + x), (y2 + y))
    let (newSqr : ImgUtil . figure) = ImgUtil . Rectangle (newSqrLeft, newSqrRight, colour)
    newSqr

///<summary> A generic function that moves a figure (circle, sqaur, or a mix), by taking the old one and returning a new in a different location. </summary>
///<param figure = f> The figure to be moved </param>
///<param direction = (x,y)> The amount that the x and y coordinats the figure shall be moved.</param>
///<returns> A new figure where the figure have been moved </returns>
let rec move (f: ImgUtil . figure)(x,y)  = 
    match f with
    | ImgUtil . Circle ((x1,y1) , r, colour) -> moveCircle (x1,y1) (x,y) r colour
    | ImgUtil . Rectangle ((x1,y1), (x2,y2), colour) -> moveRectangle (x1,y1) (x2,y2) (x,y) colour
    | ImgUtil . Mix (fig1, fig2) -> ImgUtil . Mix ((move fig1 (x,y)), (move fig2 (x,y))) 

//ALT OVERSTÅENDE ER FLYTTET TIL img_util.fs OG TILPASSET (i.e. alle "ImgUtil . " er blevet fjernet.)
(*
//Whiteboxtesting to the max.
let (CircleCenter : ImgUtil . point) = (50,50)
let (radius : int) = (45)
let (red : ImgUtil . colour) = (255,0,0)
let (figCircle : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius, red)

let (sqrLeft : ImgUtil . point) = (40,40)
let (sqrRight : ImgUtil . point) = (90,110)
let (blue : ImgUtil . colour) = (0,0,255)
let (figSqr : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft, sqrRight, blue)

let (figTest : ImgUtil . figure) = ImgUtil . Mix (figCircle, figSqr)
do ImgUtil . makePicture "figTest1" (move figCircle (-20,20)) 100 150
do ImgUtil . makePicture "figTest2" (move figSqr (-20,20)) 100 150
do ImgUtil . makePicture "figTest3" (move figTest (-20,20)) 100 150
*)