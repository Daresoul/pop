let (CircleCenter : ImgUtil . point) = (50,50)
let (radius : int) = (45)
let (red : ImgUtil . colour) = (255,0,0)

let (sqrLeft : ImgUtil . point) = (40,40)
let (sqrRight : ImgUtil . point) = (90,110)
let (blue : ImgUtil . colour) = (0,0,255)

let (figCircle : ImgUtil . figure) = ImgUtil . Circle (CircleCenter, radius, red)
let (figSqr : ImgUtil . figure) = ImgUtil . Rectangle (sqrLeft, sqrRight, blue)
let (figTest : ImgUtil . figure) = ImgUtil . Mix (figCircle, figSqr)

do ImgUtil . makePicture "figTest" figTest 100 150

//Again... what to say here... 