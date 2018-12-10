///<summary> A set of three function that returns eighter the first, second or third parameter of a tuple. </summary>
///<param tuple > A tuple of three.</param>
///<returns>The requested position of the given tuple. </returns>
let first (a, _, _) = a
let second (_, b, _) = b
let thirde (_, _, c) = c

///<summary> A function that checks if a given colour is in the rgb. </summary>
///<param colour = (r,g,b)> The colour in the rgb format.</param>
///<returns> A bool </returns>
let checkColour (c): bool = 
    ((first c)<=255 && (first c)>=0 && (second c)<=255 && (second c)>=0 && (thirde c)<=255 && (thirde c)>=0)

///<summary> A function that checks if a given figure (circle, Rectangle or a mix of them) are correctely made. A circle must be non negative, the top coorner of a Rectanglee must be above the bottom one, and the colour must be in the rgb interval. (0-255) </summary>
///<param figure> The figure that is to be checked.</param>
///<returns> A bool </returns>
let rec checkFigure (f: ImgUtil . figure) : bool = 
    match f with
    | ImgUtil . Circle ((x,y) , r, colour)-> (((r>=0))&&(checkColour colour))
    | ImgUtil . Rectangle ((x1,y1), (x2,y2), colour) -> ((x1<=x2)&&(y1<=y2)&&(checkColour colour))
    | ImgUtil . Mix (fig1, fig2) -> checkFigure fig1 && checkFigure fig2

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

let (CircleCenter2 : ImgUtil . point) = (50,50)
let (radius2 : int) = (30)
let (red2 : ImgUtil . colour) = (0,200,0)
let (figCircle2 : ImgUtil . figure) = ImgUtil . Circle (CircleCenter2, radius2, red2)
let (superTest : ImgUtil . figure) = ImgUtil . Mix (figTest, figCircle2)

let (radius3 : int) = (-45)
let (figCircle3 : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius3, red)

let (red4 : ImgUtil . colour) = (-255,0,0)
let (figCircle4 : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius, red4)

let (sqrLeft2 : ImgUtil . point) = (90,110)
let (sqrRight2 : ImgUtil . point) = (40,40)
let (figSqr2 : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft2, sqrRight2, blue)

let (blue2 : ImgUtil . colour) = (0,0,-255)
let (figSqr3 : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft, sqrRight, blue2)

let (figTest2 : ImgUtil . figure) = ImgUtil . Mix (figCircle, figSqr2)
let (superTest2 : ImgUtil . figure) = ImgUtil . Mix (figTest2, figCircle2)

printfn "Good circle = %b" (ImgUtil . checkFigure figCircle)
printfn "Bad circle (negative r)= %b" (ImgUtil . checkFigure figCircle3)
printfn "Bad circle (bad colour)= %b" (ImgUtil . checkFigure figCircle4)
printfn "Good sqr = %b" (ImgUtil . checkFigure figSqr)
printfn "Bad sqr (negative r)= %b" (ImgUtil . checkFigure figSqr2)
printfn "Bad sqe (bad colour)= %b" (ImgUtil . checkFigure figSqr3)
printfn "Good mix 1 lv =%b" (ImgUtil . checkFigure figTest)
printfn "Good mix 2 lv = %b" (ImgUtil . checkFigure superTest)
printfn "Bad mix 1 lv =%b" (ImgUtil . checkFigure figTest2)
printfn "Bad mix 2 lv = %b" (ImgUtil . checkFigure superTest2)
*)