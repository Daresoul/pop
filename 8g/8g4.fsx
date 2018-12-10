let (CircleCenter : ImgUtil . point) = (50,50)
let (radius : int) = (45)
let (red : ImgUtil . colour) = (255,0,0)
let (figCircle : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius, red)

let (sqrLeft : ImgUtil . point) = (40,40)
let (sqrRight : ImgUtil . point) = (90,110)
let (blue : ImgUtil . colour) = (0,0,255)
let (figSqr : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft, sqrRight, blue)

let (figTest : ImgUtil . figure) = ImgUtil . Mix (figCircle, figSqr)


let moveCircle (f : ImgUtil . figure)(x,y)(colour): ImgUtil . figure : 
    let (newCenter : ImgUtil . point) = (fst (first f)+x, snd (first f)+y)
    let (newCircle : ImgUtil . figure) = ImgUtil . Circle (newCenter, radius, colour)
    newCircle

let moveRectangle (f : ImgUtil . figure)(x,y) : ImgUtil . figure
    let (newSqrRight : ImgUtil . figure) = (first (first f) + x, Second (first f) +y)
    let (newSqrLeft : ImgUtil . figure) = (Second (first f) + x, Second (Second f) +y)
    let (newSqr : ImgUtil figure) = ImgUtil . Rectangle (newSqrLeft, newSqrRightm, )

let rec move (f: ImgUtil . figure)(x,y) : ImgUtil . figure = 
    match f with
    | ImgUtil . Circle ((x,y) , r, colour)--> moveCircle f x y //colour
    | ImgUtil . Rectangle ((x1,y1), (x2,y2), colour) -> moveRectangle f x y //colour
    | ImgUtil . Mix (fig1, fig2) -> ((move fig1 (x,y)),(move fig2 (x,y)) )

do ImgUtil . makePicture "figTest" figTest 100 150